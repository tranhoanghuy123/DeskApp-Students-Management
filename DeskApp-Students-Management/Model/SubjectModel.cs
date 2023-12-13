using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Model
{
    public class SubjectModel
    {
        //Fields
        private string idSubject;
        private string nameSubject;
        private int qtyCredit;

        //Properties
        [DisplayName("Mã Môn Học")]
        public string IdSubject { get => idSubject; set => idSubject = value; }
        [DisplayName("Tên Môn Học")]
        public string NameSubject { get => nameSubject; set => nameSubject = value; }
        [DisplayName("Số Tín Chỉ")]
        public int QtyCredit { get => qtyCredit; set => qtyCredit = value; }

    }
}
