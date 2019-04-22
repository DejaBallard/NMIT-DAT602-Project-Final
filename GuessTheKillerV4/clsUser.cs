using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheKiller
{
   public class clsUser
    {
        public static string _User;
        private string _Password;
        private string _Score;
        private string _Requested;
        public static string _AdminEditName;
        public static string _Oppname;

        public string User { get => _User; set => _User = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Score { get => _Score; set => _Score = value; }
        public string Requested { get => _Requested; set => _Requested = value; }
        public static string Oppname { get => _Oppname; set => _Oppname = value; }
    }
}
