using System;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.TaskDelegate[] delegates = new Parallel.TaskDelegate[] { 
                DoWork, DoWork, DoWork, DoWork, DoWork, DoWork,
                DoWork, DoWork, DoWork, DoWork, DoWork, DoWork,
                DoWork, DoWork, DoWork, DoWork, DoWork, DoWork
            };

            Parallel.WaitAll(delegates);
            Thread.Sleep(2000);
            Console.ReadLine();
        }

        public static void DoWork()
        {            
            Console.WriteLine("Поток с номером {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(500);
        }
    }
}