using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_cw6.Services
{
    public class EfStudentDbService : IStudentDbSerives
    {


       //  s18793context _context;

        public EfStudentDbService(///s187932context context)
        ){
           /// _context = context;
        }

        public void EnrollStudent(string index)
        {
           // return _context.Student.ToList();
        }

        public void PromoteStudent(string index)
        {
           // return _context.Student.First(s => s.IndexNumber == index);
        }
    }
}
    
