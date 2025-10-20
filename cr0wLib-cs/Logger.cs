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
        private readonly LogLevel _minimumSeverity = minSeverity;
        public readonly string? OutputDirectory = outDir;
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

        /// <summary>
        /// Logs the provided string to the console if the severity is at least
        /// the Logger's minSeverity, then writes the Log message to a text file
        /// if the output directory is not null.
        /// </summary>
        /// <param name="severity">The severity of the log entry</param>
        /// <param name="entry">The string to be logged</param>
        private void Log(LogLevel severity, string entry)
        {
            if (severity < _minimumSeverity)
                return;

            // format current time
            string timestamp = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";
            // build message string
            string message = $"{Name}: {timestamp} - [{severity.ToString().ToUpper()}] {entry}";

            Console.WriteLine(message);

            if (OutputDirectory == null)
                return;

            // write message to file
            string fileName = $"{Name}-logs-{timestamp}.txt";
            File.AppendAllText($"{OutputDirectory}/{fileName}", $"{message}\n");
        }

        /// <summary>
        /// Logs the provided string to the console if the Logger's minimum
        /// severity is at least Debug level, then writes the Log message
        /// to a text file if this.OutputDirectory is not null.
        /// </summary>
        /// <param name="entry">The string to be logged</param>
        public void Debug(string entry) => Log(LogLevel.Debug, entry);

        /// <summary>
        /// Logs the provided string to the console if the Logger's minimum
        /// severity is at least Info level, then writes the Log message
        /// to a text file if this.OutputDirectory is not null.
        /// </summary>
        /// <param name="entry">The string to be logged</param>
        public void Info(string entry) => Log(LogLevel.Info, entry);

        /// <summary>
        /// Logs the provided string to the console if the Logger's minimum
        /// severity is at least Warning level, then writes the Log message
        /// to a text file if this.OutputDirectory is not null.
        /// </summary>
        /// <param name="entry">The string to be logged</param>
        public void Warn(string entry) => Log(LogLevel.Warning, entry);

        /// <summary>
        /// Logs the provided string to the console if the Logger's minimum
        /// severity is at least Error level, then writes the Log message
        /// to a text file if this.OutputDirectory is not null.
        /// </summary>
        /// <param name="entry">The string to be logged</param>
        public void Error(string entry) => Log(LogLevel.Error, entry);

        /// <summary>
        /// Logs the provided string to the console if the Logger's minimum
        /// severity is at least Fatal level, then writes the Log message
        /// to a text file if this.OutputDirectory is not null.
        /// </summary>
        /// <param name="entry">The string to be logged</param>
        public void Fatal(string entry) => Log(LogLevel.Fatal, entry);
    }
}
