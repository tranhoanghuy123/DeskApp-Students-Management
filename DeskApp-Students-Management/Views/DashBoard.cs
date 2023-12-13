using DeskApp_Students_Management._Repositories;
using DeskApp_Students_Management.Model;
using DeskApp_Students_Management.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPdf;
namespace DeskApp_Students_Management.Views
{
    public partial class DashBoard : Form,IStudentView,IClassView,ISubjectView,IPointView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;
         
        public string StudentID { get => txtID.Text; set => txtID.Text = value; }
        public string StudentName { get => txtName.Text; set => txtName.Text = value; }
        public string StudentAddress { get => txtAddress.Text; set => txtAddress.Text = value; }
        public string StudentClass { get => txtClass.Text; set => txtClass.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }
        public string ClassID { get => txtIDClass.Text; set => txtIDClass.Text = value; }
        public string ClassName { get => txtNameMajor.Text; set => txtNameMajor.Text = value; }
        public int SchoolYear { get => int.Parse(txtSchoolYear.Text); set => txtSchoolYear.Text = value.ToString(); }
        public string SubjectID { get => txtIDSubject.Text; set => txtIDSubject.Text = value; }
        public string SubjectName { get => txtNameSubject.Text; set => txtNameSubject.Text = value; }
        public int QtyCredit { get => int.Parse(txtQtyCredit.Text); set => txtQtyCredit.Text = value.ToString(); }
        public string SubjID { get => txtIDSubj.Text; set => txtIDSubj.Text = value; }
        public string NameSubject { get => txtNameSubject.Text; set => txtNameSubject.Text = value; }
        public float Score { get => float.Parse(txtPoint.Text); set => txtIDStudent.Text = value.ToString(); }
        public string IDStudent { get => txtIDStudent.Text; set => txtIDStudent.Text = value; }
        public string SearchValueStudentID { get =>txtValueSearchToExportPoint.Text; set => txtValueSearchToExportPoint.Text = value; }
        public bool IsSuccessfull { get => isSuccessful; set => isSuccessful = value; }

        private string sqlConnectionString = ConfigurationManager.ConnectionStrings["DeskApp_Students_Management.Properties.Settings.SqlConnection"].ConnectionString;
        public DashBoard()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabAddData);
            tabControl1.TabPages.Remove(tabReported);
        }     
        private void AssociateAndRaiseViewEvents()
        {
            //Search Event
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearchValue.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Add new Event
            btnAdd.Click += delegate 
            { 
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(listStudent);
                tabControl1.TabPages.Remove(tabReported);
                tabControl1.TabPages.Add(tabAddData);
                tabControlAdd.TabPages.Remove(tabAddClass);
                tabControlAdd.TabPages.Remove(tabAddSubject);
                tabControlAdd.TabPages.Remove(tabUpdatePoint);
                tabControlAdd.TabPages.Remove(tabViewResultAddClass);
            };
            btnAddStudent.Click += delegate
            {
                tabControlAdd.TabPages.Remove(tabAddStudent);
                tabControlAdd.TabPages.Add(tabAddStudent);
                tabControlAdd.TabPages.Remove(tabAddClass);
                tabControlAdd.TabPages.Remove(tabAddSubject);
                tabControlAdd.TabPages.Remove(tabUpdatePoint);
                tabControlAdd.TabPages.Remove(tabViewResultAddClass);
            };
            btnAddClass.Click += delegate
            {
                IClassView viewClass = GetInstance();
                IClassRepository repositoryClass = new ClassRepository(sqlConnectionString);
                new ClassPresenter(viewClass, repositoryClass);
                AddNewClassEvent?.Invoke(this, EventArgs.Empty);
                tabControlAdd.TabPages.Remove(tabAddClass);
                tabControlAdd.TabPages.Add(tabAddClass);
                tabControlAdd.TabPages.Remove(tabAddStudent);
                tabControlAdd.TabPages.Remove(tabAddSubject);
                tabControlAdd.TabPages.Remove(tabUpdatePoint);
                tabControlAdd.TabPages.Remove(tabViewResultAddClass);
                message = "";
            };
            btnAddSubject.Click += delegate
            {
                ISubjectView viewSubject = GetInstance();
                ISubjectRepository subjectRepository = new SubjectRepository(sqlConnectionString);
                new SubjectPresenter(viewSubject, subjectRepository);
                AddNewSubjectEvent?.Invoke(this, EventArgs.Empty);
                tabControlAdd.TabPages.Remove(tabAddSubject);
                tabControlAdd.TabPages.Add(tabAddSubject);
                tabControlAdd.TabPages.Remove(tabAddStudent);
                tabControlAdd.TabPages.Remove(tabAddClass);
                tabControlAdd.TabPages.Remove(tabUpdatePoint);
                tabControlAdd.TabPages.Remove(tabViewResultAddClass);
                message = "";
            };
            btnUpdatePoint.Click += delegate
            {
                IPointView viewPoint = GetInstance();
                IPointRepository pointRepository = new PointRepository(sqlConnectionString);
                new PointPresenter(pointRepository, viewPoint);
                AddNewPointEvent?.Invoke(this, EventArgs.Empty);
                tabControlAdd.TabPages.Remove(tabUpdatePoint);
                tabControlAdd.TabPages.Add(tabUpdatePoint);
                tabControlAdd.TabPages.Remove(tabAddStudent);
                tabControlAdd.TabPages.Remove(tabAddClass);
                tabControlAdd.TabPages.Remove(tabAddSubject);
                tabControlAdd.TabPages.Remove(tabViewResultAddClass);
                message = "";
            };
            //Edit Event
            btnEdit.Click += delegate 
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                
                //EditSubjectEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(listStudent);
                tabControl1.TabPages.Remove(tabReported);
                tabControl1.TabPages.Add(tabAddData);
                tabControlAdd.TabPages.Remove(tabAddClass);
                tabControlAdd.TabPages.Remove(tabAddSubject);
                tabControlAdd.TabPages.Remove(tabUpdatePoint);
                tabControlAdd.TabPages.Remove(tabViewResultAddClass);
            };
            
            //Delete Event
            btnDelete.Click += delegate 
            { 
                var result = MessageBox.Show("Bạn có chắc là muốn xóa sinh viên này không?", "Cảnh báo!", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            //Save  Event
            btnSave.Click += delegate 
            { 
                SaveEvent?.Invoke(this, EventArgs.Empty); 
                if(isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabAddData);
                    tabControl1.TabPages.Remove(tabReported);
                    tabControl1.TabPages.Add(listStudent);
                }
                MessageBox.Show(Message);
            };
            btnSaveAddClass.Click += delegate 
            { 
                SaveClassEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControlAdd.TabPages.Remove(tabAddClass);
                    tabControlAdd.TabPages.Add(tabViewResultAddClass);
                }
                MessageBox.Show(Message);
            };
            btnSaveAddSubj.Click += delegate 
            {              
                SaveSubjectEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {                  
                    tabControlAdd.TabPages.Remove(tabAddSubject);
                    tabControlAdd.TabPages.Add(tabViewResultAddClass);
                }
                MessageBox.Show(Message);
            };
            btnSaveAddPoint.Click += delegate
            {
                SavePointEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControlAdd.TabPages.Remove(tabUpdatePoint);
                    tabControlAdd.TabPages.Add(tabViewResultAddClass);
                }
                MessageBox.Show(Message);
            };
            //Cancel Event
            btnCancel.Click += delegate 
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabAddData);
                tabControl1.TabPages.Add(listStudent);
            };
            btnCancelAddClass.Click += delegate 
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabAddData);
                tabControl1.TabPages.Add(listStudent);
            };
            btnCancelAddPoint.Click += delegate 
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabAddData);
                tabControl1.TabPages.Add(listStudent);
            };
            btnCancelAddSubj.Click += delegate 
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabAddData);
                tabControl1.TabPages.Add(listStudent);
            };
        }
        //Event Student
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ReportedEvent;
        //Event Class
        public event EventHandler SearchClassEvent;
        public event EventHandler AddNewClassEvent;
        public event EventHandler DeleteClassEvent;
        public event EventHandler SaveClassEvent;
        public event EventHandler CancelClassEvent;
        public event EventHandler ReportedClassEvent;
        //Event Subject
        public event EventHandler SearchSubjectEvent;
        public event EventHandler AddNewSubjectEvent;
        public event EventHandler DeleteSubjectEvent;
        public event EventHandler SaveSubjectEvent;
        public event EventHandler CancelSubjectEvent;
        public event EventHandler ReportSubjectEvent;
        //Event point
        public event EventHandler SearchPointEvent;
        public event EventHandler AddNewPointEvent;
        public event EventHandler SavePointEvent;
        public event EventHandler CancelPointEvent;
        public event EventHandler ReportedPointEvent;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] procs = Process.GetProcessesByName("DeskApp-Students-Management");
            foreach(Process process in procs)
            {
                process.Kill();
            }
        }
        public void SetStudentListBindingSource(BindingSource studentList)
        {
            viewAllStudents.DataSource = studentList;
            bindingSourceStudentList = studentList;
        }

        // Singleton patten(open a single form instance)
        private static DashBoard instance;
        public static DashBoard GetInstance()
        {
            if(instance == null || instance.IsDisposed)
                instance = new DashBoard();
            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();

            }
            return instance;
        }
        private BindingSource bindingSourceClassList;
        private BindingSource bindingSourceSubjectList;
        private BindingSource bindingSourcePointList;
        private BindingSource bindingSourceStudentList;
        private BindingSource bindingSourseScoreOfStudentList = new BindingSource() ;
        public void SetClassListBindingSource(BindingSource classList)
        {
            dataViewResultAddClass.DataSource = classList;
            bindingSourceClassList = classList;
        }

        public void SetSubjectBindingSource(BindingSource subjectList)
        {
            dataViewResultAddClass.DataSource = subjectList;
            bindingSourceSubjectList = subjectList;
        }

        public void SetPointListBindingSource(BindingSource pointList)
        {
            dataViewResultAddClass.DataSource = pointList;
            bindingSourcePointList = pointList;
        }
        private GetDataScoreOfStudent scoreStudent;
        private InforStudentExportRepository inforStudentExportRepository;
        private IEnumerable<ScoreOfStudentModel> scoreList = new List<ScoreOfStudentModel>();
        private IEnumerable<InforStudentExportModel> listInforStudent  = new List<InforStudentExportModel>();
        private void btnWriteReported_Click(object sender, EventArgs e)
        {
            // Config UI
            tabControl1.TabPages.Remove(tabReported);
            tabControl1.TabPages.Add(tabReported);
            tabReportInfor.TabPages.Remove(tabReportedScoreStudent);
            tabReportInfor.TabPages.Add(tabReportedScoreStudent);
            tabControl1.TabPages.Remove(tabAddData);
            tabControl1.TabPages.Remove(listStudent);
            tabReportInfor.TabPages.Remove(tabReportedSubjectList);
            tabReportInfor.TabPages.Remove(tabReportedClassList);
            tabReportInfor.TabPages.Remove(tabReportStudentByClass);
            scoreStudent = new GetDataScoreOfStudent(sqlConnectionString);
            scoreList = scoreStudent.GetAllData();
            dataViewScoreStudent.DataSource = scoreList;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Config UI
            tabControl1.TabPages.Add(listStudent);
            tabControl1.TabPages.Remove(tabAddData);
            tabControl1.TabPages.Remove(tabReported);
        }

        private void btnExportPoint_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabReported);
            tabControl1.TabPages.Add(tabReported);
            tabReportInfor.TabPages.Remove(tabReportedScoreStudent);
            tabReportInfor.TabPages.Add(tabReportedScoreStudent);
            tabControl1.TabPages.Remove(tabAddData);
            tabControl1.TabPages.Remove(listStudent);
            tabReportInfor.TabPages.Remove(tabReportedSubjectList);
            tabReportInfor.TabPages.Remove(tabReportedClassList);
            tabReportInfor.TabPages.Remove(tabReportStudentByClass);
            scoreStudent = new GetDataScoreOfStudent(sqlConnectionString);
            scoreList = scoreStudent.GetAllData();
            dataViewScoreStudent.DataSource = scoreList;
        }
        private void btnSearchToExportPoint_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtValueSearchToExportPoint.Text)) // if search text box is null then get all data
            {
                scoreList = scoreStudent.GetAllData();
            }
            else
            {
                scoreList = scoreStudent.GetDataByValue(txtValueSearchToExportPoint.Text);
            }
            dataViewScoreStudent.DataSource = scoreList;
        }

        private void btnExportReportedPoint_Click(object sender, EventArgs e)
        {
            scoreStudent.ExportedPDF(scoreList, txtValueSearchToExportPoint.Text);
        }
        // Báo cáo tất cả lớp học
        private void btnExportClasses_Click(object sender, EventArgs e)
        {
            // Config UI
            tabReportInfor.TabPages.Remove(tabReportedClassList);
            tabReportInfor.TabPages.Add(tabReportedClassList);
            tabReportInfor.TabPages.Remove(tabReportedSubjectList);
            tabReportInfor.TabPages.Remove(tabReportedScoreStudent);
            tabReportInfor.TabPages.Remove(tabReportStudentByClass);
            //Set data source to view
            dataViewClassList.DataSource = bindingSourceClassList;
        }
        // Event export PDF
        private void btnExportClassList_Click(object sender, EventArgs e)
        {
            ClassRepository repository = new ClassRepository(sqlConnectionString);
            repository.ExportedPDF();
        }

        // Báo cáo tất cả môn học  
        private void btnExportSubjects_Click(object sender, EventArgs e)
        {
            // Config UI
            tabReportInfor.TabPages.Remove(tabReportedSubjectList);
            tabReportInfor.TabPages.Add(tabReportedSubjectList);
            tabReportInfor.TabPages.Remove(tabReportedScoreStudent);
            tabReportInfor.TabPages.Remove(tabReportedClassList);
            tabReportInfor.TabPages.Remove(tabReportStudentByClass);
            //Set data source to view
            dataViewsAllSubjects.DataSource = bindingSourceSubjectList;
        }
        // Event export PDF
        private void btnExportAllSubjects_Click(object sender, EventArgs e)
        {
            SubjectRepository repository = new SubjectRepository(sqlConnectionString);
            repository.ExportedPDF();
        }

        // Báo cáo sinh viên theo mã lớp 

        private void btnExportStudents_Click(object sender, EventArgs e)
        {
            // Config UI
            tabReportInfor.TabPages.Remove(tabReportStudentByClass);
            tabReportInfor.TabPages.Add(tabReportStudentByClass);
            tabReportInfor.TabPages.Remove(tabReportedSubjectList);
            tabReportInfor.TabPages.Remove(tabReportedClassList);
            tabReportInfor.TabPages.Remove(tabReportedScoreStudent);
            inforStudentExportRepository = new InforStudentExportRepository(sqlConnectionString);
            listInforStudent = inforStudentExportRepository.GetAllData();
            dataViewStudentsByClass.DataSource = listInforStudent;
        }


        private void btnSearchStudentByClass_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtValueIDClassToExport.Text))
            {
                listInforStudent = inforStudentExportRepository.GetAllData();
            }
            else
            {
                listInforStudent = inforStudentExportRepository.GetDataByValue(txtValueIDClassToExport.Text);
            }
            dataViewStudentsByClass.DataSource = listInforStudent;
        }
        //Event export PDF
        private void btnExportStudentsByClass_Click(object sender, EventArgs e)
        {
            inforStudentExportRepository.ExportedPDF(listInforStudent, txtValueIDClassToExport.Text);
        }

    }
}
