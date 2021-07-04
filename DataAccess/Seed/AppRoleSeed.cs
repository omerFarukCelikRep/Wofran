using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seed
{
    public class AppRoleSeed : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole() { Id = new Guid("fab4fac1-c546-41de-aebc-a14da6895711"), Name = "Employer", ConcurrencyStamp = "1", NormalizedName = "Employer" },
                new AppRole() { Id = new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), Name = "JobSeeker", ConcurrencyStamp = "2", NormalizedName = "Job Seeker" }
                );
        }
    }
}
