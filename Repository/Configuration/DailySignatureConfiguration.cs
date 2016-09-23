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
    /// DailySignature 配置类
    /// </summary>
    class DailySignatureConfiguration:EntityTypeConfiguration<DailySignature>
    {
        public DailySignatureConfiguration()
        {
            ToTable("DailySignature");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.User).WithMany(e=>e.DaliySignatures).Map(e=>e.MapKey("UserId"));
            Property(e =>e.AccumulativeTotal).HasColumnName("AccumulativeTotal").HasColumnType("int").IsRequired();
            Property(e =>e.Year).HasColumnName("Year").HasColumnType("int").IsRequired();
            Property(e =>e.Month).HasColumnName("Month").HasColumnType("int").IsRequired();
            Property(e =>e.Day).HasColumnName("Day").HasColumnType("int").IsRequired();
        }
    }
}
