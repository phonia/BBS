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
    /// VoteItem 配置类
    /// </summary>
    class VoteItemConfiguration:EntityTypeConfiguration<VoteItem>
    {
        public VoteItemConfiguration()
        {
            ToTable("VoteItem");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.Sort).HasColumnName("Sort").HasColumnType("int").IsRequired();
            HasRequired(e=>e.Post).WithMany().Map(e=>e.MapKey("PostId"));
        }
    }
}
