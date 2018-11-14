using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace Core
{
    public sealed class XmlHelper
    {
        /// <summary>
        /// 获取配置内容
        /// </summary>
        /// <param name="xmlfilename">配置文件</param>
        /// <param name="xpath">查询表达式</param>
        public static XmlNodeList GetConfigs(string xmlfilename, string xpath)
        {
            try
            {
                string filePath = HttpContext.Current.Server.MapPath("/App_Resource/Configs/" + xmlfilename);
                XmlDocument xml = new XmlDocument();
                xml.Load(filePath);
                return xml.SelectNodes(xpath);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取配置内容
        /// </summary>
        /// <param name="xmlfilename">配置文件</param>
        /// <param name="xpath">查询表达式</param>
        public static XmlNode GetConfig(string xmlfilename, string xpath)
        {
            XmlNodeList xnl = GetConfigs(xmlfilename, xpath);
            return xnl.Count == 0 ? null : xnl[0];
        }

        /// <summary>
        /// 获取自定义属性的值
        /// 使用此方法一定要确保有type和name属性
        /// 不使用第3个参数时，请确保有value属性
        /// </summary>
        /// <param name="type">type属性值</param>
        /// <param name="name">name属性值</param>
        /// <param name="attributeName">属性名称，默认为value属性</param>
        /// <returns>属性值</returns>
        public static string Get(string type, string name, string attributeName = "value")
        {
            XmlNode config = GetConfig(ConstHelper.Config_Xml_File, string.Format("/configs/config[@type='{1}' and @name='{0}']", name, type));
            return config == null ? string.Empty : config.Attributes[attributeName].Value;
        }

        /// <summary>
        /// 获取自定义属性的值
        /// 使用此方法一定要确保有name属性
        /// </summary>
        /// <param name="name">name属性值</param>
        /// <returns>属性值</returns>
        public static string GetValueByName(string name)
        {
            XmlNode config = GetConfig(ConstHelper.Config_Xml_File, string.Format("/configs/config[@name='{0}']", name));
            return config == null ? string.Empty : config.Attributes["value"].Value;
        }

        /// <summary>
        ///  获取固定name属性和value属性的组合
        ///  使用此方法一定要确保有type，name，value属性
        /// </summary>
        /// <param name="type">type属性值</param>
        /// <returns>返回字典集合</returns>
        public static Dictionary<string, string> GetNameValue(string type)
        {
            XmlNodeList configs = GetConfigs(ConstHelper.Config_Xml_File, string.Format("/configs/config[@type='{0}']", type));
            if (configs.Count == 0) { return null; }

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (XmlNode config in configs)
            {
                string name = config.Attributes["name"].Value;
                string value = config.Attributes["value"].Value;
                dictionary.Add(name, value);
            }

            return dictionary;
        }
    }
}