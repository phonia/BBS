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
    /// Navagation 配置类
    /// </summary>
    class NavagationConfiguration:EntityTypeConfiguration<Navagation>
    {
        public NavagationConfiguration()
        {
            ToTable("Navagation");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Level).HasColumnName("Level").HasColumnType("int").IsRequired();
            Property(e =>e.IsMenu).HasColumnName("IsMenu").HasColumnType("bit").IsRequired();
            Property(e =>e.IsPage).HasColumnName("IsPage").HasColumnType("bit").IsRequired();
            Property(e =>e.IsDisplay).HasColumnName("IsDisplay").HasColumnType("bit").IsRequired();
            HasRequired(e=>e.Parent).WithMany(e=>e.Children).Map(e=>e.MapKey("ParentId"));
        }
    }
}
