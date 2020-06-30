using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        // GET: api/Security
        [HttpGet]
        
            public IEnumerable<string> Get()
            {
                // Key
                var securityKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes("238420983409284098230948"));
                // Algorithm
                var credentials = new
                        SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                // claimns
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "shiv"),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken("finishingschool",
                  "finishingschool",
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                string tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                return new string[] { tokenstring };
            }
       

        // GET: api/Security/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Security
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Security/5
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
