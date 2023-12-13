using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeskApp_Students_Management.Model;
using DeskApp_Students_Management.Views;
namespace DeskApp_Students_Management.Presenters
{
    public class StudentPresenter
    {
        // Fields
        private IStudentView view;
        private IStudentRepository repository;
        private BindingSource studentBindingSource;
        private IEnumerable<StudentModel> studentList;

        // Constructor
        public StudentPresenter(IStudentView view, IStudentRepository repository)
        {
            this.studentBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            // Init event handle methods to view event
            this.view.SearchEvent += SearchStudent;
            this.view.AddNewEvent += AddNewStudent;
            this.view.EditEvent += LoadSelectedStudentToEdit;
            this.view.DeleteEvent += DeleteSelectedStudent;
            this.view.SaveEvent += SaveStudent;
            this.view.CancelEvent += CancelAction;
            // Set Student Binding Source
            this.view.SetStudentListBindingSource(studentBindingSource);
            //Load student list view
            LoadAllStudentList();
            //Show view
            this.view.Show();
        }

        private void LoadAllStudentList()
        {
            studentList = repository.GetAll();
            studentBindingSource.DataSource = studentList; // Set data source
        }

        private void AddNewStudent(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedStudentToEdit(object sender, EventArgs e)
        {
            var student = (StudentModel)studentBindingSource.Current;
            view.StudentID = student.StudentID;
            view.StudentName = student.StudentName;
            view.StudentClass = student.IdClass;
            view.StudentAddress = student.StudentAddress;
            view.IsEdit = true;
        }
         
        private void DeleteSelectedStudent(object sender, EventArgs e)
        {
            try
            {
                var student = (StudentModel)studentBindingSource.Current;
                repository.Delete(student.StudentID);
                view.IsSuccessful = true;
                view.Message = "Xóa sinh viên thành công";
                LoadAllStudentList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = true;
                view.Message = "Đã xảy ra lỗi khi Xóa sinh viên";
            }
        }

        private void SaveStudent(object sender, EventArgs e)
        {
            var model = new StudentModel();
            model.StudentID = view.StudentID;
            model.StudentName = view.StudentName;
            model.IdClass = view.StudentClass;
            model.StudentAddress = view.StudentAddress;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if(view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Sửa Thông Tin Sinh Viên Thành Công";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Thêm Thông Tin Sinh Viên Thành Công";
                }
                view.IsSuccessful = true;
                LoadAllStudentList();
                CleanViewFields();
            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.StudentID = "";
            view.StudentName = "";
            view.StudentClass = "";
            view.StudentAddress = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SearchStudent(object sender, EventArgs e)
        {
            bool emptyVal = string.IsNullOrEmpty(this.view.SearchValue);
            if (!emptyVal)
                studentList = repository.GetByValue(this.view.SearchValue);
            else
                studentList = repository.GetAll();
            studentBindingSource.DataSource = studentList;
        }


    }
}
