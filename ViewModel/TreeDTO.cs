using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class TreeDTO
    {
        public Int32 id { get; set; }
        public String text { get; set; }
        public String iconCls { get; set; }
        public String state { get; set; }
        public TreeAttributeDTO attributes { get; set; }
        public List<TreeDTO> children { get; set; }
    }

    public class TreeAttributeDTO
    {
        public String url { get; set; }
    }
}
