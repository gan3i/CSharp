using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    public class PlayWithTasks
    {

        public async Task  Start()
        {
            Task taskOne=Task.Run(() =>
            { 
                Console.WriteLine("Task 1 started");
                Thread.Sleep(3000);
                Console.WriteLine("Task 1 ended");

            });

            Task taskTwo = taskOne.ContinueWith(t => {
                Console.WriteLine(t.Status);
                Console.WriteLine("Task 2 started");
                Thread.Sleep(3000);
                Console.WriteLine("Task 2 ended");
            });
            await taskTwo;
        }
        private async Task CallBackTask()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Task 1 started");
                Thread.Sleep(3000);
                Console.WriteLine("Task 1 ended");

            });
        }

    }

}
