using Core.Entity.Abstract;
using Core.Entity.Enum;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Education : IEntity
    {
        public Guid ID { get; set; }
        private DateTime _createdDate = DateTime.Now;
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime? ModifiedDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        [Required(ErrorMessage = "Error Message")]
        public DegreeType DegreeType { get; set; }

        [Required(ErrorMessage = "Error Message")]
        public string DegreeName { get; set; }

        [Required(ErrorMessage = "Error Message")]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Error Message")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Error Message")]
        public string State { get; set; }

        [Required(ErrorMessage = "Error Message")]
        public string City { get; set; }

        [Required(ErrorMessage = "Error Message")]
        public int StartYear { get; set; }

        [Required(ErrorMessage = "Error Message")]
        public int CompletionYear { get; set; }
        public bool IsCurrent { get; set; }

        //Navigation Prop.
        public Guid JobSeekerID { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
    }
}
