using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management.Views
{
    public  interface IStudentView
    {
        string StudentID { get; set; }
        string StudentName { get; set; }
        string StudentAddress { get; set; }
        string StudentClass { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; } 
        string Message { get; set; }

        // Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler ReportedEvent;


        // Methods
        void SetStudentListBindingSource(BindingSource studentList);
        void Show(); // Optional
    }
}
