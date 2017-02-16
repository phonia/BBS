using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace Simple.Models
{
    public class WebConfig:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
    }
}