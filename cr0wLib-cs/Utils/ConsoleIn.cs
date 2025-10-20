namespace cr0wLib_cs.Utils
{
    public class ConsoleIn
    {
        /// <summary>
        /// Continuously reads an string from the console until a valid integer
        /// can be parsed.
        /// </summary>
        /// <returns></returns>
        public static int ReadFromUser()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
                Console.Error.Write("Invalid input. Please enter a valid number: ");

            return n;
        }

        /// <summary>
        /// Continuously reads an string from the console until a valid integer
        /// can be parsed that is at least <c>min</c>.
        /// </summary>
        /// <param name="min">The minimum integer value that is allowed to be parsed by the user (inclusive)</param>
        /// <returns>An integer that is guaranteed to be at least <c>min</c></returns>
        public static int ReadFromUser(int min)
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) && n < min)
                Console.Error.Write("Invalid input. Please enter a valid number: ");

            return n;
        }

        /// <summary>
        /// Continuously reads an string from the console until a valid integer
        /// is parsed between <c>min</c> and <c>max</c> (exclusive).
        /// </summary>
        /// <param name="min">The minimum integer value that is allowed to be 
        /// parsed by the user (inclusive)</param>
        /// <param name="max">The maximum integer value that is allowed to be
        /// parsed by the user (exclusive)</param>
        /// <returns>An integer that is guaranteed to be at least <c>min</c>
        /// but less than <c>max</c></returns>
        public static int ReadFromUser(int min, int max)
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) && (n < min || n >= max))
                Console.Error.Write("Invalid input. Please enter a valid number: ");

            return n;
        }
    }
}
