using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeskApp_Students_Management.Views;
using DeskApp_Students_Management.Model;
using DeskApp_Students_Management._Repositories;
using System.Runtime.CompilerServices;

namespace DeskApp_Students_Management.Presenters
{
    public class MainFormPresenter
    {
        private IMainForm mainForm;
        private readonly string sqlConnectionString;

        public MainFormPresenter(IMainForm mainForm, string sqlConnectionString)
        {
            this.mainForm = mainForm;
            this.sqlConnectionString = sqlConnectionString;
            this.mainForm.ShowStudentView += ShowStudentView;
            this.mainForm.ShowAddDataView += ShowAddDataView;
        }

        private void ShowAddDataView(object sender, EventArgs e)
        {
            
        }

        private void ShowStudentView(object sender, EventArgs e)
        {
            // Student view
            IStudentView view =  DashBoard.GetInstance();
            IStudentRepository repository = new StudentRepository(sqlConnectionString);
            new StudentPresenter(view, repository);

            IClassView viewClass = DashBoard.GetInstance();
            IClassRepository repositoryClass = new ClassRepository(sqlConnectionString);
            new ClassPresenter(viewClass, repositoryClass);

            ISubjectView viewSubject = DashBoard.GetInstance();
            ISubjectRepository subjectRepository = new SubjectRepository(sqlConnectionString);
            new SubjectPresenter(viewSubject, subjectRepository);

            IPointView viewPoint = DashBoard.GetInstance();
            IPointRepository pointRepository = new PointRepository(sqlConnectionString);
            new PointPresenter(pointRepository, viewPoint);
        }
    }
}
