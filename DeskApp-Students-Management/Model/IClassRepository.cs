using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Model
{
    public interface IClassRepository
    {
        void Add(ClassModel classModel);
        void Edit(ClassModel classModel);
        void Delete(string classID);
        bool FindClassFromDB(string idClass);
        IEnumerable<ClassModel> GetAll();
        IEnumerable<ClassModel> GetByValue(string value); // Func search Class by value ...
    }
}
