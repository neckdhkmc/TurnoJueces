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
    public partial class login_usuario_root : Form
    {
        public login_usuario_root()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();

        private void login_usuario_root_Load(object sender, EventArgs e)
        {
            txt_pass.PasswordChar = '*';
        }
        public void datos_root()
        {

            string contraseña = "Disturbio1";
            if (txt_pass.Text == contraseña)
            {


                refrescarDisponibilidad();
            }
            else { MessageBox.Show("Aceso Denegado no eres usuario root","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void refrescarDisponibilidad()
        {


            if (CON.eliminar2(" disponibilidad"))
            {
                MessageBox.Show("SE VACIO LA TABLA DISPONIBILIDAD EN LA BASE DE DATOS", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



            }
            else
            {
                MessageBox.Show("Error al eliminar no hay campos");
                CAUSA_PENAL2 rf = new CAUSA_PENAL2();
                rf.Show();
                this.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            datos_root();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
        }
    }
}
