using apbd_cw6.DTOs;
using apbd_cw6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_cw6.Services
{
    public class EfStudentDbService : IStudentDbSerives
    {


        public s18793Context _context;

        public EfStudentDbService(s18793Context context)
        {
            _context = context;
        }

        public IEnumerable<Student> getStudent()
        {
            var data = new s18793Context();

            var listaStud = data.Student.ToList();
            return listaStud;
        }


     

        public Student modfiyStudent(Student student)
        {
            var data = new s18793Context();

            var stud
            = data.Student.Where(s => s.IndexNumber == student.IndexNumber);
            var studlist = stud.ToList();

            foreach (var modStud in studlist)
            {
                modStud.IndexNumber = student.IndexNumber;
                modStud.FirstName = student.FirstName;
                modStud.LastName = student.LastName;
                modStud.IdEnrollment = student.IdEnrollment;
                modStud.BirthDate = student.BirthDate;

            }
            data.SaveChanges();


            return null;
        }


       

        public Student deleteStudent(string index)
        {
            var data = new s18793Context();
            var deleteList = data.Student.Where(s => s.IndexNumber == index).ToList();
            Student deletedStudent=null;


            foreach (var student in deleteList){
                deletedStudent = student;
                data.Student.Remove(student);
            }
            data.SaveChanges();
           
            
            
            return deletedStudent;
        }

        public List<Enrollment> promoteStudents(PromoteStudReq request)
        {

            //todo dodac z poprzedniego repo do tego 
            //procedura z cwiczen poprzednich zwizanychh z promote
            _context.Database.ExecuteSqlRaw("EXEC PromoteStudents @studies @Semester ", request.Name, request.Semester);
            return null;
        }

        public string EnrollStudent(EnrollStudentReq req)
        {

            var student = _context.Student.Where(s => s.IndexNumber.Equals(req.IndexNumber)).ToList();

            if (student.Count != 0) return "Istnieje juz taki indeks";
            var studi = _context.Studies.Where(st => st.Name.Equals(req.Studies)).ToList();
            var enrollment = _context.Enrollment.Where(e => e.IdStudy.Equals(studi.First().IdStudy)&& e.Semester == 1).ToList();

            if (enrollment.Count() == 0)
            {
                Enrollment enrol = new Enrollment
                {
                    IdEnrollment = enrollment.First().IdEnrollment,
                    IdStudy = studi.First().IdStudy,
                    Semester = 1,
                    StartDate = DateTime.Now
                };

                _context.Enrollment.Add(enrol);
                _context.SaveChanges();



            }
            return null;

                
        }
    }
}
 

    
