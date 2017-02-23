using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class Reply:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Content { get; set; }
        public DateTime ReplyTime { get; set; }
        public Int32 Level { get; set; }

        public Account Replyer { get; set; }
        public Post Post { get; set; }
    }
}