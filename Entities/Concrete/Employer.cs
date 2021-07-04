using Core.Entity.Abstract;
using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employer : IEntity
    {
        public Guid UserID { get; set; }
        public virtual AppUser AppUser { get; set; }

        private DateTime _createdDate = DateTime.Now;
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime? ModifiedDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
