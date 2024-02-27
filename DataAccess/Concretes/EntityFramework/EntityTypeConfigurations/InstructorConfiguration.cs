using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(i => i.CompanyName).IsRequired().HasMaxLength(100).HasColumnName("CompanyName");

            builder.HasMany(x => x.Bootcamps); //one to many
        }
    }
}
