using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BBS2._0.Common
{
    public enum Sex
    {
        [Description("男")]
        Male,
        [Description("女")]
        Femal,
        [Description("未知")]
        Unknown
    }
}