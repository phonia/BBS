using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace Simple.Models
{
    public interface ISectionRepository:IRepository<Section,Int32>
    {
    }
}