using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheKiller
{
    public partial class FrmLogin : Form
    {
        FrmHub _frmHub = new FrmHub();
        private clsDBMethods _DBMethods = new clsDBMethods();
        public clsUser _user = new clsUser();
        FrmAdmin _frmAdmin = new FrmAdmin();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            _user.User = txtUser.Text;
            _user.Password = txtPassword.Text;
            byte accLogin = _DBMethods.AccountLogin(_user.User, _user.Password);
            if (accLogin == 1 && _user.User == "admin")
            {
                MessageBox.Show(_user.User + " has succefully logged in");
                this.Hide();
                clearboxes();
                _frmAdmin.ShowDialog();
                this.Show();
            }
            else if (accLogin == 1)
            {
                MessageBox.Show(_user.User + " Has succefully logged in");
                this.Hide();
                clearboxes();
                _frmHub.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("The information you have entered is incorrect");
            }
        }

        private void btnCreateAccount_Click_1(object sender, EventArgs e)
        {
            _user.User = txtUser.Text;
            _user.Password = txtPassword.Text;
            byte accRegister = _DBMethods.AccountRegister(_user.User, _user.Password,"0");
            if (accRegister == 1)
            {
                MessageBox.Show(_user.User + " has succefully been created");
                this.Hide();
                clearboxes();
                _frmHub.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("That username has already been taken");
            }
        }

        public void clearboxes()
        {
            txtUser.Text = null;
            txtPassword.Text = null;
        }
    }
}

