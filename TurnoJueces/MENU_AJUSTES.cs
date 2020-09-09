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
    public partial class CAUSA_PENAL2 : Form
    {
        public CAUSA_PENAL2()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            login_usuario_root rf = new login_usuario_root();
            rf.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LOGIN2 rf = new LOGIN2();
            rf.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            JUECES_NODISP rf = new JUECES_NODISP();
            rf.Show();
            this.Hide();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
        }

       

        private void CAUSA_PENAL2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EditCausaPenal RF = new EditCausaPenal();
            RF.Show();
        }
    }
        
    }
