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
    public class EducationMapping : CoreMapping<Education>
    {
        public override void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.SchoolName).IsRequired(true);
            builder.Property(a => a.StartYear).IsRequired(true);
            builder.Property(a => a.State).IsRequired(true);
            builder.Property(a => a.City).IsRequired(true);
            builder.Property(a => a.CompletionYear).IsRequired(true);
            builder.Property(a => a.Country).IsRequired(true);
            builder.Property(a => a.DegreeName).IsRequired(true);
            builder.Property(a => a.DegreeType).IsRequired(true);

            builder.HasOne(a => a.JobSeeker).WithMany(a => a.Educations).HasForeignKey(a => a.JobSeekerID);


            base.Configure(builder);
        }
    }
}
