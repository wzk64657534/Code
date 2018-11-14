using System.IO;

namespace Core
{
    public sealed class StreamHelper
    {
        // <summary>
        /// 将 Stream 转成 byte[]
        /// </summary>
        public static byte[] StreamToBytes(Stream stream)
        {
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);

            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            return bytes;
        }

        /// <summary>
        /// 将 byte[] 转成 Stream
        /// </summary>
        public static Stream BytesToStream(byte[] bytes)
        {
            using (Stream stream = new MemoryStream(bytes))
            {
                return stream;
            }
        }

        public static FileStream CreateFile(string path)
        {
            return new FileStream(path, FileMode.Create, FileAccess.Write);
        }

        public static FileStream OpenFile(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }
    }
}