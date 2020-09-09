using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnoJueces
{
    public partial class mensaje_carp_invest : Form
    {
        public mensaje_carp_invest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
        }
    }
}
