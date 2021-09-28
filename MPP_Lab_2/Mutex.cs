using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MPP_Lab_2
{
    internal class Mutex
    {
        private const int unlockedThreadID = 0;
        public int lockedThreadID = 0;
        private int currentThreadID = Thread.CurrentThread.ManagedThreadId;    

        public void Lock()
        {                      
            SpinWait.SpinUntil(() => Interlocked.CompareExchange(ref lockedThreadID, currentThreadID, unlockedThreadID) == currentThreadID );
            Console.WriteLine("Locked");
        }

        public void Unlock()
        {
            if (Interlocked.CompareExchange(ref lockedThreadID, unlockedThreadID, currentThreadID) != currentThreadID)
            {
                return;
            }
            Console.WriteLine("Unlocked");
        }
    }
}
