using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apbd_cw6.DTOs;
using apbd_cw6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace apbd_cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }
        public StudentsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult GetStudents()
        {

            
            var list = new List<Student>();
            
                list.Add(new Student
                {
                    IdStudent=1,
                    FirstName="Jan",
                    LastName="Kowalski"

                });
            list.Add(new Student
            {
                IdStudent = 2,
                FirstName = "Kajetan",
                LastName = "Masny"

            });
            return Ok(list);

        }

        [HttpPost]
        public IActionResult Login(LoginRequestDto requestDto)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,"1"),
                new Claim(ClaimTypes.Name, "pawel"),
                new Claim(ClaimTypes.Role, "student")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                 issuer: "s18793",
                 audience: "Students",
                  claims: claims,
                   expires: DateTime.Now.AddMinutes(10),
                   signingCredentials: creds

            );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = Guid.NewGuid()
            }); ;
        }
    
    }

}