using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace App1
{
    class close_app : ICloseApplication
    {
        public void closeApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}
