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
    public class JobSeekerSeed : CoreMapping<JobSeeker>
    {
        public override void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            JobSeeker jobSeeker = new JobSeeker
            {
                UserID = new Guid("b74ddd14-6340-4840-95c2-db12554843e5"),
                BirthDate = new DateTime(1990, 1, 1),
                CreatedDate = DateTime.Now,
                FirstName = "Ali",
                LastName = "Veli",
                Status = Core.Entity.Enum.Status.Active
            };

            builder.HasData(jobSeeker);

            base.Configure(builder);
        }
    }
}
