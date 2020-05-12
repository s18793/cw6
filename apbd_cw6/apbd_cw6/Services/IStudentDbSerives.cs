using apbd_cw6.DTOs;
using apbd_cw6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_cw6.Services
{
    public interface IStudentDbSerives
    {

        public IEnumerable<Student> getStudent();

        public List<Enrollment> promoteStudents(PromoteStudReq request);
        public Student modfiyStudent(Student student);
        public Student deleteStudent(string index);
        public string EnrollStudent(EnrollStudentReq req);
        
    }
}
