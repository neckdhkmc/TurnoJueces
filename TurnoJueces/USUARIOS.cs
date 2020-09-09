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
    public partial class USUARIOS : Form
    {
        public USUARIOS()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void USUARIOS_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
            mostrarDatos();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void mostrarDatos()
        {

            CON.consulta("select  * from usuarios ", "usuarios");
            dataGridView1.DataSource = CON.ds.Tables["usuarios"];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
            //  textBox1.Text = dgv.Cells[0].Value.ToString();
            label5.Text = dgv.Cells[0].Value.ToString();
            TXT_NOM.Text = dgv.Cells[1].Value.ToString();
            TXT_USER.Text = dgv.Cells[2].Value.ToString();
            TXT_PASS.Text = dgv.Cells[3].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            modificar();
        }

        public void modificar() {

            string actualizar = "nombre ='" + TXT_NOM.Text + "', nickname='" + TXT_USER.Text + "', pass='" + TXT_PASS.Text+ "'";

            if (CON.actualizar("usuarios", actualizar, "id=" + label5.Text))
            {
                MessageBox.Show("LOS DATOS SE MODIFICARON CORRECTAMENTE!!");
                mostrarDatos();
            }
            else
            {

                MessageBox.Show("ERROR AL ACTULIZAR  LOS DATOS");

            }
        }
        public void registrar() {

            string agregar1 = "insert into usuarios (nombre, nickname, pass) values('" + TXT_NOM.Text + "', '" +TXT_USER.Text + "', '" +TXT_PASS.Text +"' )";// se inserta dato en la tabla disponibilidad
            if (CON.insertar(agregar1))
            {

                MessageBox.Show("USUARIO REGISTRADO","INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {

                MessageBox.Show("NO SE PUDO REGISTRAR EL USUARIO REVISA LA INFORMACION", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registrar();
            mostrarDatos();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MENU2 rf = new MENU2();
            rf.Show();
            this.Hide();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            //btn_maximizar.Visible = false;
            //btn_restaurar.Visible = true;
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            //btn_restaurar.Visible = false;
            //btn_maximizar.Visible = true;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CON.eliminar(" usuarios ", " id =" + label5.Text))
            {
                MessageBox.Show("El USUARIO  SE HA ELIMINADO CORRECTAMENTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   mostrarDatos();


            }
            else
            {
                MessageBox.Show("Error al eliminar");
                this.Hide();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TXT_NOM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
