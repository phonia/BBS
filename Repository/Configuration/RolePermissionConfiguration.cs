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
    /// RolePermission 配置类
    /// </summary>
    class RolePermissionConfiguration:EntityTypeConfiguration<RolePermission>
    {
        public RolePermissionConfiguration()
        {
            ToTable("Sys_RolePermission");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.PermissionCode).HasColumnName("PermissionCode").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            HasRequired(e=>e.Role).WithMany(e=>e.Permission).Map(e=>e.MapKey("RoleId"));
        }
    }
}
