using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0
{
    public class DomainException : Exception
    {
        public DomainException(String message) : base(message) { }
    }
}