namespace cr0wLib_cs
{
    /// <summary>
    /// The Logger class logs important info, both to the console and to a dedicated file.
    /// </summary>
    /// <param name="minSeverity">The minimum severity to output the log.</param>
    /// <param name="outDir">The directory in which logs will be outputted. Leave null to prevent writing to files.</param>
    /// <param name="name">The name to be used in the Logger</param>
    public class Logger(Logger.LogLevel minSeverity, string? outDir, string name)
    {
        private readonly LogLevel _minSeverity = minSeverity;
        public readonly string? OutDir = outDir;
        public readonly string Name = name;

        /// <summary>
        /// Ordered LogLevels
        /// </summary>
        public enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error,
            Fatal
        }

        private void Log(LogLevel severity, string entry)
        {
            if (severity < _minSeverity)
                return;

            // format current time
            string timestamp = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";
            // build message string
            string message = $"{Name}: {timestamp} - [{severity.ToString().ToUpper()}] {entry}";

            Console.WriteLine(message);

            if (OutDir == null)
                return;

            // write message to file
            string fileName = $"{Name}-logs-{timestamp}.txt";
            File.AppendAllText($"{OutDir}/{fileName}", $"{message}\n");
        }

        public void Debug(string entry) => Log(LogLevel.Debug, entry);
        public void Info(string entry) => Log(LogLevel.Info, entry);
        public void Warn(string entry) => Log(LogLevel.Warning, entry);
        public void Error(string entry) => Log(LogLevel.Error, entry);
        public void Fatal(string entry) => Log(LogLevel.Fatal, entry);
    }
}
