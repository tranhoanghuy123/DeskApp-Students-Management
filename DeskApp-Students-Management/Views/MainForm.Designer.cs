namespace DeskApp_Students_Management
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.containerHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IconApp = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.statusPassChar = new System.Windows.Forms.PictureBox();
            this.btnLogin = new Quiz_Project.CustomButton();
            this.noticeFail = new System.Windows.Forms.Label();
            this.txtPassword = new Quiz_Project.LoginControl();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtUsername = new Quiz_Project.LoginControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.containerHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusPassChar)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerHeader
            // 
            this.containerHeader.BackColor = System.Drawing.Color.Turquoise;
            this.containerHeader.Controls.Add(this.btnClose);
            this.containerHeader.Controls.Add(this.label1);
            this.containerHeader.Controls.Add(this.IconApp);
            this.containerHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerHeader.Location = new System.Drawing.Point(0, 0);
            this.containerHeader.Name = "containerHeader";
            this.containerHeader.Size = new System.Drawing.Size(738, 28);
            this.containerHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::DeskApp_Students_Management.Properties.Resources.CloseBtn;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(705, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(36, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Sinh Viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IconApp
            // 
            this.IconApp.BackgroundImage = global::DeskApp_Students_Management.Properties.Resources.logo;
            this.IconApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IconApp.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconApp.Location = new System.Drawing.Point(0, 0);
            this.IconApp.Name = "IconApp";
            this.IconApp.Size = new System.Drawing.Size(36, 28);
            this.IconApp.TabIndex = 0;
            this.IconApp.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 35);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::DeskApp_Students_Management.Properties.Resources.img_login;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 308);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(298, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 308);
            this.panel3.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.statusPassChar);
            this.panel7.Controls.Add(this.btnLogin);
            this.panel7.Controls.Add(this.noticeFail);
            this.panel7.Controls.Add(this.txtPassword);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.txtUsername);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(106, 112);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(316, 196);
            this.panel7.TabIndex = 5;
            // 
            // statusPassChar
            // 
            this.statusPassChar.BackgroundImage = global::DeskApp_Students_Management.Properties.Resources.eye;
            this.statusPassChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statusPassChar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statusPassChar.Location = new System.Drawing.Point(292, 66);
            this.statusPassChar.Name = "statusPassChar";
            this.statusPassChar.Size = new System.Drawing.Size(24, 30);
            this.statusPassChar.TabIndex = 5;
            this.statusPassChar.TabStop = false;
            this.statusPassChar.Click += new System.EventHandler(this.statusPassChar_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 10;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(0, 124);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(316, 50);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseHover += new System.EventHandler(this.btnLogin_MouseHover);
            // 
            // noticeFail
            // 
            this.noticeFail.Dock = System.Windows.Forms.DockStyle.Top;
            this.noticeFail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noticeFail.ForeColor = System.Drawing.Color.Firebrick;
            this.noticeFail.Location = new System.Drawing.Point(0, 99);
            this.noticeFail.Name = "noticeFail";
            this.noticeFail.Size = new System.Drawing.Size(316, 25);
            this.noticeFail.TabIndex = 3;
            this.noticeFail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.BoderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtPassword.BoderFocusColor = System.Drawing.Color.HotPink;
            this.txtPassword.BoderSize = 2;
            this.txtPassword.BorderRadius = 0;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(0, 60);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PasswordChar = true;
            this.txtPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPassword.PlaceholderText = "123456789";
            this.txtPassword.Size = new System.Drawing.Size(316, 39);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UderlinedStyle = true;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 39);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(316, 21);
            this.panel9.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.BoderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtUsername.BoderFocusColor = System.Drawing.Color.HotPink;
            this.txtUsername.BoderSize = 2;
            this.txtUsername.BorderRadius = 0;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(0, 0);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUsername.PlaceholderText = "Type username here ...";
            this.txtUsername.Size = new System.Drawing.Size(316, 39);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.UderlinedStyle = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 112);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(106, 196);
            this.panel6.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 39);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mật khẩu:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 39);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(106, 21);
            this.panel8.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tài khoản:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 69);
            this.label2.TabIndex = 3;
            this.label2.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(422, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(18, 265);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(440, 43);
            this.panel4.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 371);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.containerHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sinh Viên";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.containerHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusPassChar)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel containerHeader;
        private System.Windows.Forms.PictureBox IconApp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private Quiz_Project.LoginControl txtUsername;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private Quiz_Project.CustomButton btnLogin;
        private System.Windows.Forms.Label noticeFail;
        private Quiz_Project.LoginControl txtPassword;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox statusPassChar;
    }
}

