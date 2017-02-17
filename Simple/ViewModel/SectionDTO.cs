using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.ViewModel
{
    public class SectionDTO
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String KeyWord { get; set; }
        public String Description { get; set; }
        public Int32 PostsAccount { get; set; }
    }
}