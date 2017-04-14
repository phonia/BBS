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
    public class ModuleServiceConfiguration:EntityTypeConfiguration<ModuleService>
    {
        public ModuleServiceConfiguration()
        {
            ToTable("Sys_ModuleService");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            HasRequired(e=>e.ModuleOperate).WithMany().HasForeignKey(e=>e.ModuleOperateId);
            HasRequired(e=>e.ServiceMethod).WithMany().HasForeignKey(e=>e.ServiceMethodId);
        }
    }
}
