using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ballance2.Utils
{
    /// <summary>
    /// 字符串转换类
    /// </summary>
    public static class StringConverter
    {
        /// <summary>
        /// 字符串转为布尔型
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool StrToBool(string s)
        {
            if (s == "false" || s == "0" || s == "False" || s == "FALSE")
                return false;
            else if (s=="true" || s== "1" || s == "True" || s == "TRUE")
                return true;
            return false;
        }
        /// <summary>
        /// 字符串转为指定的枚举类
        /// </summary>
        /// <typeparam name="T">枚举类</typeparam>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static T StrToEnum<T>(string s)
        {
            return (T)System.Enum.Parse(typeof(T), s);
        }
        /// <summary>
        /// 字符串转为Int
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static int StrToInt(string s,int defaultValue = 0)
        {
            int rs = defaultValue;
            int.TryParse(s, out rs);
            return rs;
        }
        /// <summary>
        /// 字符串转为 Double
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static double StrToDouble(string s, double defaultValue = 0)
        {
            double rs = defaultValue;
            double.TryParse(s, out rs);
            return rs;
        }
        /// <summary>
        /// 字符串转为 Float
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static float StrToFloat(string s, float defaultValue = 0)
        {
            float rs = defaultValue;
            float.TryParse(s, out rs);
            return rs;
        }
        /// <summary>
        /// 字符串转为 Vector3
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static Vector3 StrToVector3(string s, Vector3 defaultValue = default(Vector3))
        {
            Vector3 rs = defaultValue;
            if (s.StartsWith("(") && s.EndsWith(")"))
                s = s.Substring(0, s.Length - 2);
            if(s.Contains(","))
            {
                string[] ss = s.Split(',');
                if (ss.Length >= 3)
                {
                    rs.x = StrToFloat(ss[0]);
                    rs.y = StrToFloat(ss[1]);
                    rs.z = StrToFloat(ss[2]);
                }
            }
            return rs;
        }
        /// <summary>
        /// 字符串转为 Vector2
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static Vector2 StrToVector2(string s, Vector2 defaultValue = default(Vector2))
        {
            Vector2 rs = defaultValue;
            if (s.StartsWith("(") && s.EndsWith(")"))
                s = s.Substring(0, s.Length - 2);
            if (s.Contains(","))
            {
                string[] ss = s.Split(',');
                if (ss.Length >= 2)
                {
                    rs.x = StrToFloat(ss[0]);
                    rs.y = StrToFloat(ss[1]);
                }
            }
            return rs;
        }
    }
}
