using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheKiller
{
public class clsDBMethods
    {
        public byte AccountLogin(string prName,string prPwd)
        {

            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("AccountLogin", new Dictionary<string, object>
            { ["Name"] = prName , ["Pwd"] = prPwd }));
            return lcResult;
        }

        public byte AccountRegister(string prName, string prPwd)
        {
            string lcName = prName;
            string lcPwd = prPwd;

            byte lcResult = Convert.ToByte(clsDBConnection.DbFunction("AccountRegister", new Dictionary<string, object>
            { ["Name"] = lcName, ["Pwd"] = lcPwd }));
            return lcResult;
        }

        public List<string> ShowPlayersOnline(string prName)
        {
            DataTable lcOnlinePlayers = clsDBConnection.SProcTable("ShowOnlinePlayers", new Dictionary<string, object>

            { ["prCurrentAccName"] = prName });

            return (from DataRow lcRow in lcOnlinePlayers.Rows

                    select lcRow["Acc_Name"] + "\t" + lcRow["acc_score"] + "\t" + lcRow["acc_status"]).ToList();
        }
    }
}
