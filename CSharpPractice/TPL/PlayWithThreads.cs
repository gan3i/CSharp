using System;
using System.Threading;
using System.Threading.Tasks;


namespace TPL
{

	public class PlayWithThreads
	{

		public PlayWithThreads()
		{

		}

		public void Start()
		{
			Console.WriteLine("In Main Thread");
			ThreadPool.QueueUserWorkItem(CallBack);
			Thread.Sleep(1000);
			ThreadStart threadCall = new ThreadStart(CallToChildThread);
			ThreadStart threadCall2 = new ThreadStart(CallToChildThread2);
			Thread newThread = new Thread(threadCall);
			Thread newThread2 = new Thread(threadCall2);

			//ThreadStart threadCall = new ThreadStart(CallToChildThread);
			//ThreadStart threadCall2 = new ThreadStart(CallToChildThread2);
			using (SemaphoreSlim sm = new SemaphoreSlim(1, 3))
			{
				Parallel.For(0, 20, x =>
				{
					Console.WriteLine("Semaphore wait");
					sm.Wait();
					Thread.Sleep(2000);

					newThread = new Thread(threadCall);
					newThread2 = new Thread(threadCall2);
					newThread.Start();
					newThread2.Start();
					Console.WriteLine(sm.CurrentCount);
					sm.Release();
					Console.WriteLine("Semaphore  Release");

				});
			}






			newThread.Join();

			Thread.Sleep(5000);
			Console.WriteLine("Aborting Thread 1...");
			newThread2.Interrupt();
			Console.WriteLine("finised");
		}


		static void CallBack(object itateInfo)
		{
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine("back ground Thread");
				Thread.Sleep(3000);
			}
		}
		private void CallToChildThread()
		{
			try
			{
				//Console.WriteLine("Child Thread 1 Starting ");
				int sleepTime = 5000;
				//for (int i = 0; i < 6; i++)
				//{
				//	Console.WriteLine("Child Thread 1 running " + i.ToString());
					Thread.Sleep(sleepTime);
				//}
				//Console.WriteLine("Child Thread 1 ended");
				
			}
			catch (ThreadInterruptedException)
			{
				Console.WriteLine("Thread 1 Interrupted Exception");
			}
			//finally{
			//	Console.WriteLine("Thread 1 Couldn't catch the exception..");
			//}
		}

		private void CallToChildThread2()
		{
			try
			{
				//Console.WriteLine("Child Thread 2 Starting");
				int sleepTime = 5000;
				//for (int i = 0; i < 6; i++)
				//{
				//	Console.WriteLine("Child Thread 2 running " + i.ToString());
					Thread.Sleep(sleepTime);
				//}
				//Console.WriteLine("Child Thread 2 ended");
			}
			catch (ThreadInterruptedException)
			{
				Console.WriteLine("Thread 2 Interrupted Exception");
			}
			//finally
			//{
			//	Console.WriteLine("Thread 2 Couldn't catch the exception..");
			//}
		}

	}
}
