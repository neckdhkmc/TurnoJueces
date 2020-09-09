using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnoJueces
{
    public partial class EditCausaPenal : Form
    {
        public EditCausaPenal()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void bt_aceptar_Click(object sender, EventArgs e)
        {
            string actualizar_ = "CARPETA_JUDICIAL ='" + TB_CARP_JUD.Text + "', NUM_OFICIO='" + TB_NUM_OFICIO.Text + "', FECHA_RECEPCION='" + DT_FECHA_RECEP.Text + "', TIPO_SOLICITUD='" + cb_solicitud.Text + "', DELITO='" + TB_DELITO.Text + "', JUEZ='" + txt_juez.Text + "', DEPENDENCIA='" + comboBox2.Text + "'";

            if (CON.actualizar_CAUSAPENAL("Causa_Penal", actualizar_, "ID =" + TXT_ID.Text))
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
            notifyIcon1.BalloonTipText = "JUEZ: " + comboBox3.Text;

            notifyIcon1.ShowBalloonTip(100);

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CAUSA_PENAL2 RF = new CAUSA_PENAL2();
            RF.Show();
            this.Hide();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void EditCausaPenal_Load(object sender, EventArgs e)
        {
            mostrarCausasPenales();
            mostrarDatosjueces();
            mostrarDatosjueces2();
            CON.llenarNombre(comboBox3);
            dataGridView2.RowHeadersVisible = false;

        }
        public void mostrarCausasPenales()
        {

            CON.consulta("select  * from Causa_Penal order by CARPETA_JUDICIAL", "Causa_Penal");
            dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
            dataGridView1.Columns["ID"].Visible = false;


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
            TXT_ID.Text = dgv.Cells[0].Value.ToString();
            TB_CARP_JUD.Text = dgv.Cells[1].Value.ToString();
            TB_NUM_OFICIO.Text = dgv.Cells[2].Value.ToString();
            TB_DELITO.Text = dgv.Cells[5].Value.ToString();
            txt_juez.Text = dgv.Cells[8].Value.ToString();
        }

        public void mostrarDatosjueces()
        {


            CON.consulta("select  * from Jueces ", "Jueces");
            dataGridView2.DataSource = CON.ds.Tables["Jueces"];
            dataGridView3.DataSource = CON.ds.Tables["Jueces"];
            dataGridView2.Columns[1].HeaderText = "Nombre";
            dataGridView3.Columns[1].HeaderText = "Nombre";
            //dataGridView1.Columns[2].HeaderText = "Total de carpetas";
            //dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[3].HeaderText = "Formulaciones";
            //dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
            //dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[5].HeaderText = "Control de detención";
            //dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
            //dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
            //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[8].HeaderText = "Imputados";
            //dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[9].HeaderText = "Victimas";
            //dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns["ESTATUS"].Visible = false;
            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["TOTAL_CARPETAS"].Visible = false;
            dataGridView2.Columns["FORMULACIONES"].Visible = false;
            dataGridView2.Columns["ORDENES_A"].Visible = false;
            dataGridView2.Columns["CONTROL_DETENCION"].Visible = false;
            dataGridView2.Columns["DELITO_ALTO_IMPACTO"].Visible = false;
            dataGridView2.Columns["DELITO_BAJO_IMPACTO"].Visible = false;
            dataGridView2.Columns["TOTAL_IMPUTADOS"].Visible = false;
            dataGridView2.Columns["TOTAL_VICTIMAS"].Visible = false;
            dataGridView2.Columns["ALIAS"].Visible = false;


            dataGridView3.Columns["ESTATUS"].Visible = false;
            dataGridView3.Columns["id"].Visible = false;
            dataGridView3.Columns["TOTAL_CARPETAS"].Visible = false;
            dataGridView3.Columns["FORMULACIONES"].Visible = false;
            dataGridView3.Columns["ORDENES_A"].Visible = false;
            dataGridView3.Columns["CONTROL_DETENCION"].Visible = false;
            dataGridView3.Columns["DELITO_ALTO_IMPACTO"].Visible = false;
            dataGridView3.Columns["DELITO_BAJO_IMPACTO"].Visible = false;
            dataGridView3.Columns["TOTAL_IMPUTADOS"].Visible = false;
            dataGridView3.Columns["TOTAL_VICTIMAS"].Visible = false;
            dataGridView3.Columns["ALIAS"].Visible = false;



        }

        public void mostrarDatosjueces2()
        {


            CON.consulta("select  * from Jueces ", "Jueces");
            dataGridView3.DataSource = CON.ds.Tables["Jueces"];
            dataGridView3.Columns[1].HeaderText = "Nombre";

            dataGridView3.Columns["ESTATUS"].Visible = false;
            dataGridView3.Columns["id"].Visible = false;
            dataGridView3.Columns["TOTAL_CARPETAS"].Visible = false;
            dataGridView3.Columns["FORMULACIONES"].Visible = false;
            dataGridView3.Columns["ORDENES_A"].Visible = false;
            dataGridView3.Columns["CONTROL_DETENCION"].Visible = false;
            dataGridView3.Columns["DELITO_ALTO_IMPACTO"].Visible = false;
            dataGridView3.Columns["DELITO_BAJO_IMPACTO"].Visible = false;
            dataGridView3.Columns["TOTAL_IMPUTADOS"].Visible = false;
            dataGridView3.Columns["TOTAL_VICTIMAS"].Visible = false;
            dataGridView3.Columns["ALIAS"].Visible = false;



        }



        public void mostrarDatos()
        {
            CON.consulta("select * from Causa_Penal order by CARPETA_JUDICIAL", "Causa_Penal");
            dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
     
            //dataGridView1.Columns["ID"].Visible = false;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
