using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0
{
    public class DomainRepositoryException:DomainException
    {
        public DomainRepositoryException(String message) : base(message) { }
    }
}