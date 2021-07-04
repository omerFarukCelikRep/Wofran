using Core.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seed
{
    public class EducationSeed : CoreMapping<Education>
    {
        public override void Configure(EntityTypeBuilder<Education> builder)
        {
            Education education = new Education
            {
                ID = Guid.NewGuid(),
                City = "Istanbul",
                CreatedDate = DateTime.Now,
                Status = Core.Entity.Enum.Status.Active,
                DegreeType = Entities.Enum.DegreeType.Bachelor,
                DegreeName = "Computer Science",
                CompletionYear = 2019,
                Country = "Turkey",
                JobSeekerID = new Guid("b74ddd14-6340-4840-95c2-db12554843e5"),
                SchoolName = "Istanbul Technical University",
                StartYear = 2012,
                State = "Istanbul"
            };

            builder.HasData(education);
            base.Configure(builder);
        }
    }
}
