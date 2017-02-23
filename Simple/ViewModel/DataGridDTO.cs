using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.ViewModel
{
    public class DataGridDTO<T>
    {
        public Int32 total { get; set; }
        public IList<T> rows { get; set; }
    }
}