using DeskApp_Students_Management.Model;
using IronPdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DeskApp_Students_Management._Repositories
{
    public class SubjectRepository : BaseRepository,ISubjectRepository
    {
        // Constructor get connectionString from  BaseRepository( App config)
        public SubjectRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }
        // Methods
        public void Add(SubjectModel subject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Insert into Subjects(subID,subName,qtyCredit) values ('" +
                    subject.IdSubject + "',N'" +
                    subject.NameSubject + "','" +
                    subject.QtyCredit + "');";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string idSubject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Delete from Subjects where subID = '" +
                   idSubject + "';" +
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(SubjectModel subject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Update Subjects set subName=N'" +
                        subject.NameSubject + "',qtyCredit='" +
                        subject.QtyCredit + "' where subID ='" + subject.IdSubject +
                        "';";
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool FindSubjectFromDB(string idSubject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select subName from Subjects where subID = '" +
                    idSubject + "';";
                    return command.ExecuteReader().Read();
                }
            }
          
        }

        public IEnumerable<SubjectModel> GetAll()
        {
            var subjectsList = new List<SubjectModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select * from Subjects order by subID desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subjectModel = new SubjectModel();
                            subjectModel.IdSubject = reader[0].ToString();
                            subjectModel.NameSubject = reader[1].ToString();
                            subjectModel.QtyCredit = int.Parse(reader[2].ToString());
                            subjectsList.Add(subjectModel);
                        }
                    }
                }
            }
            return subjectsList;
        }

        public IEnumerable<SubjectModel> GetByValue(string value)
        {
            var subjectsList = new List<SubjectModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"Select * from Subjects where subID = '" + value + "' " +
                        "or subName like  N'%" + value + "%' order by subID desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subjectModel = new SubjectModel();
                            subjectModel.IdSubject = reader[0].ToString();
                            subjectModel.NameSubject = reader[1].ToString();
                            subjectModel.QtyCredit = int.Parse(reader[2].ToString());
                            subjectsList.Add(subjectModel);
                        }
                    }
                }
            }
            return subjectsList;
        }
        public  bool ExportedPDF()
        {
            IEnumerable<SubjectModel> subjectsList = new List<SubjectModel>();
            subjectsList = GetAll();
            string htmlPDF = "<style>table, th { margin: auto; border: 1px solid;padding: 20px;border-collapse: collapse;} h1{text-align: center;} </style><table><tr><th>Mã môn học</td><th>Tên môn học</td><th>Số tín chỉ</td></tr>";
            foreach (SubjectModel subject in subjectsList)
            {
                htmlPDF += "<tr>" +
                        "<th>" + subject.IdSubject +
                        "<th>" + subject.NameSubject +
                        "<th>" + subject.QtyCredit +
                     "</tr>";
            }
            htmlPDF += "</table>";
            var pdf = new IronPdf.HtmlToPdf();
            PdfDocument doc = pdf.RenderHtmlAsPdf("<h1> BÁO CÁO TẤT CẢ MÔN HỌC</h1>" +
               htmlPDF);
            string strTimeNow = DateTime.Now.ToString().Replace(":", "");
            strTimeNow = strTimeNow.Replace("/", "");
            strTimeNow = strTimeNow.Replace(" ", "");
            string fileName = "BAO-CAO-TAT-CA-MON-HOC[" + strTimeNow + "].pdf";
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
