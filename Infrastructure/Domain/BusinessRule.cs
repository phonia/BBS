using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class BusinessRule
    {
        [Description("属性")]
        public String Property { get; set; }
        [Description("约束")]
        public String Rule { get; set; }
    }
}
