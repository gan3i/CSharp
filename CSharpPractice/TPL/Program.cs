using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static  async Task Main(string[] args)
        {

            PlayWithThreads pt = new PlayWithThreads();

            pt.Start();

            //PlayWithTasks pTasks = new PlayWithTasks();

            //await pTasks.Start();

            //PlayWithSemaSlim pSlim = new PlayWithSemaSlim();

            //pSlim.Start();

            BitArray bt = new BitArray(8);


            Task<int> obTask = Task.Run(() => DoSomething(1));

            Console.WriteLine(obTask.Result);
        }

        private static List<int> GetValues(int[][] arr)
        {
            return new List<int>();
        }

        private static int DoSomething(int S)
        {
            Console.WriteLine("Hello" + S);
            return 1;
        }
    }
}
