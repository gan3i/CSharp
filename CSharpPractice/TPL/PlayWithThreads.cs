using System;
using System.Threading;


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
			Thread.Sleep(10000);
			ThreadStart threadCall = new ThreadStart(CallToChildThread);
			ThreadStart threadCall2 = new ThreadStart(CallToChildThread2);
			Thread newThread = new Thread(threadCall);
			Thread newThread2 = new Thread(threadCall2);

			//ThreadStart threadCall = new ThreadStart(CallToChildThread);
			//ThreadStart threadCall2 = new ThreadStart(CallToChildThread2);
			using (SemaphoreSlim sm = new SemaphoreSlim(1, 5))
			{
				for (int i = 0; i < 15; i++)
				{
					//Console.WriteLine("Semaphore wait");
					sm.Wait();
					Thread.Sleep(2000);
					Console.WriteLine(sm.CurrentCount);

					newThread = new Thread(threadCall);
					newThread2 = new Thread(threadCall2);
					newThread.Start();
					newThread2.Start();
					sm.Release();
				}
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
