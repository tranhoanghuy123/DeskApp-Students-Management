using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Model
{
    public interface IStudentRepository
    {
        void Add(StudentModel student);
        void Edit(StudentModel student);
        void Delete(string studentID);
        IEnumerable<StudentModel> GetAll();
        IEnumerable<StudentModel> GetByValue(string value); // Func search student by value ...
    }
}
