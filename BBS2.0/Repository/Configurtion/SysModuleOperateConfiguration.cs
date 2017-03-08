using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class SysModuleOperateConfiguration:EntityTypeConfiguration<SysModuleOperate>
    {
        public SysModuleOperateConfiguration()
        {
            ToTable("Sys_ModuleOperate");
            HasKey(e => e.Id);
//            Property(e=>e.Id
        }
    }
}