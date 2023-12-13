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
    public class InforStudentExportRepository:BaseRepository
    {
        // Constructor
        public InforStudentExportRepository(string sqlConnectionString) 
        {
            this.connectionString = sqlConnectionString;
        }
        // Methods
        public IEnumerable<InforStudentExportModel> GetAllData()
        {
            var studentList = new List<InforStudentExportModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select Students.studentID, studentName,studentAddress from Students order by studentID asc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentModel = new InforStudentExportModel();
                            studentModel.IdStudent = reader[0].ToString();
                            studentModel.NameStudent = reader[1].ToString();
                            studentModel.StudentAddress = reader[2].ToString();
                            using (var scoreConnection = new SqlConnection(connectionString))
                            {
                                using (var commandScore = new SqlCommand())
                                {
                                    scoreConnection.Open();
                                    commandScore.Connection = scoreConnection;
                                    commandScore.CommandText = "Select AVG(score) from Scores where studentID = '" + studentModel.IdStudent + "'";
                                   
                                    using (var readerScore = commandScore.ExecuteReader())
                                    {
                                        if(readerScore.Read())
                                        {
                                            if (!string.IsNullOrEmpty(readerScore[0].ToString()))
                                            {
                                                studentModel.Score = float.Parse(readerScore[0].ToString());
                                            }
                                            else
                                            {
                                                studentModel.Score = float.Parse("0.0");
                                            }
                                                
                                        }
                                    }
                                }
                            }
                            studentList.Add(studentModel);
                        }
                    }
                }
            }
            return studentList;
        }
        public IEnumerable<InforStudentExportModel> GetDataByValue(string classID)
        {
            var studentList = new List<InforStudentExportModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select Students.studentID, studentName,studentAddress from Students " +
                        "where classID = '" +
                        classID +
                        "' order by studentID asc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentModel = new InforStudentExportModel();
                            studentModel.IdStudent = reader[0].ToString();
                            studentModel.NameStudent = reader[1].ToString();
                            studentModel.StudentAddress = reader[2].ToString();
                            using (var scoreConnection = new SqlConnection(connectionString))
                            {
                                using (var commandScore = new SqlCommand())
                                {
                                    scoreConnection.Open();
                                    commandScore.Connection = scoreConnection;
                                    commandScore.CommandText = "Select AVG(score) from Scores where studentID = '" + studentModel.IdStudent + "'";

                                    using (var readerScore = commandScore.ExecuteReader())
                                    {
                                        if (readerScore.Read())
                                        {
                                            if (!string.IsNullOrEmpty(readerScore[0].ToString()))
                                            {
                                                studentModel.Score = float.Parse(readerScore[0].ToString());
                                            }
                                            else
                                            {
                                                studentModel.Score = float.Parse("0.0");
                                            }

                                        }
                                    }
                                }
                            }
                            studentList.Add(studentModel);
                        }
                    }
                }
            }
            return studentList;
        }
        public bool ExportedPDF(IEnumerable<InforStudentExportModel> studentList, string classID)
        {
            string htmlPDF = "<style>table, th { margin: auto; border: 1px solid;padding: 20px;border-collapse: collapse;} h1{text-align: center;} </style><table><tr><th>Mã sinh viên</td><th>Tên sinh viên</td><th>Tên môn học</td><th>Điểm số</td></tr>";
            foreach (InforStudentExportModel student in studentList)
            {
                htmlPDF += "<tr>" +
                        "<th>" + student.IdStudent +
                        "<th>" + student.NameStudent +
                        "<th>" + student.StudentAddress +
                        "<th>" + student.Score +
                     "</tr>";
            }
            htmlPDF += "</table>";
            var pdf = new IronPdf.HtmlToPdf();
            PdfDocument doc = pdf.RenderHtmlAsPdf("<h1> BÁO CÁO DANH SÁCH SINH VIÊN LỚP "+ classID + "</h1>" +
               htmlPDF);
            string strTimeNow = DateTime.Now.ToString().Replace(":", "");
            strTimeNow = strTimeNow.Replace("/", "");
            strTimeNow = strTimeNow.Replace(" ", "");
            string fileName = "BAO-CAO-DSSV-LOP-[" + classID + "]-[" + strTimeNow + "].pdf";
            bool result = doc.TrySaveAs(fileName);
            if (result)
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
