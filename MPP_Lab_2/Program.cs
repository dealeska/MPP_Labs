using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace MPP_Lab_2
{
    internal class Program
    {
        public static Mutex mutex = new Mutex();
        /*public static void Main(string[] args)
        {
            for (int i = 0; i < 10; ++i)
            {
                Thread thread = new Thread(getThreadInfo);
                thread.Start();
            }

            Console.ReadLine();
        }*/

        public static void Main(string[] args)
        {
            Process notePad = new Process();
            notePad.StartInfo.FileName = "notepad.exe";            
            notePad.Start();

            OSHandle handle = new OSHandle((int)notePad.Handle);
            handle.Dispose();

            Console.ReadLine();
            notePad.Kill();
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
