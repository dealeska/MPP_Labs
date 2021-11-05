using System;
using System.Threading;

namespace Task_1
{
    class Parallel
    {
        public delegate void TaskDelegate();

        public static void WaitAll(TaskDelegate[] delegates)
        {           
            foreach (var del in delegates)
            {                
                ThreadPool.QueueUserWorkItem(ThreadProc, del);
            }            
        }

        private static void ThreadProc(Object stateInfo)
        {
            if (stateInfo is TaskDelegate)
            {
                ((TaskDelegate)stateInfo).Invoke();
            }
        }
    }
}