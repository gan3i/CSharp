using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using ContactManager;

namespace cm
{
    internal class Repl
    {
        readonly TextReader input;
        readonly TextWriter output;
        readonly CommandFactory factory;
        readonly FlightRecorder flightRecorder;
        readonly DataStructures.Stack<ICommand> undo;

        readonly Regex verbRegex = new Regex(@"^(?<verb>\w+)");
        readonly Regex fieldsRegex = new Regex(@"(?<field>\w+)=(?<value>[^;]+)");

        internal Repl(TextReader input, TextWriter output, ContactStore store)
        {
            this.input = input;
            this.output = output;
            this.factory = new CommandFactory(store);
            this.flightRecorder = new FlightRecorder();
            this.undo = new DataStructures.Stack<ICommand>();

            Log.MessageLogged += ConsoleLogger;
            Log.MessageLogged += this.flightRecorder.Record;
        }

        internal void Run()
        {
            bool quitSeen = false;

            while (!quitSeen)
            {
                ICommand cmd = NextCommand();

                Stopwatch timer = new Stopwatch();
                timer.Start();

                switch(cmd.Verb)
                {
                    case Commands.Quit:
                        quitSeen = true;
                        break;
                    case Commands.Dump:
                        DumpFlightRecorder();
                        break;
                    case Commands.Undo:
                        UndoLastAction();
                        break;
                    case Commands.List:
                        PrintList(cmd.Execute());
                        break;
                    case Commands.Find:
                        PrintList(cmd.Execute());
                        break;
                    default:
                        RecordUndo(cmd.Execute());
                        break;
                }

                timer.Stop();
                Log.Verbose("{0} completed after: {1} ms", cmd.Verb, timer.Elapsed.TotalMilliseconds);
            }
        }

        private void UndoLastAction()
        {
            if(undo.Count > 0)
            {
                ICommand action = undo.Pop();

                Log.Info("Undo: executing {0}", action.Verb);

                action.Execute();
            }
            else
            {
                Log.Info("Undo: there is nothing to undo");
            }
        }

        private void RecordUndo(CommandResult result)
        {
            if(result.CanUndo)
            {
                Log.Verbose("Adding undo action");
                undo.Push(result.GetUndoCommand());
            }
        }

        private void DumpFlightRecorder()
        {
            output.WriteLine("---------------------------------------");

            foreach(Record r in flightRecorder.Dump())
            {
                output.WriteLine(string.Format("{0} - {1} {2}", r.When.ToString("u"), r.Level, r.Message));
            }

            output.WriteLine("---------------------------------------");
        }

        private void PrintList(CommandResult result)
        {
            foreach(Contact c in result.Results)
            {
                output.WriteLine(c.ToString());
            }
        }

        private ICommand NextCommand()
        {
            Prompt();
            return TryMapToCommand(Read());
        }

        private ICommand TryMapToCommand(string line)
        {
            string verb;
            IReadOnlyDictionary<string, string> args;

            if(ParseLine(line, out verb, out args))
            {
                switch(verb)
                {
                    case Commands.Add:
                        return factory.Add(args);
                    case Commands.Remove:
                        return factory.Remove(args);
                    case Commands.Find:
                        return factory.Find(args);
                    case Commands.Quit:
                        return factory.Quit();
                    case Commands.List:
                        return factory.List(args);
                    case Commands.Save:
                        return factory.Save(args);
                    case Commands.Load:
                        return factory.Load(args);
                    case Commands.Dump:
                        return factory.Dump(args);
                    case Commands.Undo:
                        return factory.Undo(args);
                    default:
                        return factory.UnknownCommand(verb);
                }
            }

            return factory.SyntaxError();
        }

        private bool ParseLine(string line, out string verb, out IReadOnlyDictionary<string,string> args)
        {
            Log.Verbose("input: {0}", line);

            bool parsedVerb = false;
            Dictionary<string,string> fields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            Match verbMatch = verbRegex.Match(line.TrimStart());
            if(verbMatch.Success)
            {
                verb = verbMatch.Value;
                parsedVerb = true;
                foreach (Match m in fieldsRegex.Matches(line))
                {
                    fields[m.Groups["field"].Value] = m.Groups["value"].Value;
                }
            }
            else
            {
                verb = Commands.Error;
                fields["message"] = string.Format("Unable to parse verb. ({0})", line);
            }

            args = fields;
            return parsedVerb;
        }

        private string Read()
        {
            return input.ReadLine();
        }

        private void Prompt()
        {
            output.Write("> ");
            output.Flush();
        }

        private void ConsoleLogger(object sender, LogMessageEventArgs e)
        {
            switch (e.Level)
            {
                case LogLevel.Verbose:
                    // do nothing
                    break;
                case LogLevel.Info:
                case LogLevel.Warning:
                case LogLevel.Error:
                    this.output.WriteLine(e.Message);
                    this.output.Flush();
                    break;
            }
        }
    }
}
