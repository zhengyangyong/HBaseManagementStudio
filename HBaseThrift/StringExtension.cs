using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBaseThrift
{
    public static class StringExtension
    {
        public static byte[] GetBytes(this string str)
        {
            return Encoding.Default.GetBytes(str);
        }

        public static byte[] GetUTF8Bytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        //public static byte[] GetUnicodeBytes(this string str)
        //{
        //    return Encoding.Unicode.GetBytes(str);
        //}
    }
}
