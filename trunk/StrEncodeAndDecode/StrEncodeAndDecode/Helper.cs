using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrEncodeAndDecode
{
    using RuanYun.Utility.Helper;

    public static class Helper
    {
        /// <summary>
        /// url解密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string UrlDecode(this string source)
        {
            return CryptogramHelper.Decrypt3DES(UrlHelper.UrlDecode(source).Replace(" ", "+"));
        }

        /// <summary>
        /// 将参数解密并转成对应的数据类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T UrlDecode<T>(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return default(T);
            }
            var decodeStr = CryptogramHelper.Decrypt3DES(UrlHelper.UrlDecode(source).Replace(" ", "+"));
            if (string.IsNullOrEmpty(decodeStr))
            {
                return default(T);
            }
            try
            {
                return (T)Convert.ChangeType(decodeStr, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// url加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string UrlEncode(this string source)
        {
            return UrlHelper.UrlEncode(CryptogramHelper.Encrypt3DES(source));
        }
    }
}
