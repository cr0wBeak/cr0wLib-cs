namespace cr0wLib_cs.Utils
{
    /// <summary>
    /// Reduces slow Console.Write() calls by storing substrings in part of a single buffer string,
    /// then printing the entire buffer to the console.
    /// </summary>
    public class BufferedConsole
    {
        private string buffer;
        
        /// <summary>
        /// Creates a BufferedConsole instance without an initial buffer.
        /// </summary>
        BufferedConsole() { buffer = String.Empty; }

        /// <summary>
        /// Creates a BufferedConsole instance with an initial buffer of <c>from</c>.
        /// </summary>
        /// <param name="from"></param>
        BufferedConsole(string from) { buffer = from; }

        /// <summary>
        /// Outputs the buffer string to the console.
        /// </summary>
        public void Print() { Console.Write(buffer); }

        /// <summary>
        /// Outputs the buffer string to the console and appends a newline afterwards.
        /// </summary>
        public void PrintLine() { Console.WriteLine(buffer); }

        /// <summary>
        /// Adds a string to the buffer.
        /// </summary>
        /// <param name="s">The string to add to the buffer.</param>
        public void Append(string s) { buffer += s; }
    }
}
