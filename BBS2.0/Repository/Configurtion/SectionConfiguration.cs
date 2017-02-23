using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class SectionConfiguration:EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            ToTable("Sys_section");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Description).HasColumnName("Description").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.Title).HasColumnName("Title").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
        }
    }
}