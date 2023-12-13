using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Model
{
    public class ScoreOfStudentModel
    {
        //Fields
        private string idStudent;
        private string nameStudent;
        private string nameSubject;
        private float score;
        //Properties
        [DisplayName("Mã sinh viên")]
        public string IdStudent { get => idStudent; set => idStudent = value; }
        [DisplayName("Họ và tên")]
        public string NameStudent { get => nameStudent; set => nameStudent = value; }
        [DisplayName("Tên môn học")]
        public string NameSubject { get => nameSubject; set => nameSubject = value; }
        [DisplayName("Điểm số")]
        public float Score { get => score; set => score = value; }
    }
}
