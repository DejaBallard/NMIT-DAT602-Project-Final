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
        private string _CurrentUser = clsUser._User;

        public FrmHub()
        {
            InitializeComponent();
            lstPlayers.MouseDoubleClick += new MouseEventHandler(lstPlayers_DoubleClick);
            lstPlayers.DataSource = null;
        }

        private void FrmHub_Load(object sender, EventArgs e)
        {
            _CurrentUser = clsUser._User;
            this.Text = ("Welcome " + _CurrentUser);
            lstPlayers.DataSource = _DBMethods.ShowPlayersOnline(_CurrentUser);
            tmrUpdate.Start();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            byte lcResult = _DBMethods.AccountLogOff(_CurrentUser);
            if (lcResult == 1)
            {
                MessageBox.Show(_CurrentUser + " has logged off");
                
                this.Close();

            }
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            string lcname = _DBMethods.GetSelectedName(lstPlayers);
            MessageBox.Show(lcname);
            _DBMethods.GameRequest(lcname,"1");
            //if yes, show a message box of do u have to join game,
            //if yes start game.
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            byte lcResult = _DBMethods.HaveRequest(_CurrentUser);
            if (lcResult == 1)
            {
                _DBMethods.GameRequest(_CurrentUser, "0");
                DialogResult dialogResult = MessageBox.Show("You have been sent a game request. Would you like to join?","Game Request", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                }

            }
            lstPlayers.DataSource = _DBMethods.ShowPlayersOnline(_CurrentUser);
        }
        private void lstPlayers_DoubleClick(object sender, MouseEventArgs e)
        {
            string lcname = _DBMethods.GetSelectedName(lstPlayers);
            MessageBox.Show(lcname);
            _DBMethods.GameRequest(lcname, "1");
        }

            }
        }
    

