using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Model
{
    public class ClassModel
    {
        private string idClass;
        private string nameClass;
        private int schoolYear;

        [DisplayName("Mã Lớp Học")]
        public string IdClass { get => idClass; set => idClass = value; }
        [DisplayName("Tên Lớp Học")]
        public string NameClass { get => nameClass; set => nameClass = value; }
        [DisplayName("Niên Khóa")]
        public int SchoolYear { get => schoolYear; set => schoolYear = value; }
    }
}
