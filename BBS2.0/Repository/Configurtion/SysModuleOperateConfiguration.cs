using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.IsValid).HasColumnName("IsValid").HasColumnType("bit").IsRequired();
            Property(e => e.KeyCode).HasColumnName("KeyCode").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.Name).HasColumnName("Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.OperateCode).HasColumnName("OperateCode").HasColumnType("int").IsRequired();
            Property(e => e.RowVersion).IsRowVersion();
            //Property(e => e.Url).HasColumnName("Url").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            HasRequired(e => e.Module).WithMany(e => e.ModuleOperates).HasForeignKey(e => e.ModuleId);
        }
    }
}