using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace Simple.Models
{
    /// <summary>
    /// 回复
    /// </summary>
    public class Reply:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Content { get; set; }//纯文本信息
        public DateTime ReplyTime { get; set; }
        public Int32 Level { get; set; }

        public User Replayer { get; set; }
        public Post Belong { get; set; }
    }
}