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
    /// WebConfig 配置类
    /// </summary>
    class WebConfigConfiguration:EntityTypeConfiguration<WebConfig>
    {
        public WebConfigConfiguration()
        {
            ToTable("WebConfig");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.WebName).HasColumnName("WebName").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.WebDomain).HasColumnName("WebDomain").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.LoginLogReserveTime).HasColumnName("LoginLogReserveTime").HasColumnType("int").IsRequired();
            Property(e =>e.UseLogReserveTime).HasColumnName("UseLogReserveTime").HasColumnType("int").IsRequired();
        }
    }
}
