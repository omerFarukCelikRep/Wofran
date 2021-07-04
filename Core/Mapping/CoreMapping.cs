using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class CoreMapping<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatedDate)
                .IsRequired(true);
            builder.Property(e => e.ModifiedDate)
                .IsRequired(false);
            builder.Property(e => e.Status)
                .IsRequired(true);
        }
    }
}
