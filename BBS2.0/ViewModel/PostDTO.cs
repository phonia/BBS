using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class PostDTO
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Keyword { get; set; }
        public DateTime PublicTime { get; set; }
        public Int32 ScanAccount { get; set; }
        public Int32 ReplyAccount { get; set; }

        public AccountDTO Poster { get; set; }
        public ReplyDTO LastReply { get; set; }
    }
}