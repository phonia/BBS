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
    /// Module 配置类
    /// </summary>
    public class ModuleConfiguration:EntityTypeConfiguration<Module>
    {
        public ModuleConfiguration()
        {
            ToTable("Sys_Module");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.NameCH).HasColumnName("NameCH").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.ModuleCode).HasColumnName("ModuleCode").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            HasOptional(e=>e.Parent).WithMany(e=>e.Children).HasForeignKey(e=>e.ParentId);
        }
    }
}
