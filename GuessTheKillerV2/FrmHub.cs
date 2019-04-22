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
    public partial class FrmHub : Form
    {
        private clsDBMethods _DBMethods = new clsDBMethods();
        private string name = clsUser._User;

        public FrmHub()
        {
            InitializeComponent();
            lstPlayers.DataSource = null;
        }

        private void FrmHub_Load(object sender, EventArgs e)
        {
            name = clsUser._User;
            lstPlayers.DataSource = _DBMethods.ShowPlayersOnline(name);
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            byte lcResult = _DBMethods.AccountLogOff(name);
            if (lcResult == 1)
            {
                MessageBox.Show(name + " has logged of");
                this.Close();

            }
        }
    }
}
