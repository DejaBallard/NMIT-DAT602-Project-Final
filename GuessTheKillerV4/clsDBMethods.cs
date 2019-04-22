using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheKiller
{
    public class clsDBMethods
    {
        public static DataTable OnlinePlayers;
        public static DataTable AdminPlayers;
        public static DataTable AdminGames;
        public static DataTable Chat;

        //login methods
        //login finished
        public float AccountLogin(string prName, string prPwd)
        {

          float lcResult = Convert.ToSingle(clsDBConnection.DbFunction("AccountLogin", new Dictionary<string, object>
            { ["Name"] = prName, ["Pwd"] = prPwd }));
            return lcResult;
        }

        //register finished
        public byte AccountRegister(string prName, string prPwd, string prScore)
        {

            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("AccountRegister", new Dictionary<string, object>
            { ["Name"] = prName, ["Pwd"] = prPwd, ["Score"] = prScore }));
            return lcResult;
        }

        //logoff finished
        public byte AccountLogOff(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("AccountLogOff", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }


        public List<string> ShowPlayersOnline(string prName)
        {
            OnlinePlayers = clsDBConnection.SProcTable("ShowOnlinePlayers", new Dictionary<string, object>

            { ["prCurrentAccName"] = prName });

            return (from DataRow lcRow in OnlinePlayers.Rows
                    select lcRow["Acc_Name"] + "\t" + lcRow["acc_score"] + "\t" + lcRow["acc_status"]).ToList();
        }


        public string GetSelectedName(ListBox prlst)
        {
            string lcPlayerName = OnlinePlayers.Rows[prlst.SelectedIndex]["acc_name"].ToString();

            return lcPlayerName;
        }
        public string GetSelectedStatus(ListBox prlst)
        {
            string lcPlayerStatus = OnlinePlayers.Rows[prlst.SelectedIndex]["acc_status"].ToString();

            return lcPlayerStatus;
        }


        //Sending Game Request
        public string GameRequest(string prName, string prOppName)
        {
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("SendRequest", new Dictionary<string, object>
            { ["Name"] = prName, ["_OppName"] = prOppName }));
            return lcResult;
        }
        public string HaveRequest(string prName)
        {
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("HaveRequest", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public Byte CreateGame(string prOppName, string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("CreateGame", new Dictionary<string, object>
            { ["_OppName"] = prOppName, ["Name"] = prName }));
            return lcResult;
        }

        //Admin Methods
        public List<string> AdminShowPlayers(string prName)
        {
            AdminPlayers = clsDBConnection.SProcTable("ShowPlayers", new Dictionary<string, object>

            { ["prCurrentAccName"] = prName });

            return (from DataRow lcRow in AdminPlayers.Rows

                    select lcRow["Acc_Name"] + "\t" + lcRow["acc_status"]).ToList();
        }
        public List<string> AdminShowGames()
        {
            AdminGames = clsDBConnection.SProcTable("ShowGames", new Dictionary<string, object>

            { });

            return (from DataRow lcRow in AdminGames.Rows

                    select lcRow["gam_player_1"] + "\t" + lcRow["gam_player_2"] + "\t" + lcRow["gam_start_time"]).ToList();
        }
        public string AdminGetSelectedName(ListBox prlst)
        {
            string lcPlayerName = AdminPlayers.Rows[prlst.SelectedIndex]["acc_name"].ToString();
            return lcPlayerName;
        }
        public string AdminGetSelectedGame(ListBox prlst)
        {
            string lcPlayerName = AdminGames.Rows[prlst.SelectedIndex]["gam_player_1"].ToString();
            return lcPlayerName;
        }
        public float GetScore(string prName)
        {
            float lcResult = Convert.ToSingle(clsDBConnection.DbFunction("GetScore", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public string GetVersion(string prName)
        {
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("GetVersion", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public string UpdateAccount(string prName, string prPass, string prScore, string prVersion)
        {
            Convert.ToString(prScore);
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("UpdateAccount", new Dictionary<string, object>
            { ["Name"] = prName, ["Pwd"] = prPass, ["Score"] = prScore, ["Version"] = prVersion }));
            return lcResult;
        }
        public byte DeleteAccount(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("DeleteAccount", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public void DeleteGame(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("DeleteGame", new Dictionary<string, object>
            { ["Name"] = prName }));
        }

        //Game
        public void SetStatus(string prName, string prType)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("ChangeStatus", new Dictionary<string, object>
            { ["Name"] = prName, ["Status"] = prType }));
        }
        public float GetNpcPicks(string prName)
        {
            float lcResult = Convert.ToSingle(clsDBConnection.DbFunction("GetnpcPicks", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public string GetTurn(string prName)
        {
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("GetTurn", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public string UpdateTurn(string prName)
        {
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("UpdateTurn", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public string GetPlayerOne(string prName)
        {
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("GetPlayerOne", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public void Set1Score(string prName, string prScore)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("Set1Score", new Dictionary<string, object>
            { ["Name"] = prName, ["Score"] = prScore }));
        }
        public void Set2Score(string prName, string prScore)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("Set2Score", new Dictionary<string, object>
            { ["Name"] = prName, ["Score"] = prScore }));
        }
        public byte IsGameActive(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("IsGameActive", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public float GetGame1Score(string prName)
        {
            float lcResult = Convert.ToSingle(clsDBConnection.DbFunction("GetGame1Score", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }
        public float GetGame2Score(string prName)
        {
            float lcResult = Convert.ToSingle(clsDBConnection.DbFunction("GetGame2Score", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }

        //Chat
        public List<string> ShowChat()
        {
            Chat = clsDBConnection.SProcTable("GetComments", new Dictionary<string, object>

            { });

            return (from DataRow lcRow in Chat.Rows

                    select "[" + lcRow["com_time"] + "] " + lcRow["com_account"] + ": " + lcRow["com_comment"]).ToList();
        }
        public void DeleteComments()
        {
            byte lcResult = Convert.ToByte(clsDBConnection.Execute("DeleteComments", new Dictionary<string, object>
            { }));
        }
        public void InsertComment(string prname,string prcomment)
        {
            string lcResult = Convert.ToString(clsDBConnection.DbFunction("InsertComment", new Dictionary<string, object>
            { ["Name"] = prname, ["Comment"] = prcomment }));

        }
    }
}
