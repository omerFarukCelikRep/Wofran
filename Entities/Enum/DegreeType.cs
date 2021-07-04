using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enum
{
    public enum DegreeType
    {
        [Display(Name ="High School")]
        HighSchool,
        [Display(Name = "Bachelor")]
        Bachelor,
        [Display(Name = "Master")]
        Master
    }
}
