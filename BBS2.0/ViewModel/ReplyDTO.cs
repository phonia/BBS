using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class ReplyDTO
    {
        public Int32 Id { get; set; }
        public String Content { get; set; }
        public DateTime ReplyTime { get; set; }
        public Int32 Level { get; set; }

        public AccountDTO Replyer { get; set; }
    }
}