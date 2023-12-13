using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management.Views
{
    public interface IClassView
    {
        string ClassID { get; set; }
        string ClassName { get; set; }
        int SchoolYear { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // Events
        event EventHandler SearchClassEvent;
        event EventHandler AddNewClassEvent;
        event EventHandler DeleteClassEvent;
        event EventHandler SaveClassEvent;
        event EventHandler CancelClassEvent;
        event EventHandler ReportedClassEvent;


        // Methods
        void SetClassListBindingSource(BindingSource classList);
        void Show(); // Optional
    }
}
