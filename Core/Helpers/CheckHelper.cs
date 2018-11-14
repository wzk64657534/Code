using System;
using System.Text.RegularExpressions;

namespace Core
{
    public sealed class CheckHelper
    {
        /// <summary>
        /// 通用登录名规则
        /// 只包含数字，26个大小写英文字母，下划线，短划线的组合，4-20位
        /// </summary>
        public static bool IsLoginName(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_LoginName);
        }
        /// <summary>
        /// 通用登录名规则
        /// 只包含数字，26个大小写英文字母，下划线，短划线的组合，4-20位
        /// </summary>
        public static bool IsNotLoginName(string input)
        {
            return IsLoginName(input) == false;
        }
        /// <summary>
        /// 通用密码规则
        /// 必须是数字和字母的组合，6-20位
        /// </summary>
        public static bool IsPassword(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Password);
        }
        /// <summary>
        /// 通用密码规则
        /// 必须是数字和字母的组合，6-20位
        /// </summary>
        public static bool IsNotPassword(string input)
        {
            return IsPassword(input) == false;
        }

        public static bool IsIP(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_IP);
        }

        public static bool DateTimeEqual(string input1, string input2)
        {
            return (DateTime.Parse(input1) - DateTime.Parse(input2)).TotalMilliseconds == 0;
        }

        public static bool DateTimeMoreThanRight(string input1, string input2)
        {
            return (DateTime.Parse(input1) - DateTime.Parse(input2)).TotalMilliseconds > 0;
        }

        public static bool DateTimeLessThanRight(string input1, string input2)
        {
            return (DateTime.Parse(input1) - DateTime.Parse(input2)).TotalMilliseconds < 0;
        }

        public static bool IsDateTime(string input)
        {
            DateTime dt = new DateTime();
            return DateTime.TryParse(input, out dt);
        }

        public static bool IsNonSpecialLetters(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_NonSpecialLetters);
        }

        public static bool IsContains(string input, string key)
        {
            return input.Contains(key);
        }

        public static bool IsYear(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Year);
        }

        public static bool IsMonth(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Month);
        }

        public static bool IsZipCode(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_ZipCode);
        }

        public static bool IsUrl(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Url);
        }

        public static bool IsQQ(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_QQ);
        }

        public static bool IsMobile(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Mobile);
        }

        public static bool IsTel(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Tel);
        }

        public static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input.Trim());
        }

        public static bool IsEmail(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Email);
        }

        public static bool LengthMoreMax(string input, int max)
        {
            return Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length > max;
        }

        public static bool LengthEqualMax(string input, int max)
        {
            return Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length == max;
        }

        public static bool LengthIn(string input, int min, int max)
        {
            return Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length > min && Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length < max;
        }

        public static bool LengthInWithEqual(string input, int min, int max)
        {
            return Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length >= min && Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length <= max;
        }

        public static bool LengthLessMin(string input, int min)
        {
            return Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length < min;
        }

        public static bool LengthEqualMin(string input, int min)
        {
            return Regex.Replace(input, ConstHelper.Regex_DoubleByte, "**").Length == min;
        }

        public static bool OnlyLetterAndNumber(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_LetterNumber);
        }

        public static bool OnlyNumber(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_OnlyNumber);
        }

        public static bool OnlyLetter(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_OnlyLetter);
        }

        public static bool OnlyChinese(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_OnlyChinese);
        }

        public static bool IsFloat(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Float);
        }

        public static bool IsZero(string input)
        {
            return Regex.IsMatch(input, ConstHelper.Regex_Zero);
        }
    }
}