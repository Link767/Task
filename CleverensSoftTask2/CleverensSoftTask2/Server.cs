using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverensSoftTask2
{
    public static class Server
    {
        private static int count = 0;
        private static ReaderWriterLockSlim lockt = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            lockt.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                lockt.ExitReadLock();
            }
        }
        public static void AddToCount(int value)
        {
            lockt.EnterWriteLock();
            try
            {
                count =+ value;
            }
            finally
            {
                lockt.ExitWriteLock();
            }
        }

    }
}
