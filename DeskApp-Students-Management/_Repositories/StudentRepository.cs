using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DeskApp_Students_Management.Model;
using System.Windows.Forms;

namespace DeskApp_Students_Management._Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        //Constructor
        public StudentRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        //Methods
        public void Add(StudentModel student)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Insert into Students(studentID,studentName" +
                        ",studentAddress,classID) values ('" +
                        student.StudentID + "',N'" +
                        student.StudentName +"',N'" +
                        student.StudentAddress +"','" +
                        student.IdClass+"');";
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string studentID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Delete from Students where studentID = '"+ studentID +"';";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(StudentModel student)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Update Students set studentName=N'" +
                         student.StudentName + "',studentAddress=N'" + student.StudentAddress + "',classID='" + student.IdClass + "' " +
                         "where studentID ='" + student.StudentID + "';";
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<StudentModel> GetAll()
        {
            var studentList = new List<StudentModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select * from Students order by studentID desc";
                    using(var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                           var studentModel = new StudentModel();
                            studentModel.StudentID = reader[0].ToString();
                            studentModel.StudentName = reader[1].ToString();
                            studentModel.StudentAddress = reader[2].ToString();
                            studentModel.IdClass = reader[3].ToString();
                            studentList.Add(studentModel);
                        }
                    }
                }
            }
            return studentList;  
        }

        public IEnumerable<StudentModel> GetByValue(string value)
        {
            var studentList = new List<StudentModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"Select * from Students where studentID = '" + value + "' or studentName like  N'%" + value +"%' order by studentID desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentModel = new StudentModel();
                            studentModel.StudentID = reader[0].ToString();
                            studentModel.StudentName = reader[1].ToString();
                            studentModel.StudentAddress = reader[2].ToString();
                            studentModel.IdClass = reader[3].ToString();
                            studentList.Add(studentModel);
                        }
                    }
                }
            }
            return studentList;
        }
    }
}
