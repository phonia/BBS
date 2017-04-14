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
    /// ModuleOperate 配置类
    /// </summary>
    public class ModuleOperateConfiguration:EntityTypeConfiguration<ModuleOperate>
    {
        public ModuleOperateConfiguration()
        {
            ToTable("Sys_ModuleOperate");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.OperateName).HasColumnName("OperateName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.OperateCode).HasColumnName("OperateCode").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.PermissionCode).HasColumnName("PermissionCode").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            HasRequired(e=>e.Module).WithMany(e=>e.Operates).HasForeignKey(e=>e.ModuleId);
            Property(e =>e.IsEnable).HasColumnName("IsEnable").HasColumnType("bit").IsRequired();
        }
    }
}
