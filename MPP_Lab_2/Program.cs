using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MPP_Lab_2
{
    internal class Program
    {
        public static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; ++i)
            {
                Thread thread = new Thread(getThreadInfo);
                thread.Start();
            }

            Console.ReadLine();
        }

        public static void getThreadInfo()
        {
            mutex.Lock();
            Console.WriteLine($"I {Thread.CurrentThread.ManagedThreadId} thread!");
            mutex.Unlock();
            Thread.Sleep(250);
        }
    }
}
