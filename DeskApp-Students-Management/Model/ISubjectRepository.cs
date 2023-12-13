using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Model
{
    public interface ISubjectRepository
    {
        void Add(SubjectModel subject);
        void Edit(SubjectModel subject);
        void Delete(string idSubject);
        bool FindSubjectFromDB(string idSubject);
        IEnumerable<SubjectModel> GetAll();
        IEnumerable<SubjectModel> GetByValue(string value); // Search subject by value (optional: id or name)
    }
}
