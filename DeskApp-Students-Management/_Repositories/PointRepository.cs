using DeskApp_Students_Management.Model;
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
    public class PointRepository : BaseRepository, IPointRepository
    {
        public PointRepository(string sqlConnectionString) 
        {
            this.connectionString = sqlConnectionString;
        }

        public void Add(PointModel pointModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Insert into Scores(studentID,subID,score) values ('" +
                    pointModel.IdStudent + "','" +
                    pointModel.IdSubject + "'," +
                    pointModel.Score + ");";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(PointModel pointModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Update Scores set score = " +
                    pointModel.Score.ToString() + " where studentID ='" +
                    pointModel.IdStudent + "' and subID = '" +
                    pointModel.IdSubject + "';";
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool FindPointFromDB(string subID, string studentID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select score from Scores where studentID ='" +
                    studentID + "' and subID ='" + subID + "';";
                    return command.ExecuteReader().Read();
                }
            }
        }

        public IEnumerable<PointModel> GetAll()
        {
            var pointList = new List<PointModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    //Câu truy vấn lấy ra 4 trường dữ liệu cần thiết cho 1 point model.
                    //Nếu không hiểu thì xem về SQL Tutorial phần Join table trên w3school
                    command.CommandText = "Select studentID,Scores.subID,subName,score from Scores," +
                        "Subjects where Subjects.subID = Scores.subID  order by studentID desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pointModel = new PointModel();
                            pointModel.IdStudent = reader[0].ToString();
                            pointModel.IdSubject = reader[1].ToString();
                            pointModel.NameSubject = reader[2].ToString();
                            pointModel.Score = float.Parse(reader[3].ToString());
                            pointList.Add(pointModel);
                        }
                    }
                }
            }
            return pointList;
        }

        public IEnumerable<PointModel> GetByValue(string studentID)
        {
            var pointList = new List<PointModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    //Câu truy vấn lấy ra 4 trường dữ liệu cần thiết cho 1 point model.
                    //Nếu không hiểu thì xem về SQL Tutorial phần Join table trên w3school
                    command.CommandText = "Select studentID,Scores.subID,subName,score from Scores," +
                        "Subjects where Subjects.subID = Scores.subID and studentID = '" + studentID +
                        "'  order by studentID desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pointModel = new PointModel();
                            pointModel.IdStudent = reader[0].ToString();
                            pointModel.IdSubject = reader[1].ToString();
                            pointModel.NameSubject = reader[2].ToString();
                            pointModel.Score = float.Parse(reader[3].ToString());
                            pointList.Add(pointModel);
                        }
                    }
                }
            }
            return pointList;
        }
    }
}
