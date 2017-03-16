using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.Common
{
    public static class Common
    {
        public static String ConvertDecimalToHex(this Int32 x, Int32 length)
        {
            return x.ToString("X" + length);
        }
    }
}