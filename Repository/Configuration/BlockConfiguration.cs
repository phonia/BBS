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
    /// Block 配置类
    /// </summary>
    class BlockConfiguration:EntityTypeConfiguration<Block>
    {
        public BlockConfiguration()
        {
            ToTable("Block");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.BlockName).HasColumnName("BlockName").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Sort).HasColumnName("Sort").HasColumnType("int").IsRequired();
        }
    }
}
