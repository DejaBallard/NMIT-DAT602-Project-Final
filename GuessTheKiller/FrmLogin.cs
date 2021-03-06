﻿using System;
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
        private clsUser _user = new clsUser();
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
            if (accLogin == 1 && _user.User == "Admin")
            {
                MessageBox.Show(_user.User + " Has succefully logged in");
                _frmAdmin.ShowDialog();
            }
            else if (accLogin == 1)
            {
                MessageBox.Show(_user.User + " Has succefully logged in");
                _frmHub.ShowDialog();
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
            byte accRegister = _DBMethods.AccountRegister(_user.User, _user.Password);
            if (accRegister == 1)
            {
                MessageBox.Show(_user.User + " has succefully been created");
                _frmHub.ShowDialog();
            }
            else
            {
                MessageBox.Show("That username has already been taken");
            }
        }
    }
}

