using System;

namespace Core
{
    public static class GuidExtension
    {
        public static long ToInt64(this Guid input)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}