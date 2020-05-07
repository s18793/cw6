using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_cw6.Services
{
    public interface IStudentDbSerives
    {

        public void EnrollStudent(string index);
        public void PromoteStudent(string index);
    }
}
