using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DeskApp_Students_Management.Model
{
    public class StudentModel
    {
        // Fields
        private string studentID;
        private string studentName;
        private string studentAddress;
        private string idClass;

        // Properties
        [DisplayName("Mã Sinh Viên")]
        public string StudentID { get => studentID; set => studentID = value; }

        [DisplayName("Họ Và Tên")]
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Student's name must be between 3 and 50 character")]

        public string StudentName { get => studentName; set => studentName = value; }
        [DisplayName("Địa Chỉ")]
        [Required(ErrorMessage = "Student Address is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Student's Address must be between 3 and 100 character")]
        public string StudentAddress { get => studentAddress; set => studentAddress = value; }

        [DisplayName("Lớp Học")]
        [Required(ErrorMessage = "Student Class is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Student's Class must be between 3 and 100 character")]
        public string IdClass { get => idClass; set => idClass = value; }
        
    }
}
