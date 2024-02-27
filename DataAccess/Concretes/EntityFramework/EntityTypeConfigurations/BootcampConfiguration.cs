using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
    {
        ////id,name,instructor_id,startDate,endDate,bootcampState_id
        public void Configure(EntityTypeBuilder<Bootcamp> builder)
        {
            builder.ToTable("Bootcamp").HasKey(u => u.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
            builder.Property(x => x.InstructorId).IsRequired().HasColumnName("InstructorId");
            builder.Property(x => x.BootcampStateId).IsRequired().HasColumnName("BootcampStateId");
            builder.Property(x => x.StartDate).HasColumnName("StartDate");
            builder.Property(x => x.EndDate).HasColumnName("EndDate");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");


            builder.HasMany(x => x.Applications);
            builder.HasOne(x => x.BootcampState); //one to one
            builder.HasOne(x => x.Instructor); //one to many

        }
    }
}
