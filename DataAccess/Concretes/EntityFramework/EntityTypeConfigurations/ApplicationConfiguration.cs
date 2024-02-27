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
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        //id,applicant_id,bootcamp_id,applicationState_id
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Applications").HasKey(u => u.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ApplicantId).IsRequired().HasColumnName("ApplicantId");
            builder.Property(x => x.BootcampId).IsRequired().HasColumnName("BootcampId");
            builder.Property(x => x.ApplicationStateId).IsRequired().HasColumnName("ApplicationStateId");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");


            builder.HasOne(x => x.Bootcamp); //one to many 
            builder.HasOne(x => x.Applicant); //one to many
            builder.HasOne(x => x.ApplicationState); //one to one
        }
    }
}
