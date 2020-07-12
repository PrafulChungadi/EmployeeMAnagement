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
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-z]{1,10}$")]
        public string name { get; set; }
       
        // to many relationship
        public List<Address> addresses { get; set; }//pural
    }
    public class Address //singular
    {
        public int id { get; set; }
        [Required]
        public string address { get; set; }
        public EmployeeModel employee { get; set; }
    }
}
