using System.IO;
using System.Web;

namespace Core
{
    public sealed class FileHelper
    {
        private static object o = new object();

        public static void Create(string directory, string filename, string content)
        {
            string localdirectory = HttpContext.Current.Server.MapPath(string.Format("/{0}", directory));
            if (!Directory.Exists(localdirectory))
            {
                Directory.CreateDirectory(localdirectory);
            }

            string fullpath = localdirectory + filename;

            using (FileStream fs = new FileStream(fullpath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public static void Append(string directory, string filename, string content)
        {
            string localdirectory = HttpContext.Current.Server.MapPath(string.Format("/{0}", directory));
            if (!Directory.Exists(localdirectory))
            {
                Directory.CreateDirectory(localdirectory);
            }

            string fullpath = localdirectory + filename;

            using (FileStream fs = new FileStream(fullpath, FileMode.Append, FileAccess.Write))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length);
            }
        }
    }
}