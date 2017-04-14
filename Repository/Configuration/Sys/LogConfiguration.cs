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
    /// Log 配置类
    /// </summary>
    public class LogConfiguration:EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            ToTable("Sys_Log");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.ModuleName).HasColumnName("ModuleName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.OperateName).HasColumnName("OperateName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.Result).HasColumnName("Result").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.RecordTime).HasColumnName("RecordTime").HasColumnType("datetime").IsRequired();
            Property(e =>e.Note).HasColumnName("Note").HasColumnType("nvarchar").IsOptional();
            HasRequired(e=>e.User).WithMany(e=>e.Logs).HasForeignKey(e=>e.UserId);
        }
    }
}
