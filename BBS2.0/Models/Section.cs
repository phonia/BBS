using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class Section:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

        public IList<Post> Posts { get; set; }
    }
}