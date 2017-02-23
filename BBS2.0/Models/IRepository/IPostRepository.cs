using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public interface IPostRepository:IRepository<Post,Int32>
    {
    }
}