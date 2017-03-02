using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class Post:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Keyword { get; set; }
        public DateTime PublicTime { get; set; }
        public byte[] RowVersion { get; set; }
        public Int32 ScanAccount { get; set; }
        public Int32 PosterId { get; set; }
        public Int32 SectionId { get; set; }

        public Account Poster { get; set; }
        public Section Section { get; set; }
        public List<Reply> Replies { get; set; }
    }
}