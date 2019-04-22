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
    public partial class FrmGame : Form
    {
        public string _playerOne;
        public string _UserName;
        public float _UserScore = 0;
        public string _OppName;
        public float _PlayerTwoScore;
        public float _npcPicked;
        public int _timeLeft = 5;
        public string _WhoseTurn;
        public string _accVerion;
        private clsDBMethods _DBMethods = new clsDBMethods();


        public FrmGame()
        {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            //Start Connection timer, to check if the connection with other player is still active
            tmrConnection.Start();
            //collect the answer from the database
            _npcPicked = _DBMethods.GetNpcPicks(clsUser._User);
            //Set username locally
            _UserName = clsUser._User;
            //set opponent name locally
            _OppName = clsUser._Oppname;
            this.Text = ("Welcome " + _UserName + " to the game");
            txtPlayer1Name.Text = _UserName;
            txtPlayer2Name.Text = _OppName;
            //How to play message
            MessageBox.Show("There is a killer on the loose. We have found six suspects and you need to decide who the killer is.\n\n" +
                "Rules:\n" +
                "5 Seconds to pick\n" +
                "The closer you are, the more points you will gain\n" +
                "points are multiplied by the time you have left, so be fast!\n" +
                "if the buttons are disabled. this means the other player is picking","How to play: "+_UserName);
            
            GameStarting();
        }
        //plays at start of game
        public void GameStarting()
        {
            //Gets whose turn it is
            _WhoseTurn = _DBMethods.GetTurn(clsUser._User);
            //if current user has its turn, they go first
            if (_WhoseTurn == clsUser._User)
            {
                checkButtons(true);
                tmrCountDown.Start();
            }
            //if current user is player two, wait
            else
            {
                checkButtons(false);
                tmrWaiting.Start();
            }
        }

        //Setting buttons to enabled or disabled
        private void checkButtons(bool prtype)
        {
            btnV1.Enabled = prtype;
            btnV2.Enabled = prtype;
            btnV3.Enabled = prtype;
            btnV4.Enabled = prtype;
            btnV5.Enabled = prtype;
            btnV6.Enabled = prtype;
        }

        //Leave button
        private void btnLeave_Click(object sender, EventArgs e)
        {
            //delete game row
            _DBMethods.DeleteGame(clsUser._User);
            this.Close();
        }

        //count down timer
        private void tmrCountDown_Tick(object sender, EventArgs e)
        {
            txtTime.Text = "time left: " + _timeLeft;
            _timeLeft--;
            if (_timeLeft == 0)
            { tmrCountDown.Stop();
             MessageBox.Show ("times up");
                _UserScore = 1;
            }

        }



        //Game buttons
        private void btnV1_Click(object sender, EventArgs e)
        {
            tmrCountDown.Stop();
            checkButtons(false);
            float lcValue = 1;
            MessageBox.Show("you picked " + lcValue + " and the correct answer is " + _npcPicked);
            float lcNPC = Convert.ToSingle(_npcPicked);
            float lcResult = lcNPC - lcValue;
            CompareAnswer(lcResult);
            UpdateDisplay();
            _DBMethods.UpdateTurn(_OppName);
            tmrWaiting.Start();
        }
        private void btnV2_Click(object sender, EventArgs e)
        {
            tmrCountDown.Stop();
            float lcValue = 2;
            checkButtons(false);
            MessageBox.Show("you picked " + lcValue + " and the correct answer is " + _npcPicked);
            float lcNPC = Convert.ToSingle(_npcPicked);
            float lcResult = lcNPC - lcValue;
            CompareAnswer(lcResult);
            UpdateDisplay();
            _DBMethods.UpdateTurn(_OppName);
            tmrWaiting.Start();
        }
        private void btnV3_Click(object sender, EventArgs e)
        {
            tmrCountDown.Stop();
            checkButtons(false);
            float lcValue = 3;
            MessageBox.Show("you picked " + lcValue + " and the correct answer is " + _npcPicked);
            float lcNPC = Convert.ToSingle(_npcPicked);
            float lcResult = lcNPC - lcValue;
            CompareAnswer(lcResult);
            UpdateDisplay();
            _DBMethods.UpdateTurn(_OppName);
            tmrWaiting.Start();
        }
        private void btnV4_Click(object sender, EventArgs e)
        {
            tmrCountDown.Stop();
            float lcValue = 4;
            checkButtons(false);
            MessageBox.Show("you picked " + lcValue + " and the correct answer is " + _npcPicked);
            float lcNPC = Convert.ToSingle(_npcPicked);
            float lcResult = lcNPC - lcValue;
            CompareAnswer(lcResult);
            UpdateDisplay();
            _DBMethods.UpdateTurn(_OppName);
            tmrWaiting.Start();
        }
        private void btnV5_Click(object sender, EventArgs e)
        {
            tmrCountDown.Stop();
            float lcValue = 5;
            checkButtons(false);
            MessageBox.Show("you picked " + lcValue + " and the correct answer is " + _npcPicked);
            float lcNPC = Convert.ToSingle(_npcPicked);
            float lcResult = lcNPC - lcValue;
            CompareAnswer(lcResult);
            UpdateDisplay();
            _DBMethods.UpdateTurn(_OppName);
            tmrWaiting.Start();
        }
        private void btnV6_Click(object sender, EventArgs e)
        {
            tmrCountDown.Stop();
            float lcValue = 6;
            checkButtons(false);
            MessageBox.Show("you picked " + lcValue + " and the correct answer is " + _npcPicked);
            float lcNPC = Convert.ToSingle(_npcPicked);
            float lcResult = lcNPC - lcValue;
            CompareAnswer(lcResult);
            UpdateDisplay();
            _DBMethods.UpdateTurn(_OppName);
            tmrWaiting.Start();
        }

        //Compare answer with real answer
        private float CompareAnswer(float prAnswer)
        {
            if (prAnswer == 0)
            {
                _UserScore += 5 * _timeLeft;
                return _UserScore;
            }
            else if (prAnswer == 1 || prAnswer == -1)
            {
                _UserScore += 3 * _timeLeft;
                return _UserScore;
            }
            else if (prAnswer == 2 || prAnswer == -2)
            {
                _UserScore += 2 * _timeLeft;
                return _UserScore;
            }
            else
            {
                _UserScore += 1 * _timeLeft;
                return _UserScore;
            }

        }

        //update display
        public void UpdateDisplay()
        {
            lblTurn.Text = _WhoseTurn;
            txtPlayer1Score.Text = _UserScore.ToString();
            _playerOne = _DBMethods.GetPlayerOne(clsUser._User);
            if (_playerOne == clsUser._User)
            {
                _DBMethods.Set1Score(_UserName, _UserScore.ToString());
                _PlayerTwoScore = _DBMethods.GetGame2Score(_OppName);
                txtPlayer2Score.Text = _PlayerTwoScore.ToString();
            }
            else
            {
                _DBMethods.Set2Score(_UserName, _UserScore.ToString());
                _PlayerTwoScore = _DBMethods.GetGame1Score(_OppName);
                txtPlayer2Score.Text = _PlayerTwoScore.ToString();
            }

        }

        //Connection timer
        private void tmrConnection_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
            byte lcResult = _DBMethods.IsGameActive(_UserName);
            if (lcResult == 0)
            {
                tmrConnection.Stop();
                MessageBox.Show("Sorry, connection has been lost");
                _DBMethods.SetStatus(_UserName, "2");
                this.Close();
            }
            if (_UserScore > 0 && _PlayerTwoScore > 0)
            {
                tmrWaiting.Stop();
                tmrConnection.Stop();
                _DBMethods.SetStatus(_UserName, "2");
                _accVerion = _DBMethods.GetVersion(_UserName);
                _DBMethods.UpdateAccount(_UserName, "", _UserScore.ToString(),_accVerion);
                resultMessage();
                _DBMethods.DeleteGame(clsUser._User);
                this.Close();
            }
        }
        private void resultMessage()
        {
            if (_UserScore < _PlayerTwoScore)
                MessageBox.Show("Sorry you lost \n\nUser Score: " + _UserScore + "\nOpponent: " + _PlayerTwoScore,_UserName);
            else if (_UserScore > _PlayerTwoScore)
                MessageBox.Show("You won! \n\nUser Score: " + _UserScore + "\nOpponent: " + _PlayerTwoScore,_UserName);
            else
                MessageBox.Show("It was a draw! \n\nUser Score: " + _UserScore + "\nOpponent: " + _PlayerTwoScore, _UserName);
        }

        //Waiting timer
        private void tmrWaiting_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
            //checking if other player has played
            _WhoseTurn = _DBMethods.GetTurn(clsUser._User);

            if (_WhoseTurn == clsUser._User)
            {
                tmrWaiting.Stop();
                checkButtons(true);
                MessageBox.Show(_OppName + " has finished their turn");
                tmrCountDown.Start();

            }

            
        }
    }
}
