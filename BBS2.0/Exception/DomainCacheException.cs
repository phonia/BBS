using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0
{
    public class DomainCacheException : DomainException
    {
        public DomainCacheException(String message) : base(message) { }
    }
}