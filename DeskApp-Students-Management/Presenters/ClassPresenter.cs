using DeskApp_Students_Management.Model;
using DeskApp_Students_Management.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management.Presenters
{
    public class ClassPresenter
    {
        private IClassView view;
        private IClassRepository repository;
        private BindingSource classBindingSource;
        private IEnumerable<ClassModel> classList;

        public ClassPresenter(IClassView view, IClassRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.classBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            // Init event handle methods to view event
            this.view.SearchClassEvent += SearchClassEvent;
            this.view.AddNewClassEvent += AddNewClassEvent;
            this.view.DeleteClassEvent += DeleteClassEvent;
            this.view.SaveClassEvent += SaveClassEvent;
            this.view.CancelClassEvent += CancelClassEvent;
            // Set Class Binding Source
            this.view.SetClassListBindingSource(classBindingSource);
            //Load Class list view
            LoadAllClassList();
            //Show view
            this.view.Show();
        }

        private void LoadAllClassList()
        {
            classList = repository.GetAll();
            classBindingSource.DataSource = classList; // Set data of list
        }

        private void CancelClassEvent(object sender, EventArgs e)
        {
            CleanViewFields();
        }
        private void CleanViewFields()
        {
            view.ClassID = "";
            view.ClassName = "";
            view.SchoolYear = 0;
        }
        private void SaveClassEvent(object sender, EventArgs e)
        {
            var model = new ClassModel();
            model.IdClass = view.ClassID;
            model.NameClass = view.ClassName;
            model.SchoolYear = view.SchoolYear;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if(repository.FindClassFromDB(model.IdClass))
                {
                    repository.Edit(model);
                    view.Message = "Sửa Thông Tin Lớp Thành Công";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Thêm Lớp Học Thành Công";
                }
                view.IsSuccessful = true;
                LoadAllClassList();
                CleanViewFields();
            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void DeleteClassEvent(object sender, EventArgs e)
        {
            try
            {
                var classModel = (ClassModel)classBindingSource.Current;
                repository.Delete(classModel.IdClass);
                view.IsSuccessful = true;
                view.Message = "Xóa lớp học thành công";
                LoadAllClassList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = true;
                view.Message = "Đã xảy ra lỗi khi Xóa lớp học";
            }
        }
        private void AddNewClassEvent(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchClassEvent(object sender, EventArgs e)
        {
            bool emptyVal = string.IsNullOrEmpty(this.view.SearchValue);
            if (!emptyVal)
                classList = repository.GetByValue(this.view.SearchValue);
            else
                classList = repository.GetAll();
            classBindingSource.DataSource = classList;
        }
    }
}
