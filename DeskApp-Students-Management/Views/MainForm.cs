using DeskApp_Students_Management.Handle_Logic;
using DeskApp_Students_Management.Model;
using DeskApp_Students_Management.Properties;
using DeskApp_Students_Management.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskApp_Students_Management
{
    public partial class MainForm : Form,IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private ConnectDB database;

        public event EventHandler ShowStudentView;
        public event EventHandler ShowOwnerView;
        public event EventHandler ShowVetsView;
        public event EventHandler ShowAddDataView;

        private void btnTestQuery_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["DeskApp_Students_Management.Properties.Settings.SqlConnection"].ConnectionString;
            database = new ConnectDB(sqlConnectionString);
            bool flag = database.StartConnect();
        }

        private void statusPassChar_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = !txtPassword.PasswordChar;
            this.statusPassChar.BackgroundImageLayout = ImageLayout.Zoom;
            this.statusPassChar.BackgroundImage = !txtPassword.PasswordChar ?
                Properties.Resources.hiddenEye : Properties.Resources.eye;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            try
            {
                string query = "UPDATE userAdmin SET lastLogin = '" + DateTime.Now  +"' WHERE username = '" + txtUsername.Text + "'" +
                    "and passw = '" + txtPassword.Text + "'";
                SqlDataReader reader = database.QueryDatabase(query);
                if(reader.RecordsAffected != 0) 
                {                                     
                    MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    { ShowStudentView?.Invoke(this, EventArgs.Empty); };
                }
                else
                {
                    noticeFail.Text = "Sai tài khoản hoặc mật khẩu";
                }

            }
            catch (Exception)
            {

                noticeFail.Text = "Lỗi kỹ thuật ở database rồi kìa. Check lại đi";
                return;
            }
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
