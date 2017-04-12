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
    /// Error 配置类
    /// </summary>
    class ErrorConfiguration:EntityTypeConfiguration<Error>
    {
        public ErrorConfiguration()
        {
            ToTable("Sys_Error");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.ErrType).HasColumnName("ErrType").HasColumnType("int").IsRequired();
            Property(e =>e.ErrTime).HasColumnName("ErrTime").HasColumnType("datetime").IsRequired();
            Property(e =>e.BrowersVersion).HasColumnName("BrowersVersion").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.BrowserType).HasColumnName("BrowserType").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.IP).HasColumnName("IP").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.Router).HasColumnName("Router").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.ErrMessage).HasColumnName("ErrMessage").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.ErrSource).HasColumnName("ErrSource").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.StackTrace).HasColumnName("StackTrace").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.Helplink).HasColumnName("Helplink").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
        }
    }
}
