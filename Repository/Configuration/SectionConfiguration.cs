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
    /// Section 配置类
    /// </summary>
    class SectionConfiguration:EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            ToTable("Section");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.SectionName).HasColumnName("SectionName").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.SectionSign).HasColumnName("SectionSign").HasColumnType("nvarchar(MAX)").IsOptional();
            Property(e =>e.UserGroupId).HasColumnName("UserGroupId").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.PostAmount).HasColumnName("PostAmount").HasColumnType("int").IsRequired();
            Property(e =>e.ScanAmount).HasColumnName("ScanAmount").HasColumnType("int").IsRequired();
            Property(e =>e.ReplyAmount).HasColumnName("ReplyAmount").HasColumnType("int").IsRequired();
            HasRequired(e=>e.FinalPost).WithMany().Map(e=>e.MapKey("FinalPostId"));
            HasRequired(e=>e.FinalReply).WithMany().Map(e=>e.MapKey("FinalReplyId"));
            Property(e =>e.PostMaster).HasColumnName("PostMaster").HasColumnType("nvarchar(250)").IsOptional();
        }
    }
}
