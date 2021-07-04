using Core.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class JobSeekerMapping : CoreMapping<JobSeeker>
    {
        public override void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder.HasKey(a => a.UserID);

            builder.Property(a => a.BirthDate).IsRequired(true);
            builder.Property(a => a.FirstName)
                .IsRequired(true);
            builder.Property(a => a.LastName).IsRequired(true);

            builder.HasMany(a => a.Educations).WithOne(a => a.JobSeeker).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(a => a.AppUser).WithOne(a => a.JobSeeker).HasForeignKey<JobSeeker>(a => a.UserID);

            base.Configure(builder);
        }
    }
}
