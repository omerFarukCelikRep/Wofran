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
    public class EducationDAL : BaseDAL<Education>,IEducationDAL
    {
        private readonly WofranDbContext _context;

        public EducationDAL(WofranDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
