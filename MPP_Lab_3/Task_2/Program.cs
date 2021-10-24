using System;
using System.Threading;

namespace Task_2
{
    class Program
    {
        public static LogBuffer logBuffer = new LogBuffer();       

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(PrintInfo);
                thread.Name = i.ToString();
                thread.IsBackground = true;
                thread.Start();
            }
            Thread.Sleep(1000);
        }

        public static void PrintInfo()
        {            
            while (Thread.CurrentThread.IsBackground)
            {
                String message = $"Thread {Thread.CurrentThread.Name} write on {DateTime.Now}";
                Console.WriteLine(message);
                logBuffer.Add(message);
                Thread.Sleep(100);
            }
        }
    }    
}
