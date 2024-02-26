using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class BlackListConfigurations : IEntityTypeConfiguration<BlackList>
{
    public void Configure(EntityTypeBuilder<BlackList> builder)
    {
        builder.ToTable("BlackList").HasKey(u=>u.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Reason).IsRequired().HasColumnName("Reason");
        builder.Property(x => x.Date).HasColumnName("Date");
        builder.Property(x => x.Applicant_id).IsRequired().HasColumnName("Applicant_id");

        builder.HasOne(x => x.Applicant);
    }

}