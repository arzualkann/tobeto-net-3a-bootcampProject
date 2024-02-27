using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class ApplicationStateConfiguration : IEntityTypeConfiguration<ApplicationState>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationState> builder)
        {
            builder.ToTable("ApplicationStates").HasKey(u => u.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");


            builder.HasOne(x => x.Application); //one to one
        }
    }
}
