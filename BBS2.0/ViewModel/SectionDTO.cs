using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class SectionDTO
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public Int32 PostsAccount { get; set; }
        public Int32 ReplyAccount { get; set; }
        public Int32 ScanAccount { get; set; }

        public PostDTO LastPost { get; set; }
        //public ReplyDTO LastReply { get; set; }
    }
}