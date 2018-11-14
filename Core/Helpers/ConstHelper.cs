namespace Core
{
    public sealed class ConstHelper
    {
        /// <summary>
        /// layer框架中子页面关闭父页面中的弹窗并刷新页面。需要layer框架
        /// </summary>
        public const string ScriptCloseWindowAndReload = @"
window.parent.location.reload();
var index = parent.layer.getFrameIndex(window.name);
parent.layer.close(index);
";
        /// <summary>
        /// layer框架中子页面关闭父页面中的弹窗不刷新页面。需要layer框架
        /// </summary>
        public const string ScriptCloseWindowNotReload = @"
var index = parent.layer.getFrameIndex(window.name);
parent.layer.close(index);";

        /// <summary>
        /// 全局配置文件
        /// </summary>
        public const string Config_Xml_File = "cfg_parameters.xml";

        #region 常用正则表达式
        /// <summary>
        /// 通用登录名规则
        /// 只包含数字，26个大小写英文字母，下划线，短划线的组合，4-20位
        /// </summary>
        public const string Regex_LoginName = @"(^[A-Za-z0-9_-]+$){4,20}";
        /// <summary>
        /// 通用密码规则
        /// 必须是数字和字母的组合，6-20位
        /// </summary>
        public const string Regex_Password = @"(^[A-Za-z0-9]+$){6,20}";
        /// <summary>
        /// 邮箱
        /// </summary>
        public const string Regex_Email = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        /// <summary>
        /// 双字节，主要用来兼容中文
        /// </summary>
        public const string Regex_DoubleByte = @"[^\x00-\xff]";
        /// <summary>
        /// 只包含简体中文
        /// </summary>
        public const string Regex_OnlyChinese = @"^[\u4e00-\u9fa5]+$";
        /// <summary>
        /// 只包含数字
        /// </summary>
        public const string Regex_OnlyNumber = @"^[0-9]+$";
        /// <summary>
        /// 只包含26个大小写英文字母
        /// </summary>
        public const string Regex_OnlyLetter = @"^[A-Za-z]+$";
        /// <summary>
        /// 固话
        /// </summary>
        public const string Regex_Tel = @"\d{3}-\d{8}|\d{4}-\d{7}";
        /// <summary>
        /// 只包含数字和26个大小写英文字母
        /// </summary>
        public const string Regex_LetterNumber = @"^[A-Za-z0-9]+$";
        /// <summary>
        /// 小数
        /// </summary>
        public const string Regex_Float = @"^[+-]?([0-9]*\.?[0-9]+|[0-9]+\.?[0-9]*)([eE][+-]?[0-9]+)?$";
        /// <summary>
        /// 手机号码
        /// </summary>
        public const string Regex_Mobile = @"^[1]+[3,4,5,7,8]+\d{9}";
        /// <summary>
        /// QQ号码
        /// </summary>
        public const string Regex_QQ = @"[1-9][0-9]{5,9}";
        /// <summary>
        /// 网址
        /// </summary>
        public const string Regex_Url = @"[a-zA-z]+://[^\s]*";
        /// <summary>
        /// 邮政编码
        /// </summary>
        public const string Regex_ZipCode = @"[1-9]\d{5}(?!\d)";
        /// <summary>
        /// 年份
        /// </summary>
        public const string Regex_Year = @"^((19\d{2})|(2\d{3}))$";
        /// <summary>
        /// 月份
        /// </summary>
        public const string Regex_Month = @"^(0?[[1-9]|1[0-2])$";
        /// <summary>
        /// 只有0
        /// </summary>
        public const string Regex_Zero = @"0";
        /// <summary>
        /// 没有特殊字符
        /// </summary>
        public const string Regex_NonSpecialLetters = @"^[A-Za-z0-9\u4e00-\u9fa5]+$";
        /// <summary>
        /// IP地址
        /// </summary>
        public const string Regex_IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
        #endregion
    }
}