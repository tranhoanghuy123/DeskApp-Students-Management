using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management.Views
{
    public interface IPointView
    {
        // Text fields
        string IDStudent { get; set; }
        string SubjID { get; set; }
        string NameSubject { get; set; }   
        float Score { get; set; }
        string SearchValue { get; set; }
        // Storage events
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        // Events handle
        event EventHandler SearchPointEvent;
        event EventHandler AddNewPointEvent;
        event EventHandler SavePointEvent;
        event EventHandler CancelPointEvent;
        event EventHandler ReportedPointEvent;

        // Set data source
        void SetPointListBindingSource(BindingSource pointList);
        // method show optional
        void Show();

    }
}
