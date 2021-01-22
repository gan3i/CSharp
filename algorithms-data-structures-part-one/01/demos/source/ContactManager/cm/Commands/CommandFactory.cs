using System.Collections.Generic;
using ContactManager;

namespace cm
{
    internal class CommandFactory
    {
        readonly ContactStore store;

        public CommandFactory(ContactStore store)
        {
            this.store = store;
        }

        public ICommand Add(IReadOnlyDictionary<string, string> args)
        {
            return new AddCommand(store, args);
        }

        public ICommand Remove(IReadOnlyDictionary<string, string> args)
        {
            return new RemoveCommand(store, args);
        }

        public ICommand Find(IReadOnlyDictionary<string, string> args)
        {
            return new FindCommand(store, args);
        }

        public ICommand Quit()
        {
            return new QuitCommand();
        }

        public ICommand SyntaxError()
        {
            return new SyntaxErrorCommand();
        }

        public ICommand UnknownCommand(string command)
        {
            return new UnknownCommand(command);
        }


        public ICommand List(IReadOnlyDictionary<string, string> args)
        {
            return new ListCommand(store, args);
        }

        public ICommand Save(IReadOnlyDictionary<string, string> args)
        {
            return new SaveCommand(store, args);
        }

        public ICommand Load(IReadOnlyDictionary<string, string> args)
        {
            return new LoadCommand(store, args);
        }

        public ICommand Dump(IReadOnlyDictionary<string,string> args)
        {
            return new DumpCommand();
        }

        public ICommand Undo(IReadOnlyDictionary<string,string> args)
        {
            return new UndoCommand();
        }

    }
}
