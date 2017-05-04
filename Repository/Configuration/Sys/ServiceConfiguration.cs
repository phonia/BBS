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
    /// Service 配置类
    /// </summary>
    public class ServiceConfiguration:EntityTypeConfiguration<Service>
    {
        public ServiceConfiguration()
        {
            ToTable("Sys_Service");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.FullName).HasColumnName("FullName").HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            Property(e =>e.Assembly).HasColumnName("Assembly").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        }
    }
}
