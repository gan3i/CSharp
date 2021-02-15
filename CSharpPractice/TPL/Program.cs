using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ASCII = System.Text.Encoding;

namespace TPL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int a = Convert.ToInt32(null);
            int b = Convert.ToInt32((string)null);
            int c = 0;

            string s = "508";

            int i = Convert.ToInt32(s);

            byte[] x =  Encoding.ASCII.GetBytes("AB");
            byte[] utf =  Encoding.UTF8.GetBytes("AB");

            string y = Encoding.ASCII.GetString(x);

            char[] z = Encoding.ASCII.GetChars(x);

            //char chr =(char) "A";
            char chr = 'A';

            //int val = (int)"A";
            int val = (int)'A';


            GC.Collect();


            //PlayWithThreads pt = new PlayWithThreads();

            //pt.Start();

            //PlayWithTasks pTasks = new PlayWithTasks();

            //await pTasks.Start();

            PlayWithSemaSlim pSlim = new PlayWithSemaSlim();

            pSlim.Start();


            BitArray bt = new BitArray(8);



            Task<int> obTask = Task.Run(() => DoSomething(1));

            //Console.WriteLine(obTask.result);
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
