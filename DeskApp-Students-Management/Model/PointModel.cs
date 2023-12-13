using DeskApp_Students_Management.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management.Model
{
    public class PointModel
    {
        //Fields
        private string idStudent;
        private string idSubject;
        private string nameSubject;
        private float score;
        //Properties
        [DisplayName("Mã Sinh Viên")]
        public string IdStudent { get => idStudent; set => idStudent = value; }
        [DisplayName("Mã Môn Học")]
        public string IdSubject { get => idSubject; set => idSubject = value; }
        [DisplayName("Tên Môn Học")]
        public string NameSubject { get => nameSubject; set => nameSubject = value; }
        [DisplayName("Điểm Số")]
        public float Score { get => score; set => score = value; }
    }
}
