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
    /// VoteRecord 配置类
    /// </summary>
    class VoteRecordConfiguration:EntityTypeConfiguration<VoteRecord>
    {
        public VoteRecordConfiguration()
        {
            ToTable("VoteRecord");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.VoteItem).WithMany().Map(e=>e.MapKey("VoteItemId"));
            HasRequired(e=>e.Post).WithMany().Map(e=>e.MapKey("PostId"));
            HasRequired(e=>e.User).WithMany().Map(e=>e.MapKey("UserId"));
        }
    }
}
