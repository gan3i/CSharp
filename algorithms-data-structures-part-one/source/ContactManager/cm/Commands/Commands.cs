using System;
using System.Collections.Generic;
using System.IO;
using ContactManager;

namespace cm
{
    internal class ListCommand : Command
    {
        public ListCommand(ContactStore store, IReadOnlyDictionary<string, string> args)
            : base(Commands.List, args, store)
        {
        }

        public override CommandResult Execute()
        {
            return new NonUndoCommandResult(this, Store.Contacts);
        }
    }

 

    internal class FindCommand : Command
    {
        internal FindCommand(ContactStore store, IReadOnlyDictionary<string, string> args)
            : base(Commands.Find, args, store)
        {
        }

        public override CommandResult Execute()
        {
            return new NonUndoCommandResult(this, Store.Search(CommandArgParser.FilterFromArgs(Args)));
        }
    }

    internal class LoadCommand : Command
    {
        internal LoadCommand(ContactStore store, IReadOnlyDictionary<string, string> args)
            : base(Commands.Load, args, store)
        {
        }

        public override CommandResult Execute()
        {
            if(!Args.ContainsKey("file"))
            {
                Log.Error(@"Load command requires a 'file' argument with the path to an existing CSV file.");
                return new NonUndoCommandResult(this, new List<Contact>(0));
            }

            string file = Args["file"];
            if(!File.Exists(file))
            {
                Log.Error(@"Load command 'file' argument must refer to an existing CSV file.");
                return new NonUndoCommandResult(this, new List<Contact>(0));
            }

            using (Stream strm = File.OpenRead(file))
            {
                CsvContactReader reader = new CsvContactReader();

                return new NonUndoCommandResult(this, Store.Load(reader.Read(strm)));
            }
        }
    }

    internal class SaveCommand : Command
    {
        internal SaveCommand(ContactStore store, IReadOnlyDictionary<string, string> args)
            : base(Commands.Save, args, store)
        {
        }

        public override CommandResult Execute()
        {
            if (!Args.ContainsKey("file"))
            {
                Log.Error(@"Save command requires a 'file' argument with the path to a new or existing CSV file.");
                return null;
            }

            string file = Args["file"];
            using (Stream strm = File.OpenWrite(file))
            {
                CsvContactWriter writer = new CsvContactWriter();
                writer.Write(strm, Store.Contacts);
            }

            return new NonUndoCommandResult(this, new List<Contact>(0));
        }
    }

    internal class NoopCommand : ICommand
    {
        public string Verb => string.Empty;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        public CommandResult Execute()
        {
            return new NonUndoCommandResult(this, new List<Contact>(0));
        }
    }

    internal class DumpCommand : ICommand
    {
        public string Verb => Commands.Dump;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        public CommandResult Execute()
        {
            return new NonUndoCommandResult(this, new List<Contact>(0));
        }
    }

    internal class UndoCommand : ICommand
    {
        public string Verb => Commands.Undo;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        public CommandResult Execute()
        {
            return new NonUndoCommandResult(this, new List<Contact>(0));
        }
    }

    internal class SyntaxErrorCommand : ICommand
    {
        public string Verb => Commands.Error;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        public CommandResult Execute()
        {
            return new NonUndoCommandResult(this, new List<Contact>(0));
        }
    }

    internal class UnknownCommand : ICommand
    {
        public string Verb => Commands.Error;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        private string Command { get; }

        public UnknownCommand(string command)
        {
            this.Command = command;
        }

        public CommandResult Execute()
        {
            Log.Error("Unknown command: {0}", this.Command);
            return new NonUndoCommandResult(this, new List<Contact>(0));
        }
    }


    internal class QuitCommand : ICommand
    {
        public string Verb => Commands.Quit;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        public CommandResult Execute()
        {
            return new NonUndoCommandResult(this, new List<Contact>(0));
        }
    }
}
