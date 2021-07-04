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
    public class EmployerMapping : CoreMapping<Employer>
    {
        public override void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(a => a.UserID);

            builder.HasOne(a => a.AppUser).WithOne(a => a.Employer).HasForeignKey<Employer>(a => a.UserID);
            base.Configure(builder);
        }
    }
}
