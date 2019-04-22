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
        static string _request;
        static int _requestTimer;
        private clsDBMethods _DBMethods = new clsDBMethods();
        private string _CurrentUser = clsUser._User;
        public FrmGame _frmGame = new FrmGame();

        public FrmHub()
        {
            InitializeComponent();
            //makes listbox double clickable
            lstPlayers.MouseDoubleClick += new MouseEventHandler(lstPlayers_DoubleClick);
            //Empty listbox
            lstPlayers.DataSource = null;
            lstChat.DataSource = null;
        }

        //When form is loading
        private void FrmHub_Load(object sender, EventArgs e)
        {
            _CurrentUser = clsUser._User;

            this.Text = ("Welcome " + _CurrentUser + " to the hub");
            //SQL showing players online apart from current user then display on list
            lstPlayers.DataSource = _DBMethods.ShowPlayersOnline(_CurrentUser);
            //Start update timer
            tmrUpdate.Start();
        }

        //Button to log off
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            //SQL set users status to offline
            byte lcResult = _DBMethods.AccountLogOff(_CurrentUser);
            if (lcResult == 1)
            {
                MessageBox.Show(_CurrentUser + " has logged off");
                this.Close();

            }
        }

        //Update timer - do this every two secounds
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            //Check to see if current user has been sent a game request
            clsUser._Oppname = _DBMethods.HaveRequest(_CurrentUser);

            //if true
            if (clsUser._Oppname != "")
            {
                tmrUpdate.Stop();
                //sql sending request. set null on current user
                _DBMethods.GameRequest("", _CurrentUser);
                DialogResult dialogResult = MessageBox.Show("You have been sent a game _request from " + clsUser._Oppname + ". Would you like to join?", "Game Request", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tmrUpdate.Stop();
                    _DBMethods.GameRequest(_CurrentUser, clsUser._Oppname);
                    _DBMethods.CreateGame(clsUser._Oppname, _CurrentUser);
                    _DBMethods.SetStatus(_CurrentUser, "3");
                    this.Hide();
                    _frmGame.ShowDialog();
                    this.Show();
                    tmrUpdate.Start();
                }
                tmrUpdate.Start();
            }
            //Update players online list with sql function then display on list
            lstPlayers.DataSource = _DBMethods.ShowPlayersOnline(_CurrentUser);
        }

        //Double click a player
        private void lstPlayers_DoubleClick(object sender, MouseEventArgs e)
        {
            //Get selected opponents name
            clsUser._Oppname = _DBMethods.GetSelectedName(lstPlayers);
            //Get selected opponents status
            string OppStatus = _DBMethods.GetSelectedStatus(lstPlayers);
            if (OppStatus == "online")
            {
                //sql sending request. set current user on opp user
                _DBMethods.GameRequest(_CurrentUser, clsUser._Oppname);
                tmrUpdate.Stop();
                DialogResult dialogResult = MessageBox.Show(clsUser._Oppname + " has been sent a game _request. Click okay and please wait", "Game Request Sent");
                IsRequest();
                if (_request != null)
                {
                    _DBMethods.GameRequest("", _CurrentUser);
                    MessageBox.Show("Successfully connected to " + clsUser._Oppname, "Accepted Connection");
                    _DBMethods.SetStatus(_CurrentUser, "3");
                    this.Hide();
                    _frmGame.ShowDialog();
                    this.Show();
                    tmrUpdate.Start();
                }
                else
                {
                    MessageBox.Show("sorry " + clsUser._Oppname + " did not accept", "Declined Connection");
                    tmrUpdate.Start();
                }
            }
            else
                MessageBox.Show(clsUser._Oppname + " is currently busy", "User is Busy");
        }

        public void IsRequest()
        {
            _request = null;
            do
            {
                _requestTimer += 1;
                _request = _DBMethods.HaveRequest(_CurrentUser);
            }
            while ((_requestTimer < 200000) && (_request == ""));
            _requestTimer = 0;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            _DBMethods.InsertComment(_CurrentUser, txtChatBox.Text);
            txtChatBox.Text = "";
        }

        private void tmrChat_Tick(object sender, EventArgs e)
        {
            lstChat.DataSource = _DBMethods.ShowChat();

            if (lstChat.Items.Count == 10)
            {
                //Waits a random amount of time before deleting comments from table, because if two instances try to delete records at once, it will crash the game.
                Random rnd = new Random();
                tmrWait.Interval = rnd.Next(100, 300);
                tmrWait.Start();
            }
        }
        private void tmrWait_Tick(object sender, EventArgs e)
        {
            _DBMethods.DeleteComments();
            tmrWait.Stop();
        }
    }
    }



