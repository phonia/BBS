/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Model;

namespace Repository
{
    /// <summary>
    /// ModuleService 配置类
    /// </summary>
    class ModuleServiceConfiguration:EntityTypeConfiguration<ModuleService>
    {
        public ModuleServiceConfiguration()
        {
            ToTable("Sys_ModuleService");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.ModuleOperate).WithMany().Map(e=>e.MapKey("ModuleOperateId"));
            HasRequired(e=>e.ServiceMethod).WithMany().Map(e=>e.MapKey("ServiceMethodId"));
        }
    }
}
