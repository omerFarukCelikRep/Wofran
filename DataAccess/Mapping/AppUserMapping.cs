using Core.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class AppUserMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(a => a.Id);

            //builder.HasIndex(a => a.Email).IsUnique();

            builder.HasOne<Employer>(a => a.Employer).WithOne(a => a.AppUser).HasForeignKey<Employer>(a => a.UserID);
            builder.HasOne<JobSeeker>(a => a.JobSeeker).WithOne(a => a.AppUser).HasForeignKey<JobSeeker>(a => a.UserID);

        }
    }
}
