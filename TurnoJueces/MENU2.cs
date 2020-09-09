using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnoJueces
{
    public partial class MENU2 : Form
    {
        public MENU2()
        {
            InitializeComponent();
        }
        string carpeta, fecha, delito, juez, dependencia;
        private void button1_Click(object sender, EventArgs e)
        {
            DISPONIBILIDAD_JUECES rf = new DISPONIBILIDAD_JUECES();
            rf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ESTADISTICAS RF = new ESTADISTICAS();
            RF.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AGREGAR_JUEZ RF = new AGREGAR_JUEZ();
            RF.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //EDITAR_REGISTROS RF = new EDITAR_REGISTROS();
            MenuSolicitud RF = new MenuSolicitud();
            RF.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void MENU2_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
            label3.Text = DateTime.Now.ToLongDateString();

            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;//centrar la ventana
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;//centrar la ventana
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void MENU2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_maximizar.Visible = false;
            btn_restaurar.Visible = true;
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_restaurar.Visible = false;
            btn_maximizar.Visible = true;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BUSQUEDAS RF = new BUSQUEDAS();
            RF.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CAUSA_PENAL2 RF = new CAUSA_PENAL2();
            RF.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CORREO RF = new CORREO();
            RF.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            DataTable dt = CONEXION.Buscar(TB_NUM_OFICIO.Text);

            if (dt.Rows.Count > 0)
            {


                DataRow row = dt.Rows[0];
                //guardo datos en variables
                carpeta = Convert.ToString(row["CARPETA_JUDICIAL"]);
                fecha = Convert.ToString(row["FECHA_RECEPCION"]);
                delito = Convert.ToString(row["DELITO"]);
                juez = Convert.ToString(row["JUEZ"]);
                dependencia = Convert.ToString(row["DEPENDENCIA"]);

                //CARGO LOS DATOS A LOS TEXTBOX
                TB_CARP_JUD.Text = carpeta;
                DT_FECHA_RECEP.Text = fecha;
                TB_DELITO.Text = delito;
                TB_JUEZ.Text = juez;
                comboBox2.Text = dependencia;

                TB_CARP_JUD.Enabled = false;
                DT_FECHA_RECEP.Enabled = false;
                TB_DELITO.Enabled = false;
                TB_JUEZ.Enabled = false;
                comboBox2.Enabled = false;

                mensaje_carp_invest rf = new mensaje_carp_invest();
                rf.TXT_CARPETA.Text = TB_CARP_JUD.Text;
                rf.TXT_FECHA.Text = DT_FECHA_RECEP.Text;
                rf.TXT_DELITO.Text = TB_DELITO.Text;
                rf.TXT_JUEZ.Text = TB_JUEZ.Text;
                rf.TXT_DEPENDENCIA.Text = comboBox2.Text;
                rf.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("No Existe carpeta de investigacion", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DISPONIBILIDAD_JUECES rf = new DISPONIBILIDAD_JUECES();
                rf.label3.Text = TB_NUM_OFICIO.Text;
                rf.Show();
                this.Hide();

            }
        }
    }
}
