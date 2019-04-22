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

        // Button to sign in
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Setting users text to static varibles in user class
            _user.User = txtUser.Text;
            _user.Password = txtPassword.Text;
            
            //SQL login function, sending user and password
            float accLogin = _DBMethods.AccountLogin(_user.User, _user.Password);
            //if admin and successfull
            if (accLogin == 2 && _user.User == "admin")
            {
                MessageBox.Show(_user.User + " has succefully logged in");
                this.Hide();
                clearboxes();
                _frmAdmin.ShowDialog();
                this.Show();
            }
            //if successfull
            else if (accLogin == 2)
            {
                MessageBox.Show(_user.User + " Has succefully logged in");
                this.Hide();
                clearboxes();
                _frmHub.ShowDialog();
                this.Show();
            }
            //if Password is wrong
            else if (accLogin == 1)
            {MessageBox.Show("Incorrect password");}
            //if Username is wrong
            else
            { MessageBox.Show("Incorrect Username");}
        }

        //Button to create account
        private void btnCreateAccount_Click_1(object sender, EventArgs e)
        {
            //Setting users text to static varibles in user class
            _user.User = txtUser.Text;
            _user.Password = txtPassword.Text;
            if (_user.Password.Length >= 8)
            {
                //SQL Create account, sending user and password
                byte accRegister = _DBMethods.AccountRegister(_user.User, _user.Password, "0");
                //Successful
                if (accRegister == 1)
                {
                    MessageBox.Show(_user.User + " has succefully been created", "login successful");
                    this.Hide();
                    clearboxes();
                    _frmHub.ShowDialog();
                    this.Show();

                }
                //Failed
                else
                { MessageBox.Show("That username has already been taken"); }
            }

            // if user's password is too short
            else
            { MessageBox.Show("Password must be a minimum of 8"); }
            
        }

        //Clear Text Boxes
        public void clearboxes()
        {
            txtUser.Text = null;
            txtPassword.Text = null;
        }
    }
}

