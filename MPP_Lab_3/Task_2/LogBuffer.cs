using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Task_2
{
    class LogBuffer
    {
        private List<string> logList = new List<string>();
        private object lockTread = new object();
        private object lockWrite = new object();
        private int listLimit = 40;
        private Timer timer;
        private string path = "File.txt";

        public LogBuffer()
        {
            TimerCallback tm = new TimerCallback(Write);
            timer = new Timer(tm, null, 0, 2000);
        }

        public LogBuffer(string path, int listlimit, int period)
        {
            this.listLimit = listlimit;
            this.path = path;
            TimerCallback tm = new TimerCallback(Write);
            timer = new Timer(tm, null, 0, period);
        }

        public void Add(string item)
        {
            bool isOverflow = false;
            lock (lockTread)
            {
                logList.Add(item);
                isOverflow = logList.Count >= listLimit;
            }

            if (isOverflow)
            {
                Write(null);
            }
        }

        private void Write(object state)
        {
            List<string> buffer;
            lock (lockTread)
            {
                buffer = new List<string>(logList);
                logList.Clear();
            }

            lock (lockWrite)
            {
                File.AppendAllLines(path, buffer);
            }
        }
    }
}
