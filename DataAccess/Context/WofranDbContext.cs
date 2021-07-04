using Core.Entity.Abstract;
using DataAccess.Mapping;
using DataAccess.Seed;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class WofranDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public WofranDbContext(DbContextOptions<WofranDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EducationMapping());
            builder.ApplyConfiguration(new JobSeekerMapping());
            builder.ApplyConfiguration(new EmployerMapping());
            builder.ApplyConfiguration(new AppRoleSeed());
            builder.ApplyConfiguration(new AppUserSeed());
            builder.ApplyConfiguration(new JobSeekerSeed());
            builder.ApplyConfiguration(new EducationSeed());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            //var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();


            //foreach (var item in modifiedEntries)
            //{
            //    IEntity entity = item.Entity as IEntity;

            //    if (item != null)
            //    {
            //        if (item.State == EntityState.Added)
            //        {
            //            //Ekleme sonrası yapılacaklar
            //        }
            //        else if (item.State == EntityState.Modified)
            //        {
            //            //Düzenleme sonrası yapılacaklar
            //        }

            //    }
            //}

            return base.SaveChanges();
        }

    }
}
