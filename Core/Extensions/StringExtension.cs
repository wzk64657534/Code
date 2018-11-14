using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string input)
        {
            input = input.Remove();
            return string.IsNullOrEmpty(input);
        }

        public static bool IsNotNullOrEmpty(this string input)
        {
            input = input.Remove();
            return !string.IsNullOrEmpty(input);
        }

        public static string DecodeFromBase64(this string input)
        {
            byte[] buffer = Convert.FromBase64String(input);
            return Encoding.Default.GetString(buffer);
        }

        ///<summary>  
        ///取字符的拼音声母   
        ///</summary>    
        ///<param name="input">要转换的汉字</param>  
        ///<returns>拼音声母</returns>    
        public static string GetPinYin(this string input)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                builder.Append(GetPYChar(input.Substring(i, 1)));
            }

            return builder.ToString();
        }

        /// <summary>
        /// 字符串转换为数组
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="separators">分隔符，可以多个以|分隔，默认是英文逗号</param>
        /// <returns>字符串数组</returns>
        public static string[] ToArray(this string input, string separators = ",")
        {
            return input.Trim().Split(separators.Split('|'), StringSplitOptions.RemoveEmptyEntries);
        }

        public static long ToInt64(this string input)
        {
            long x = 0;

            if (long.TryParse(input, out x))
            {
                return x;
            }

            return x;
        }

        public static int ToInt32(this string input)
        {
            int x = 0;

            if (int.TryParse(input, out x))
            {
                return x;
            }

            return x;
        }

        public static short ToInt16(this string input)
        {
            short x = 0;

            if (short.TryParse(input, out x))
            {
                return x;
            }

            return x;
        }

        public static decimal ToDecimal(this string input)
        {
            decimal x = 0;

            if (decimal.TryParse(input, out x))
            {
                return x;
            }

            return x;
        }

        public static double ToDouble(this string input)
        {
            double x = 0;

            if (double.TryParse(input, out x))
            {
                return x;
            }

            return x;
        }

        public static bool ToBoolean(this string input)
        {
            bool x = false;

            if (bool.TryParse(input, out x))
            {
                return x;
            }

            return x;
        }

        public static DateTime ToDateTime(this string input)
        {
            DateTime x = DateTime.MinValue;

            if (DateTime.TryParse(input, out x))
            {
                return x;
            }

            return x;
        }

        /// <summary>
        /// 移除指定的字符，默认是空格
        /// </summary>
        /// <param name="input">要移除字符的字符串</param>
        /// <param name="character">要移除的字符，默认是空格</param>
        /// <returns>移除后的字符串</returns>
        public static string Remove(this string input, string character = " ")
        {
            if (input == null)
            {
                return input;
            }

            return Remove(input, new string[] { character });
        }

        /// <summary>
        /// 移除指定数组的字符，默认是空格
        /// </summary>
        /// <param name="input">要移除字符的字符串</param>
        /// <param name="character">要移除的字符数组</param>
        /// <returns>移除后的字符串</returns>
        public static string Remove(this string input, string[] characters)
        {
            foreach (string character in characters)
            {
                input = input.Replace(character, string.Empty);
            }

            return input;
        }

        public static string ToFormatDate(this string input)
        {
            DateTime time = DateTime.Now;
            if (string.IsNullOrEmpty(input)) { return string.Empty; }
            if (!DateTime.TryParse(input, out time)) { return string.Empty; }
            return time.ToString("yyyy-MM-dd");
        }

        public static string ToFormatDateTime(this string input)
        {
            DateTime time = DateTime.Now;
            if (string.IsNullOrEmpty(input)) { return string.Empty; }
            if (!DateTime.TryParse(input, out time)) { return string.Empty; }
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static bool MoreThanMaxLength(this string input, int max)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length > max;
        }

        public static bool EqualsThanMaxLength(this string input, int max)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length >= max;
        }

        public static bool LessThanMinLength(this string input, int min)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length < min;
        }

        public static bool EqualsThanMinLength(this string input, int min)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length <= min;
        }

        public static bool BetweenLength(this string input, int min, int max)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length >= min && after.Length <= max;
        }

        public static bool NotBetweenLength(this string input, int min, int max)
        {
            return !BetweenLength(input, min, max);
        }

        public static bool BetweenMinLength(this string input, int min, int max)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length >= min && after.Length < max;
        }

        public static bool BetweenMaxLength(this string input, int min, int max)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length > min && after.Length <= max;
        }

        public static bool BetweenWithoutLength(this string input, int min, int max)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(ConstHelper.Regex_DoubleByte);
            string after = regex.Replace(input, "**");
            return after.Length > min && after.Length < max;
        }

        public static string MD5(this string input)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] result = md5.ComputeHash(buffer);
            StringBuilder builder = new StringBuilder();
            foreach (byte item in result)
            {
                // 加密结果"x2"结果为32位, "x3"结果为48位, "x4"结果为64位
                builder.Append(item.ToString("x2"));
            }

            return builder.ToString();
        }

        private static string DesKey = "eD2uI1bK";
        private static string AesKey = "uGeE1uB1eR1dH1bH5wC2vC3hD2nM6b11";

        /// <summary>
        /// DES加密算法
        /// key为8位
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns></returns>
        public static string DesEncrypt(this string input)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(input);
                des.Key = Encoding.Default.GetBytes(DesKey);
                des.IV = Encoding.Default.GetBytes(DesKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                StringBuilder builder = new StringBuilder();

                foreach (byte b in ms.ToArray())
                {
                    builder.AppendFormat("{0:X2}", b);
                }

                return builder.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// DES解密算法
        /// key为8位
        /// </summary>
        /// <param name="input">需要解密的字符串</param>
        /// <returns></returns>
        public static string DesDecrypt(this string input)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[input.Length / 2];
                for (int x = 0; x < input.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(input.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = Encoding.Default.GetBytes(DesKey);
                des.IV = Encoding.Default.GetBytes(DesKey);

                MemoryStream ms = new MemoryStream();

                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="key">aes密钥，长度必须32位</param>
        /// <returns>加密后的字符串</returns>
        public static string AesEncrypt(this string input)
        {
            try
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.Key = Encoding.UTF8.GetBytes(AesKey);
                    aesProvider.Mode = CipherMode.ECB;
                    aesProvider.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor())
                    {
                        byte[] inputBuffers = Encoding.UTF8.GetBytes(input);
                        byte[] results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                        aesProvider.Clear();
                        aesProvider.Dispose();
                        return Convert.ToBase64String(results, 0, results.Length);
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="key">aes密钥，长度必须32位</param>
        /// <returns>解密后的字符串</returns>
        public static string AesDecrypt(this string input)
        {
            try
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.Key = Encoding.UTF8.GetBytes(AesKey);
                    aesProvider.Mode = CipherMode.ECB;
                    aesProvider.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor())
                    {
                        byte[] inputBuffers = Convert.FromBase64String(input);
                        byte[] results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                        aesProvider.Clear();
                        return Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        ///<summary>  
        ///取单个字符的拼音声母   
        ///</summary>    
        ///<param name="input">要转换的单个汉字</param>  
        ///<returns>拼音声母</returns>    
        private static string GetPYChar(string input)
        {
            byte[] buffer = System.Text.Encoding.Default.GetBytes(input);

            int i = (int)(buffer[0] - '\0') * 256;

            if (i < 0xB0C5) return "A";
            if (i < 0xB2C1) return "B";
            if (i < 0xB4EE) return "C";
            if (i < 0xB6EA) return "D";
            if (i < 0xB7A2) return "E";
            if (i < 0xB8C1) return "F";
            if (i < 0xB9FE) return "G";
            if (i < 0xBBF7) return "H";
            if (i < 0xBFA6) return "J";
            if (i < 0xC0AC) return "K";
            if (i < 0xC2E8) return "L";
            if (i < 0xC4C3) return "M";
            if (i < 0xC5B6) return "N";
            if (i < 0xC5BE) return "O";
            if (i < 0xC6DA) return "P";
            if (i < 0xC8BB) return "Q";
            if (i < 0xC8F6) return "R";
            if (i < 0xCBFA) return "S";
            if (i < 0xCDDA) return "T";
            if (i < 0xCEF4) return "W";
            if (i < 0xD1B9) return "X";
            if (i < 0xD4D1) return "Y";
            if (i < 0xD7FA) return "Z";

            return input;
        }
    }
}