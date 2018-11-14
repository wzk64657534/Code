
namespace Core
{
    public static class ArrayExtension
    {
        public static string Join(this string[] input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        public static string Join(this short[] input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        public static string Join(this int[] input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        public static string Join(this long[] input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        public static string Join(this decimal[] input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        public static string Join(this double[] input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        public static string Join(this float[] input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        public static string Join<T>(this T[] input, string separator = ",") where T : struct
        {
            return string.Join(separator, input);
        }
    }
}