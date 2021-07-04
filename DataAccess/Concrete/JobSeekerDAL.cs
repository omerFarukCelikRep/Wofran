using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class JobSeekerDAL : BaseDAL<JobSeeker>,IJobSeekerDAL
    {
        private readonly WofranDbContext _context;
        public JobSeekerDAL(WofranDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
