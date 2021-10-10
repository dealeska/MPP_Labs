using System;

namespace MPP_Lab_2
{
    class OSHandle : IDisposable
    {
        public int Handle { get; private set; }
        private Mutex mutex = new Mutex();
        private bool disposed = false;


        public OSHandle(int handle)
        {
            Handle = handle;
        }

        ~OSHandle()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                disposed = true;                
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            mutex.Lock();

            if (!disposed)
            {
                if (Handle != 0)
                {
                    Handle = 0;
                }
                disposed = true;
            }

            mutex.Unlock();
        }        
    }
}