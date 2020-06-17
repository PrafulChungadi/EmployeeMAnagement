using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmployeeModel
    {
        [Required]
        [RegularExpression("^[a-z]{1,10}$")]
        public string name { get; set; }
        [Required]
        public int id { get; set; }
    }
}
