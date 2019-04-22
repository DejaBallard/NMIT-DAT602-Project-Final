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
    public partial class FrmAdmin : Form
    {
        clsDBMethods _DBMethods = new clsDBMethods();
        FrmPlayer _frmPlayer = new FrmPlayer();
        

        public FrmAdmin()
        {
            InitializeComponent();
        }

        //While form is loading
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            UpdateLists();
        }

        private void UpdateLists()
        {
            lstPlayers.DataSource = null;
            //SQL showing all players then display on list
            lstPlayers.DataSource = _DBMethods.AdminShowPlayers("");
            lstGames.DataSource = null;
            //SQL showing all games currently going then display on list
            lstGames.DataSource = _DBMethods.AdminShowGames();
        }

        //Button to create a new account
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //set name to null
            clsUser._AdminEditName = null;
            _frmPlayer.ShowDialog();
            //SQL showing all games currently going then display on list
            lstPlayers.DataSource = _DBMethods.AdminShowPlayers("");
        }

        //Button to edit selected account
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //SQL of getting selected name and setting it to name
            clsUser._AdminEditName = _DBMethods.AdminGetSelectedName(lstPlayers);
            _frmPlayer.ShowDialog();
        }

        //Button to delete selected account
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //SQL of getting selected name and setting it to name
            clsUser._AdminEditName = _DBMethods.AdminGetSelectedName(lstPlayers).ToString();

            //message box asking if they want to delete
            DialogResult dialogResult = MessageBox.Show("Are you sure you want delete " + clsUser._AdminEditName + "'s account?","Delete " + clsUser._AdminEditName+" ?",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Secound message box asking if they are sure
                DialogResult dialogResult2 = MessageBox.Show("Are you sure? all data will be deleted?", "Are you sure?", MessageBoxButtons.YesNo);
                    if(dialogResult2 == DialogResult.Yes)
                {
                    //sql of deleting selected account
                    byte lcresult = _DBMethods.DeleteAccount(clsUser._AdminEditName);
                    UpdateLists();
                    if (lcresult == 1)
                    { MessageBox.Show(clsUser._AdminEditName + " has been deleted"); }
                    else
                    { MessageBox.Show("Something went wrong, please try again"); }
                }
            }

        }

        //End selected game
        private void btnEnd_Click(object sender, EventArgs e)
        {
            //sql of getting selected game
            clsUser._AdminEditName = _DBMethods.AdminGetSelectedGame(lstGames).ToString();
            //asking if they are sure to delete
            DialogResult dialogresult =MessageBox.Show("Are you sure you want to delete the game with " +clsUser._AdminEditName +"?","delete game",MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                //sql of deleting selected game
                _DBMethods.DeleteGame(clsUser._AdminEditName);
                UpdateLists();
            }
        }

        //sign out of admin
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
