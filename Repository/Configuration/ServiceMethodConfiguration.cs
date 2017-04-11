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
    /// ServiceMethod 配置类
    /// </summary>
    class ServiceMethodConfiguration:EntityTypeConfiguration<ServiceMethod>
    {
        public ServiceMethodConfiguration()
        {
            ToTable("Sys_ServiceMethod");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.Service).WithMany(e=>e.Methods).Map(e=>e.MapKey("ServiceId"));
            Property(e =>e.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        }
    }
}
