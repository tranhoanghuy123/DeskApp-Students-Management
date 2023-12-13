using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management.Views
{
    public interface ISubjectView
    {
        //Properties
        string SubjectID { get; set; }
        string SubjectName { get; set; }
        int QtyCredit {  get; set; }
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // Handle event
        event EventHandler SearchSubjectEvent;
        event EventHandler AddNewSubjectEvent;
        event EventHandler DeleteSubjectEvent;
        event EventHandler SaveSubjectEvent;
        event EventHandler CancelSubjectEvent;
        event EventHandler ReportSubjectEvent;

        // Methods
        void SetSubjectBindingSource(BindingSource subjectList);
        void Show();

    }
}
