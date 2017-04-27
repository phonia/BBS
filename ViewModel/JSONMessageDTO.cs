using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class JSONMessageDTO
    {
        public bool Success { get; set; }
        public String Message { get; set; }
        public object Data { get; set; }
    }
}
