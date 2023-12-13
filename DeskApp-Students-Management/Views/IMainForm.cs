using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Views
{
    public interface IMainForm
    {
        event EventHandler ShowStudentView;
        event EventHandler ShowOwnerView;
        event EventHandler ShowVetsView;
        event EventHandler ShowAddDataView;
    }
}
