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
    public class PointPresenter
    {
        private IPointRepository repository;
        private IPointView view;
        BindingSource pointBindingSource;
        IEnumerable<PointModel> pointList;

        public PointPresenter(IPointRepository repository, IPointView view)
        {
            // Started base view 
            this.repository = repository;
            this.view = view;
            // Init binding source
            this.pointBindingSource = new BindingSource();
            // Init Events handle
            this.view.AddNewPointEvent += AddNewPointEvent;
            this.view.SavePointEvent += SavePointEvent;
            this.view.SearchPointEvent += SearchPointEvent;
            this.view.CancelPointEvent += CancelPointEvent;
            //Set point binding source
            this.view.SetPointListBindingSource(pointBindingSource);
            LoadAllSelected();
            // Show view
            this.view.Show();
        }
        private void CleanViewFields()
        {
            view.IDStudent = "";
            view.SubjID = "";
            view.Score = 0;
        }
        private void LoadAllSelected()
        {
            this.pointList = repository.GetAll();
            this.pointBindingSource.DataSource = pointList; // Set data to view
        }

        private void CancelPointEvent(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SearchPointEvent(object sender, EventArgs e)
        {
            bool emptyVal = string.IsNullOrEmpty(this.view.SearchValue);
            if (!emptyVal)
                pointList = repository.GetByValue(this.view.SearchValue);
            else
                pointList = repository.GetAll();
            pointBindingSource.DataSource = pointList;
        }

        private void SavePointEvent(object sender, EventArgs e)
        {
            var pointModel = new PointModel();
            pointModel.IdSubject = view.SubjID;
            pointModel.IdStudent = view.IDStudent;
            pointModel.Score = view.Score;
            pointModel.NameSubject = view.NameSubject;
            try
            {
                new Common.ModelDataValidation().Validate(pointModel);
                if(repository.FindPointFromDB(pointModel.IdSubject,pointModel.IdStudent))
                {
                    repository.Edit(pointModel);
                    view.Message = "Cập nhật điểm cho sinh viên thành công";
                }
                else
                {
                    repository.Add(pointModel);
                    view.Message = "Cập nhật điểm cho sinh viên thành công";
                }
                view.IsSuccessful = true;
                LoadAllSelected();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void AddNewPointEvent(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
    }
}
