﻿using System;
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

        public FrmHub()
        {
            InitializeComponent();
            lstPlayers.DataSource = null;
            //lstPlayers.DataSource = _DBMethods.ShowPlayersOnline();
        }

    }
}
