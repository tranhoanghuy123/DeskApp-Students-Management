using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Model
{
    public interface IPointRepository
    {
        // Note: Đối tượng kiểu điểm của 1 sinh viên thì sẽ không có chức năng xóa bởi vì chỉ có thêm và sửa thôi
        void Add(PointModel pointModel);
        void Edit(PointModel pointModel);
        bool FindPointFromDB(string subID, string studentID);
        IEnumerable<PointModel> GetAll();
        IEnumerable<PointModel> GetByValue(string studentID); // find all score of student;
    }
}
