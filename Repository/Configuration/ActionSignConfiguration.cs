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
    /// ActionSign 配置类
    /// </summary>
    class ActionSignConfiguration:EntityTypeConfiguration<ActionSign>
    {
        public ActionSignConfiguration()
        {
            ToTable("ActionSign");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.EName).HasColumnName("EName").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.CName).HasColumnName("CName").HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
