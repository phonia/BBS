using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class JsonMessageDTO
    {
        public bool Success { get; set; }
        public String Message { get; set; }
        public object Data { get; set; }
    }
}