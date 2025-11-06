using System.Diagnostics;

namespace cr0wLib_cs.Utils
{
    public static class Meta
    {
        /// <summary>
        /// Executes an Action a set number of times and tracks the time taken to do so.
        /// </summary>
        /// <param name="f">The Action to perform and track.</param>
        /// <param name="repetitions">The number of times to perform <c>f</c>.</param>
        /// <returns>The time elapsed between the beginning of the first execution
        /// of <c>f()</c> and the final execution of <c>f()</c>.</returns>
        public static TimeSpan TrackTime(Action f, int repetitions)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < repetitions; ++i)
                f(); // execute f()
            
            stopwatch.Stop();
            // return total time to execute f() repetitions times
            return stopwatch.Elapsed;
        }
    }
}
