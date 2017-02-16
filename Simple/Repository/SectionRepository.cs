using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Simple.Models;

namespace Simple.Repository
{
    public class SectionRepository:EFRepository<Section,Int32>,ISectionRepository
    {
    }
}