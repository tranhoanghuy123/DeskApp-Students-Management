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
    public class ClassRepository : BaseRepository, IClassRepository
    {
        public ClassRepository(string connectionString) 
        { 
            this.connectionString = connectionString;
        }
        public void Add(ClassModel classModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Insert into Classes(classID,className,schoolYear) values ('" +
                    classModel.IdClass + "',N'" +
                    classModel.NameClass + "',N'" +
                    classModel.SchoolYear + "');";
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string classID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Delete from Classes where classID = '" +
                        classID + "';" +
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(ClassModel classModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Update Classes set className=N'" +
                        classModel.NameClass + "',schoolYear='" +
                        classModel.SchoolYear + "' where classID = '" + classModel.IdClass +
                        "';";
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool FindClassFromDB(string idClass)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select className from Classes where classID = '" +
                        idClass + "';";
                    return command.ExecuteReader().Read();
                }
            }
        }

        public IEnumerable<ClassModel> GetAll()
        {
            var classList = new List<ClassModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select * from Classes order by classID desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var classModel = new ClassModel();
                            classModel.IdClass = reader[0].ToString();
                            classModel.NameClass = reader[1].ToString();
                            classModel.SchoolYear = int.Parse(reader[2].ToString());
                            classList.Add(classModel);
                        }
                    }
                }
            }
            return classList;
        }

        public IEnumerable<ClassModel> GetByValue(string value)
        {
            var classList = new List<ClassModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"Select * from Classes where classID = '" + value + "' " +
                        "or className like  N'%" + value + "%' order by classID desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var classModel = new ClassModel();
                            classModel.IdClass = reader[0].ToString();
                            classModel.NameClass = reader[1].ToString();
                            classModel.SchoolYear = int.Parse(reader[2].ToString());
                            classList.Add(classModel);
                        }
                    }
                }
            }
            return classList;
        }
        public bool ExportedPDF()
        {
            IEnumerable<ClassModel> classList = new List<ClassModel>();
            classList = GetAll();
            string htmlPDF = "<style>table, th { margin: auto; border: 1px solid;padding: 20px;border-collapse: collapse;} h1{text-align: center;} </style><table><tr><th>Mã lớp học</td><th>Tên ngành học</td><th>Niên khóa</td></tr>";
            foreach (ClassModel classModel in classList)
            {
                htmlPDF += "<tr>" +
                        "<th>" + classModel.IdClass +
                        "<th>" + classModel.NameClass +
                        "<th>" + classModel.SchoolYear +
                     "</tr>";
            }
            htmlPDF += "</table>";
            var pdf = new IronPdf.HtmlToPdf();
            PdfDocument doc = pdf.RenderHtmlAsPdf("<h1> BÁO CÁO TẤT CẢ NGÀNH HỌC</h1>" +
               htmlPDF);
            string strTimeNow = DateTime.Now.ToString().Replace(":", "");
            strTimeNow = strTimeNow.Replace("/", "");
            strTimeNow = strTimeNow.Replace(" ", "");
            string fileName = "BAO-CAO-TAT-CA-NGANH-HOC[" + strTimeNow + "].pdf";
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

