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

        public string User { get => _User; set => _User = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Score { get => _Score; set => _Score = value; }
    }
}
