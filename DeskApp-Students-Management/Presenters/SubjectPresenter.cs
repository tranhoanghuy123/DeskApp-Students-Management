using DeskApp_Students_Management._Repositories;
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
    public class SubjectPresenter
    {
        // Fields
        private ISubjectView view;
        private ISubjectRepository repository;
        private BindingSource bindingSourceSubjects;
        private IEnumerable<SubjectModel> subjectList;

        // Constructor init view and event handle ... 
        public SubjectPresenter(ISubjectView view, ISubjectRepository repository)
        {
            // Set view and get text fields
            this.bindingSourceSubjects = new BindingSource();
            this.view = view;
            this.repository = repository;
            // Init Event handle
            this.view.SearchSubjectEvent += SearchSubjectEvent;
            this.view.AddNewSubjectEvent += AddNewSubjectEvent;
            this.view.DeleteSubjectEvent += DeleteSubjectEvent;
            this.view.SaveSubjectEvent += SaveSubjectEvent;
            this.view.CancelSubjectEvent += CancelSubjectEvent;
            this.view.ReportSubjectEvent += AddNewSubjectEvent;
            // Set data subject binding source
            this.view.SetSubjectBindingSource(bindingSourceSubjects);
            //Load data subjects
            LoadAllSubjectList();
            //Show view
            this.view.Show();
        }

        private void LoadAllSubjectList()
        {
            subjectList = repository.GetAll();
            bindingSourceSubjects.DataSource = subjectList; // Set data source
        }
        private void CleanViewFields()
        {
            view.SubjectID = "";
            view.SubjectName = "";
            view.QtyCredit = 0;
        }
        private void CancelSubjectEvent(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveSubjectEvent(object sender, EventArgs e)
        {
            var model = new SubjectModel();
            model.IdSubject = view.SubjectID;
            model.NameSubject = view.SubjectName;
            model.QtyCredit = view.QtyCredit;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if(repository.FindSubjectFromDB(model.IdSubject))
                {
                    repository.Edit(model);
                    view.Message = "Sửa Thông Tin Môn Học Thành Công";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Thêm Môn Học Thành Công";
                }
                view.IsSuccessful = true;
                LoadAllSubjectList();
                CleanViewFields();
            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void DeleteSubjectEvent(object sender, EventArgs e)
        {
            try
            {
                var subjectModel = (SubjectModel)bindingSourceSubjects.Current;
                repository.Delete(subjectModel.IdSubject);
                view.IsSuccessful = true;
                view.Message = "Xóa lớp học thành công";
                LoadAllSubjectList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = true;
                view.Message = "Đã xảy ra lỗi khi Xóa môn học";
            }
        }

        private void AddNewSubjectEvent(object sender, EventArgs e)
        {
            this.view.IsEdit = false;
        }

        private void SearchSubjectEvent(object sender, EventArgs e)
        {
            bool emptyVal = string.IsNullOrEmpty(this.view.SearchValue);
            if (!emptyVal)
                subjectList = repository.GetByValue(this.view.SearchValue);
            else
                subjectList = repository.GetAll();
            bindingSourceSubjects.DataSource = subjectList;
        }
    }
}
