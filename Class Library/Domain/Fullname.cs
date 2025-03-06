using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Domain
{
    //[Owned]
    public class Fullname
    {
        // min max
        [StringLength(25, MinimumLength = 2, ErrorMessage = "FirstName must be between 2 and 25 characters long.")]
        public string FirstName { get; set; }
        //public int Id { get; set; }
        public string LastName { get; set; }
    }
}
