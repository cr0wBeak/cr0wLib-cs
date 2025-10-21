using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cr0wLib_cs.Utils
{
    public static class Meta
    {
        public static TimeSpan TrackTime(Action f, int repetitions)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < repetitions; ++i)
                f();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
