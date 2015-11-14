using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWinFormsTcpApp
{
    /// <summary>
    /// Class to measure the runtime
    /// </summary>
    public class TimeMeasure
    {
        private DateTime localDateTime1;

        private int iRunTime;
        public int IRunTime
        {
            get
            {
                TimeSpan run = DateTime.Now - localDateTime1;
                iRunTime = run.Minutes * 60 * 1000 + run.Seconds * 1000 + run.Milliseconds;
                return iRunTime;
            }
        }
        private String strRunTime;
        public String StrRunTime
        {
            get
            {
                strRunTime = IRunTime.ToString();
                return strRunTime;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TimeMeasure()
        {
            localDateTime1 = DateTime.Now;
        }
    }
}
