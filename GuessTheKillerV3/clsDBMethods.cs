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

        public byte AccountLogin(string prName, string prPwd)
        {

            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("AccountLogin", new Dictionary<string, object>
            { ["Name"] = prName, ["Pwd"] = prPwd }));
            return lcResult;
        }

        public byte AccountRegister(string prName, string prPwd, string prScore)
        {

            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("AccountRegister", new Dictionary<string, object>
            { ["Name"] = prName, ["Pwd"] = prPwd, ["Score"] = prScore }));
            return lcResult;
        }

        public List<string> ShowPlayersOnline(string prName)
        {
            OnlinePlayers = clsDBConnection.SProcTable("ShowOnlinePlayers", new Dictionary<string, object>

            { ["prCurrentAccName"] = prName });

            return (from DataRow lcRow in OnlinePlayers.Rows

                    select lcRow["Acc_Name"] + "\t" + lcRow["acc_score"] + "\t" + lcRow["acc_status"]).ToList();
        }

        public byte AccountLogOff(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("AccountLogOff", new Dictionary<string, object>
            { ["Name"] = prName }));
            return lcResult;
        }

        public string GetSelectedName(ListBox prlst)
        {
            string lcPlayerName = OnlinePlayers.Rows[prlst.SelectedIndex]["acc_name"].ToString();
            return lcPlayerName;
        }


        //Sending Game Request
        public byte GameRequest(string prName, string prType)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("SendRequest", new Dictionary<string, object>
            { ["Name"] = prName, ["Type"] = prType }));
            return lcResult;
        }
        public byte HaveRequest(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("HaveRequest", new Dictionary<string, object>
            { ["Name"] = prName}));
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
        public void UpdateAccount(string prName, string prPass, string prScore)
        {
            Convert.ToString(prScore);
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("UpdateAccount", new Dictionary<string, object>
            { ["Name"] = prName, ["Pwd"] = prPass, ["Score"] = prScore}));
        }
        public void DeleteAccount(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("DeleteAccount", new Dictionary<string, object>
            {["Name"] = prName}));
        }
        public void DeleteGame(string prName)
        {
            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("DeleteGame", new Dictionary<string, object>
            { ["Name"] = prName }));
        }
    }
}
