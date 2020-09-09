using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnoJueces
{
    public partial class EDITAR_REGISTROS : Form
    {
        public EDITAR_REGISTROS()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void EDITAR_REGISTROS_Load(object sender, EventArgs e)
        {
            mostrarDatos();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        public void mostrarDatos()
        {
            CON.consulta("select * from Jueces", "Jueces");
            dataGridView1.DataSource = CON.ds.Tables["Jueces"];
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ESTATUS"].Visible = false;
            dataGridView1.Columns["ALIAS"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
 

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]//mover el formulario
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]//mover el formulario

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void button2_Click(object sender, EventArgs e)
        {
            //mostrarDatos();
            //editarRegistro();

            string actualizar = "NOMBRE ='" + textBox2.Text + "', TOTAL_CARPETAS=" + tb_total_carpetas.Text + ", FORMULACIONES=" + tb_formulacion.Text + ", ORDENES_A=" + tb_aprehension.Text + ", CONTROL_DETENCION=" + tb_controlDetencion.Text + ", DELITO_ALTO_IMPACTO=" + tb_DAI.Text + ", DELITO_BAJO_IMPACTO=" + TB_DBI.Text + ", TOTAL_IMPUTADOS=" + TB_TOTALIMPUTADOS.Text + ", TOTAL_VICTIMAS=" + TB_TOTALVICTIMAS.Text + "";

            if (CON.actualizar("Jueces", actualizar, "id=" + textBox3.Text))
            {
                //MessageBox.Show("LOS DATOS SE MODIFICARON CORRECTAMENTE!!");

                NotificacionCausaPenal();
                mostrarDatos();
            }
            else
            {

                MessageBox.Show("ERROR AL ACTULIZAR  LOS DATOS");

            }
        }
        public void NotificacionCausaPenal()
        {



            notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"C:/Recursos_TurnosJueces/2.ico"));
            notifyIcon1.Text = "Edicion de registro";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Datos Modificados Correctamente";
            notifyIcon1.BalloonTipText = "JUEZ: " +textBox2.Text;

            notifyIcon1.ShowBalloonTip(100);

        }



        private void editarRegistro() {
           /* CONEXION con = new CONEXION();
            string actualizar = "NOMBRE ='" +textBox2.Text + "', TOTAL_CARPETAS=" + tb_total_carpetas.Text + ", FORMULACIONES=" + tb_formulacion.Text + ", ORDENES_A=" +tb_aprehension.Text + ", CONTROL_DETENCION=" + tb_controlDetencion.Text + ", DELITO_ALTO_IMPACTO=" + tb_DAI.Text + ", DELITO_BAJO_IMPACTO=" + TB_DBI.Text + ", TOTAL_IMPUTADOS=" + TB_TOTALIMPUTADOS.Text + ", TOTAL_VICTIMAS=" + TB_TOTALVICTIMAS.Text + "'";

            if (con.actualizar("Jueces", actualizar, "id=" + textBox3.Text))
            {
                MessageBox.Show("LOS DATOS SE MODIFICARON CORRECTAMENTE!!");
                mostrarDatos();
            }
            else
            {

                MessageBox.Show("ERROR AL ACTULIZAR  LOS DATOS");

            }
            */

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
            textBox3.Text = dgv.Cells[0].Value.ToString();
           textBox2.Text = dgv.Cells[1].Value.ToString();
            tb_total_carpetas.Text = dgv.Cells[2].Value.ToString();
            tb_formulacion.Text = dgv.Cells[3].Value.ToString();
            tb_aprehension.Text = dgv.Cells[4].Value.ToString();
            tb_controlDetencion.Text = dgv.Cells[5].Value.ToString();
            tb_DAI.Text = dgv.Cells[6].Value.ToString();
            TB_DBI.Text = dgv.Cells[7].Value.ToString();
            TB_TOTALIMPUTADOS.Text = dgv.Cells[8].Value.ToString();
            TB_TOTALVICTIMAS.Text = dgv.Cells[9].Value.ToString();



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MENU2 rf = new MENU2();
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

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
    }
}
