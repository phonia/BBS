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
    public class WebConfigConfiguration:EntityTypeConfiguration<WebConfig>
    {
        public WebConfigConfiguration()
        {
            ToTable("Sys_WebConfig");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.IsInitialed).HasColumnName("IsInitialed").HasColumnType("bit").IsRequired();
        }
    }
}
