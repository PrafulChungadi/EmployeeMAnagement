using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Dal;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class employeController : ControllerBase
    {
        [EnableCors("AllowOriginRule")]
        // GET: api/employe
       
       
        // GET: api/employe/5
        [HttpGet]
        public IActionResult Get(/*[FormBody]or[FromForm]*/ string employeeName)
        {
            EmployeeDal dal = new EmployeeDal();
            List<EmployeeModel> search = (from temp in dal.EmployeeModels
                                          where temp.name == employeeName
                                          select temp)
                                        .ToList<EmployeeModel>();
            return Ok(search);
        }

        // POST: api/employe
        [HttpPost]
        public IActionResult Post(EmployeeModel obj)
        {

            //Employee controller you will call validate
            //create object of context
            var context = new ValidationContext(obj, null, null);
            //fill the error
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
           {
                EmployeeDal dal = new EmployeeDal();
                dal.Database.EnsureCreated(); //<--tblEmployee  created
                dal.Add(obj);
               
                dal.SaveChanges(); //Physical commit



                List<EmployeeModel> recs = dal.EmployeeModels.Include(emp =>emp.addresses).ToList<EmployeeModel>();

                return StatusCode(200, recs); //200
            }
           else
            {
                return StatusCode(500, result);//500internal (error)
            }
        }

        // PUT: api/employe/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
