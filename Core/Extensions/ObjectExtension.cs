using Newtonsoft.Json;

namespace Core
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 将对话转化成Json格式的字符串
        /// </summary>
        /// <param name="o">要转化的对象</param>
        /// <returns>对象的Json格式字符串</returns>
        public static string ToJson(this object o)
        {
            return o == null ? "NULL" : JsonConvert.SerializeObject(o);
        }

        /// <summary>
        /// 对象是否为Null
        /// </summary>
        /// <param name="o">要转化的对象</param>
        public static bool IsNull(this object o)
        {
            return o == null;
        }

        /// <summary>
        /// 对象是否为Null
        /// </summary>
        /// <param name="o">要转化的对象</param>
        public static bool IsNotNull(this object o)
        {
            return o != null;
        }
    }
}