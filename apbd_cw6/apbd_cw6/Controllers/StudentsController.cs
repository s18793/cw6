using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apbd_cw6.DTOs;
using apbd_cw6.Models;
using apbd_cw6.Services;
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

        public IStudentDbSerives _service;

        public StudentsController(IStudentDbSerives service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {

            var res = _service.getStudent();
            return Ok(res);

        }
        [Route("api/update")]
        [HttpPost]

        public IActionResult modfiyStudent(Student _student)
        {
            var res = _service.modfiyStudent(_student);
            return Ok(res);
        }

        [HttpDelete("{IndexNumber}")]

        public IActionResult deleteStudent(String IndexNumber)
        {
            var res = _service.deleteStudent(IndexNumber);
            return Ok(res);
        }
        [HttpPost]
        [Route("api/students/promo")]
        public IActionResult promoteStudents(PromoteStudReq request)
        {
            List<Enrollment> lista = _service.promoteStudents(request);
            return Ok(lista);
        }

        [HttpPost]
        [Route("api/students/enroll")]
        public IActionResult EnrollStudent(EnrollStudentReq req)
        {
            string enroll = _service.EnrollStudent(req);
            return Ok(enroll);
        }
        

    }
}