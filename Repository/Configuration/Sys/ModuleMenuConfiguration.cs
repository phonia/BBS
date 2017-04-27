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
    /// ModuleMenu 配置类
    /// </summary>
    public class ModuleMenuConfiguration:EntityTypeConfiguration<ModuleMenu>
    {
        public ModuleMenuConfiguration()
        {
            ToTable("Sys_ModuleMenu");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.MenuName).HasColumnName("MenuName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.MenuCode).HasColumnName("MenuCode").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.IsVisible).HasColumnName("IsVisible").HasColumnType("bit").IsRequired();
            Property(e =>e.IsPage).HasColumnName("IsPage").HasColumnType("bit").IsRequired();
            Property(e =>e.URL).HasColumnName("URL").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.IsEnable).HasColumnName("IsEnable").HasColumnType("bit").IsRequired();
            HasRequired(e=>e.Module).WithMany(e=>e.Menus).HasForeignKey(e=>e.ModuleId);
            HasOptional(e=>e.Parent).WithMany(e=>e.Children).HasForeignKey(e=>e.ParentId);
        }
    }
}
