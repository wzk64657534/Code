using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Core
{
    /// <summary>
    /// 日志记录辅助类
    /// </summary>
    public sealed class LogHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("WebLogger");

        /// <summary>
        /// 读取web.config中的log4net配置
        /// </summary>
        private static void SetConfig()
        {
            object o = ConfigurationManager.GetSection("log4net");
            log4net.Config.XmlConfigurator.Configure(o as System.Xml.XmlElement);
        }

        /// <summary>
        /// 日志是否启动
        /// </summary>
        /// <returns></returns>
        private static bool Started()
        {
            try
            {
                return Convert.ToBoolean(XmlHelper.Get("log", "status"));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            if (Started())
            {
                if (!log.IsInfoEnabled)
                {
                    SetConfig();
                }

                log.Info(message);
            }
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string[] messages)
        {
            if (Started())
            {
                if (!log.IsInfoEnabled)
                {
                    SetConfig();
                }

                if (messages.Length > 0)
                {
                    foreach (string message in messages)
                    {
                        log.Info(message);
                    }
                }
            }
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="o">数据对象</param>
        public static void Info(object o)
        {
            if (Started())
            {
                if (!log.IsInfoEnabled)
                {
                    SetConfig();
                }

                if (o != null)
                {
                    string json = o == null ? "null" : JsonConvert.SerializeObject(o);
                    log.Info(json);
                }
            }
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="o">数据对象</param>
        public static void Info(string title, object o)
        {
            if (Started())
            {
                if (!log.IsInfoEnabled)
                {
                    SetConfig();
                }

                if (o != null)
                {
                    string json = o == null ? "null" : JsonConvert.SerializeObject(o);
                    log.Info(string.Format("{0}: {1}", title, json));
                }
            }
        }

        /// <summary>
        /// 登录错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex)
        {
            if (Started())
            {
                if (!log.IsErrorEnabled)
                {
                    SetConfig();
                }

                log.Error(message, ex);
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            if (Started())
            {
                if (!log.IsErrorEnabled)
                {
                    SetConfig();
                }

                log.Error(message);
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="messages"></param>
        public static void Error(string[] messages)
        {
            if (Started())
            {
                if (!log.IsErrorEnabled)
                {
                    SetConfig();
                }

                if (messages.Length > 0)
                {
                    foreach (string message in messages)
                    {
                        log.Error(message);
                    }
                }
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="o">错误信息对象</param>
        public static void Error(object o)
        {
            if (Started())
            {
                if (!log.IsErrorEnabled)
                {
                    SetConfig();
                }

                if (o != null)
                {
                    log.Error(JsonConvert.SerializeObject(o));
                }
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="o">错误信息对象</param>
        public static void Error(string title, object o)
        {
            if (Started())
            {
                if (!log.IsErrorEnabled)
                {
                    SetConfig();
                }

                if (o != null)
                {
                    string json = o == null ? "null" : JsonConvert.SerializeObject(o);
                    log.Error(string.Format("{0}: {1}", title, json));
                }
            }
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="loggers"></param>
        public static void Error(List<LogEntity> loggers)
        {
            if (Started())
            {
                if (!log.IsErrorEnabled)
                {
                    SetConfig();
                }

                if (loggers.Count > 0)
                {
                    foreach (LogEntity logger in loggers)
                    {
                        log.Error(logger.Message, logger.Exception);
                    }
                }
            }
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="logger"></param>
        public static void Error(LogEntity logger)
        {
            if (logger == null)
            {
                return;
            }

            if (Started())
            {
                if (!log.IsErrorEnabled)
                {
                    SetConfig();
                }

                log.Error(logger.Message, logger.Exception);
            }
        }
    }

    /// <summary>
    /// 日志类
    /// </summary>
    public class LogEntity
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 异常类
        /// </summary>
        public Exception Exception { get; set; }
    }
}