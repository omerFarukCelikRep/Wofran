using Core.Entity.Abstract;
using Core.Entity.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
        public virtual Employer Employer { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
    }
}
