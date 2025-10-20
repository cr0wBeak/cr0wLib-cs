using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cr0wLib_cs.Utils
{
    public class Math
    {
        /// <summary>
        /// Uses Stein's Algorithm to determine the Greatest Common Divisor.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>An integer <c>n</c> such that <c>a/n == b/n</c></returns>
        public static int GCD(int a, int b)
        {
            // You can read about Stein's Algorithm at: https://www.geeksforgeeks.org/dsa/steins-algorithm-for-finding-gcd/

            if (a == 0)
                return b;
            if (b == 0)
                return a;

            // find greatest power of 2 that divides both a and b
            int greatestPowerOf2;
            for (greatestPowerOf2 = 0; ((a | b) & 1) == 0; ++greatestPowerOf2)
            {
                a >>= 1;
                b >>= 1;
            }

            // Dividing a by 2 until a becomes odd
            while ((a & 1) == 0)
                a >>= 1;

            // From here on, 'a' is always odd
            do
            {
                // If b is even, remove
                // all factor of 2 in b
                while ((b & 1) == 0)
                    b >>= 1;

                // now both nums are odd
                // swap if necessary
                if (a > b)
                    (a, b) = (b, a);

                b = (b - a);
            } while (b != 0);

            // restore common factors of 2
            return a << greatestPowerOf2;
        }
    }
}
