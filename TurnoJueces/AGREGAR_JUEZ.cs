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
    public partial class AGREGAR_JUEZ : Form
    {
        public AGREGAR_JUEZ()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void RegistrarJuez() {

            //AQUI SE REGISTRA LOS DATOS DE LA CAUSA PENAL EN LA BASE DE DATOS
            string agregar1 = "insert into Jueces (NOMBRE, TOTAL_CARPETAS, FORMULACIONES, ORDENES_A, CONTROL_DETENCION, DELITO_ALTO_IMPACTO, DELITO_BAJO_IMPACTO, TOTAL_IMPUTADOS, TOTAL_VICTIMAS, ESTATUS) values('" + TB_NOM.Text + "', " + TB_TOTALCARP.Text + ", " + TB_FORMULACION.Text + ", " + TB_ORDEN_A.Text + ", " + TB_CONTROL.Text+ ", " + TB_DELITO_AI.Text + ", " + TB_DELITO_BI.Text + ", " + TB_TOTALIMPUTADOS.Text + ", "+TB_TOTALVICTIMAS.Text+", '"+CB_ESTATUS.Text+"' )";// se inserta dato en la tabla jueces
            if (CON.insertar(agregar1))
            {

                MessageBox.Show("JUEZ REGISTRADO CORRECTAMENTE");


            }
            else
            {

                MessageBox.Show("NO SE PUDO REGISTRAR AL JUEZ REVISA LOS DATOS");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarJuez();
        }
        public void mostrarDatos()
        {
            CON.consulta("select * from Jueces", "Jueces");
            dataGridView1.DataSource = CON.ds.Tables["Jueces"];
 

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void AGREGAR_JUEZ_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TB_NOM.Text = "";
            TB_TOTALCARP.Text = "";
            TB_FORMULACION.Text = "";
            TB_CONTROL.Text = "";
            TB_DELITO_AI.Text = "";
            TB_DELITO_BI.Text = "";
            TB_ORDEN_A.Text = "";
            TB_TOTALIMPUTADOS.Text = "";
            TB_TOTALVICTIMAS.Text = "" ; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
        }

        private void TB_NOM_KeyPress(object sender, KeyPressEventArgs e)
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
