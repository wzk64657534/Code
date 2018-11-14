using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RandomHelper
    {
        private static Random random;

        public static string Generator(int length = 4)
        {
            if (length > 8)
            {
                length = 8;
            }

            int min = "1".PadRight(length, '0').ToInt32();
            int max = "1".PadRight(length + 1, '0').ToInt32();

            Create();

            return random.Next(min, max).ToString();
        }

        private static Random Create()
        {
            if (random == null)
            {
                random = new Random();
            }

            return random;
        }
    }
}