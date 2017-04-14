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
    public class RolePermissionConfiguration:EntityTypeConfiguration<RolePermission>
    {
        public RolePermissionConfiguration()
        {
            ToTable("Sys_RolePermission");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.PermissionCode).HasColumnName("PermissionCode").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            HasRequired(e=>e.Role).WithMany(e=>e.Permission).HasForeignKey(e=>e.RoleId);
        }
    }
}
