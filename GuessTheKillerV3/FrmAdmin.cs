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

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            UpdateLists();
        }

        private void UpdateLists()
        {
            lstPlayers.DataSource = null;
            lstPlayers.DataSource = _DBMethods.AdminShowPlayers("");
            lstGames.DataSource = null;
            lstGames.DataSource = _DBMethods.AdminShowGames();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            clsUser._AdminEditName = null;
            _frmPlayer.ShowDialog();
            lstPlayers.DataSource = _DBMethods.AdminShowPlayers("");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsUser._AdminEditName = _DBMethods.AdminGetSelectedName(lstPlayers);
            _frmPlayer.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            clsUser._AdminEditName = _DBMethods.AdminGetSelectedName(lstPlayers).ToString();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want delete " + clsUser._AdminEditName + "'s account?","Delete " + clsUser._AdminEditName+" ?",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you sure? all data will be deleted?", "Are you sure?", MessageBoxButtons.YesNo);
                    if(dialogResult2 == DialogResult.Yes)
                {
                    _DBMethods.DeleteAccount(clsUser._AdminEditName);
                    UpdateLists();
                    MessageBox.Show(clsUser._AdminEditName + " has been deleted");

                }
            }

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            clsUser._AdminEditName = _DBMethods.AdminGetSelectedGame(lstGames).ToString();
            DialogResult dialogresult =MessageBox.Show("Are you sure you want to delete the game with " +clsUser._AdminEditName +"?","delete game",MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                _DBMethods.DeleteGame(clsUser._AdminEditName);
                UpdateLists();
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
