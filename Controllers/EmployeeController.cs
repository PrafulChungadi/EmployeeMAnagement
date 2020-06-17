using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Dal;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Controllers
{
       [EnableCors ("AllowOriginRule")]
    public class EmployeeController : Controller
    {
        
         
        
        public IActionResult Submit([FromBody] EmployeeModel obj)
        {
            //Employee controller you will call validate
            //create object of context
            var context = new ValidationContext(obj, null, null);
            //fill the error
            var result =new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context,result, true);

            if (result.Count == 0) {
                EmployeeDal dal = new EmployeeDal();
                dal.Database.EnsureCreated(); //<--tblEmployee  created
                dal.Add(obj);
                dal.SaveChanges();



                List<EmployeeModel> recs = dal.EmployeeModels.ToList<EmployeeModel>();

                return StatusCode(200,recs); //200
            }
            else
            {
                return StatusCode(500,result);//500internal (error)
            }
        }

    
        public IActionResult ViewEmployee()
        {
            return View("DisplayEmployees");
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
       
    }
}