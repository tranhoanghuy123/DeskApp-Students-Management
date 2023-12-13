using DeskApp_Students_Management.Model;
using IronPdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management._Repositories
{
    public class GetDataScoreOfStudent:BaseRepository
    {
        //Constructor
        public GetDataScoreOfStudent(string sqlConnectionString)
        {
            this.connectionString = sqlConnectionString;
        }
        // Methods
        public IEnumerable<ScoreOfStudentModel> GetAllData()
        {
            var scoreList = new List<ScoreOfStudentModel>();
            using(var connection = new SqlConnection(connectionString))
            {
                using(var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    //Câu truy vấn lấy ra 4 trường dữ liệu cần thiết cho 1 point model.
                    //Nếu không hiểu thì xem về SQL Tutorial phần Join table trên w3school
                    command.CommandText = "Select Students.studentID,studentName,subName,score from Students,Subjects,Scores " +
                                            "where " +
                                            "Students.studentID = Scores.studentID and Scores.subID = Subjects.subID order by score asc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var scoreOfStudent = new ScoreOfStudentModel();
                            scoreOfStudent.IdStudent = reader[0].ToString();
                            scoreOfStudent.NameStudent = reader[1].ToString();
                            scoreOfStudent.NameSubject = reader[2].ToString();
                            scoreOfStudent.Score = float.Parse(reader[3].ToString());
                            scoreList.Add(scoreOfStudent);
                        }
                    }
                }
            }
            return scoreList;
        }
        public IEnumerable<ScoreOfStudentModel> GetDataByValue(string studentID)
        {
            var scoreList = new List<ScoreOfStudentModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    //Câu truy vấn lấy ra 4 trường dữ liệu cần thiết cho 1 point model.
                    //Nếu không hiểu thì xem về SQL Tutorial phần Join table trên w3school
                    command.CommandText = "Select Students.studentID,studentName,subName,score from Students,Subjects,Scores " +
                                            "where " +
                                        "Students.studentID = Scores.studentID and Scores.subID = Subjects.subID " +
                                        "and Scores.studentID = '" + studentID + "' order by score  asc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var scoreOfStudent = new ScoreOfStudentModel();
                            scoreOfStudent.IdStudent = reader[0].ToString();
                            scoreOfStudent.NameStudent = reader[1].ToString();
                            scoreOfStudent.NameSubject = reader[2].ToString();
                            scoreOfStudent.Score = float.Parse(reader[3].ToString());
                            scoreList.Add(scoreOfStudent);
                        }
                    }
                }
            }
            return scoreList;
        }
        public bool ExportedPDF(IEnumerable<ScoreOfStudentModel> scoreList, string studentID)
        {
            string htmlPDF = "<style>table, th { margin: auto; border: 1px solid;padding: 20px;border-collapse: collapse;} h1{text-align: center;} </style><table><tr><th>Mã sinh viên</td><th>Tên sinh viên</td><th>Tên môn học</td><th>Điểm số</td></tr>";
            foreach (ScoreOfStudentModel score in scoreList)
            {
                htmlPDF += "<tr>" +
                        "<th>" + score.IdStudent +
                        "<th>" + score.NameStudent +
                        "<th>" + score.NameSubject +
                        "<th>" + score.Score +
                     "</tr>";
            }
            htmlPDF += "</table>";
            var pdf = new IronPdf.HtmlToPdf();
            PdfDocument doc = pdf.RenderHtmlAsPdf("<h1> Báo cáo bảng điểm của sinh viên</h1>" +
               htmlPDF);
            string strTimeNow = DateTime.Now.ToString().Replace(":", "");
            strTimeNow = strTimeNow.Replace("/", "");
            strTimeNow = strTimeNow.Replace(" ", "");
            string fileName = "BAO-CAO-BANG-DIEM-SV-[" + studentID + "]-[" + strTimeNow + "].pdf";
            bool result = doc.TrySaveAs(fileName);
            if(result)
            {
                MessageBox.Show("Báo cáo đã xuất thành công và được lưu với định dạng: " + fileName, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xuất báo cáo thất bại. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            return result;
        }
    }
}
