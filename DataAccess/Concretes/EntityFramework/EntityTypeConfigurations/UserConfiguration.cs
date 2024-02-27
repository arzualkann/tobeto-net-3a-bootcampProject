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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50).HasColumnName("Username");
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50).HasColumnName("Name");
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50).HasColumnName("Lastname");
            builder.Property(u => u.DateOfBirth).IsRequired().HasColumnName("DatoOfBirth");
            builder.Property(u => u.NationalIdentity).IsRequired().HasMaxLength(11).HasColumnName("NationalIdentity");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100).HasColumnName("Email");
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100).HasColumnName("Password");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
        }
    }
}
