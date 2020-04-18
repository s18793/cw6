using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_cw6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        
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
    }
}