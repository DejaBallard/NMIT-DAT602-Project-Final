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
    public partial class FrmPlayer : Form
    {
        string _newAccName;
        string _newAccPassword;
        string _newAccScore;

        clsDBMethods _DBMethods = new clsDBMethods();

        public FrmPlayer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _newAccName = txtAccName.Text;
            _newAccPassword = txtPassword.Text;
            _newAccScore = txtScore.Text;
            if (clsUser._AdminEditName != null)
            {
                _DBMethods.UpdateAccount(_newAccName, _newAccPassword, _newAccScore);
                MessageBox.Show(_newAccName + "'s account has been updated");
                this.Close();
            }
            else
            {
                byte lcResult = _DBMethods.AccountRegister(_newAccName, _newAccPassword, _newAccScore);
                if (lcResult == 1)
                {
                    MessageBox.Show(_newAccName + " has been created");
                    this.Close();
                }
                else MessageBox.Show("this account name has already been taken");
            }
        }

        private void FrmPlayer_Load(object sender, EventArgs e)
        {
            if (clsUser._AdminEditName != null)
            {
                txtAccName.Text = clsUser._AdminEditName;
                txtAccName.Enabled = false;
                txtScore.Text =  Convert.ToString(_DBMethods.GetScore(clsUser._AdminEditName));
            }
            else
            {
                txtAccName.Enabled = true;
                txtAccName.Text = null;
                txtPassword.Text = null;
                txtScore.Text = null;
                  }
        }
    }
}
