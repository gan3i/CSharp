using System;
using ContactManager;

namespace cm
{
    class Program
    {
        static void Main()
        {
            ContactStore store = new ContactStore();
            Repl repl = new Repl(Console.In, Console.Out, store);

            repl.Run();
        }
    }
}
