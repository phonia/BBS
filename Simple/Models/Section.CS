using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace Simple.Models
{
    //版块
    public class Section:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String KeyWord { get; set; }
        public String Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}