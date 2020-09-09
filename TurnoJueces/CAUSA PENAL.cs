using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using WhatsAppApi;

namespace TurnoJueces
{
    public partial class tb_resul_control : Form
    {
        public tb_resul_control()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();

        String NOM, NOM_VICTIMA;
        int SUMA, R1, R2;
        int SUMA_VICTIMAS, A1, A2;
        int SUMA_CARPETAS, B1, B2;
        int suma_formulacion, c1, c2, suma_ordenes, c3, c4, suma_control, c5, c6, c7, c8, suma_DAI, c9, c10, SUMA_DBI;

        //int edad;
        string carpeta, fecha, delito, juez, dependencia;

        //CODIGI PARA PODER MOVER LA VENTANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void CAUSA_PENAL_Load(object sender, EventArgs e)
        {

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.Transparent;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.Transparent;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font ("Tahoma", 9, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            mostrarDatos();
            mostrarDatos2();
            // txtTuTextBox.Text = tuDataGrid.CurrentRow.Cells["nombreColumna"].Value.ToString();
            //  label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            // id.Text = dataGridView1..Cells["id"].Value.ToString();
            //label12.Text = dataGridView1.CurrentRow.Cells["TOTAL_IMPUTADOS"].Value.ToString();
            //label13.Text = dataGridView1.CurrentRow.Cells["TOTAL_VICTIMAS"].Value.ToString();
            //label14.Text = dataGridView1.CurrentRow.Cells["TOTAL_CARPETAS"].Value.ToString();
            //label17.Text = dataGridView1.CurrentRow.Cells["FORMULACIONES"].Value.ToString();
            //label19.Text = dataGridView1.CurrentRow.Cells["ORDENES_A"].Value.ToString();
            //label21.Text = dataGridView1.CurrentRow.Cells["CONTROL_DETENCION"].Value.ToString();
            //label23.Text = dataGridView1.CurrentRow.Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            //label24.Text = dataGridView1.CurrentRow.Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            //MessageBox.Show("EL JUEZ CON MENOS CARPETAS JUDICIALES ES EL LIC.:" + label10.Text);
            //TB_JUEZ.Text = label10.Text
            int total = 0;// VARIA QUE ALMACENARA LA SUMA
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {//CICLO PARA IR SUMANDO LAS FILAS DE LA COLUMNA TOTAL DE CARPETAS

                total += Convert.ToInt32(row.Cells["TOTAL_CARPETAS"].Value);


            }
            label28.Text = Convert.ToString(total);// SE ALAMCENA EL NUMERO DEL TOTAL 


            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            
        }
        public void NotificacionCausaPenal() {



            notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"C:/Recursos_TurnosJueces/2.ico"));
            notifyIcon1.Text = "Registro de causa";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Causa Penal Registrada Correctamente";
            notifyIcon1.BalloonTipText = "EXPEDIENTE: " + TB_CARP_JUD.Text + " JUEZ: " + TB_JUEZ.Text;

            notifyIcon1.ShowBalloonTip(100);

        }//metodo para mostrar notificaciones al  registrar una causa penal

        //public void EnviarWhatsapp() {
        //    string from = "7442946788";
        //    string to = txtTo.Text;
        //    string msg = TB_CARP_JUD.Text;

        //    WhatsApp wa = new WhatsApp(from, "Disturbio1", "MyLaptop", false, false);

        //    wa.OnConnectSuccess += () =>
        //    {
        //        MessageBox.Show("conectado a whats");
        //        wa.OnLoginSuccess += (phoneNumber, data) =>
        //        {
        //            wa.SendMessage(to, msg);
        //            MessageBox.Show("mensaje enviado..");
        //        };
        //        wa.OnLoginFailed += (data) =>
        //        {
        //            MessageBox.Show("login failed: {0}", data);

        //        };
        //        wa.Login();
        //    };

        //    wa.OnConnectFailed += (ex) =>
        //    {
        //        MessageBox.Show("ffallo la conexion");
            
        //    };
        
        //}

    
        private void gestionaResaltados(DataGridView visor, Int32 fila, System.Drawing.Color c)
        {
            visor.Rows[0].Cells[0].Style.BackColor = c;
        }
        public void mostrarDatos()
        {
            

            CON.consulta("select  * from Jueces where Estatus = '" +lb_disponible.Text  + "'", "Jueces");
            dataGridView1.DataSource = CON.ds.Tables["Jueces"];
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Total de carpetas"; 
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderText = "Formulaciones";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderText = "Control de detención";
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].HeaderText = "Imputados";
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].HeaderText = "Victimas";
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ESTATUS"].Visible = false;
            dataGridView1.Columns["ALIAS"].Visible = false;
            

        }//metodo para mostrar  informacion de los jueces en datagridview
        public void mostrarDatos2()
        {


            CON.consulta("select  * from Jueces", "Jueces");
            dataGridView4.DataSource = CON.ds.Tables["Jueces"];


        }//

        public void mostrarDatosFormulacion()
        {

            if (comboBox1.Text == "DELITO DE ALTO IMPACTO")
            {
                CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by FORMULACIONES,TOTAL_CARPETAS, DELITO_ALTO_IMPACTO, TOTAL_IMPUTADOS, TOTAL_VICTIMAS, id", "jueces");
                dataGridView1.DataSource = CON.ds.Tables["jueces"];
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Total de carpetas";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Formulaciones";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].HeaderText = "Control de detensión";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].HeaderText = "Imputados";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].HeaderText = "Victimas";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["ESTATUS"].Visible = false;
                dataGridView1.Columns["ALIAS"].Visible = false;



            }
            else if (comboBox1.Text == "DELITO DE BAJO IMPACTO") {
                CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by FORMULACIONES,TOTAL_CARPETAS, DELITO_BAJO_IMPACTO, TOTAL_IMPUTADOS, TOTAL_VICTIMAS, id", "jueces");
                dataGridView1.DataSource = CON.ds.Tables["jueces"];
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Total de carpetas";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Formulaciones";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].HeaderText = "Control de detensión";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].HeaderText = "Imputados";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].HeaderText = "Victimas";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["ESTATUS"].Visible = false;
                dataGridView1.Columns["ALIAS"].Visible = false;

            }


        }//metodo para buscar por formulaciones

        public void mostrarDatosOrdenes()
        {

            if (comboBox1.Text == "DELITO DE ALTO IMPACTO")
            {
                CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by ORDENES_A, TOTAL_CARPETAS, DELITO_ALTO_IMPACTO,TOTAL_IMPUTADOS, TOTAL_VICTIMAS, id", "jueces");
                dataGridView1.DataSource = CON.ds.Tables["jueces"];
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Total de carpetas";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Formulaciones";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].HeaderText = "Control de detensión";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].HeaderText = "Imputados";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].HeaderText = "Victimas";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["ESTATUS"].Visible = false;
                dataGridView1.Columns["ALIAS"].Visible = false;

            }
            else if (comboBox1.Text == "DELITO DE BAJO IMPACTO") {

                CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by ORDENES_A, TOTAL_CARPETAS,  DELITO_BAJO_IMPACTO,TOTAL_IMPUTADOS, TOTAL_VICTIMAS, id", "jueces");
                dataGridView1.DataSource = CON.ds.Tables["jueces"];
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Total de carpetas";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Formulaciones";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].HeaderText = "Control de detensión";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].HeaderText = "Imputados";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].HeaderText = "Victimas";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["ESTATUS"].Visible = false;
                dataGridView1.Columns["ALIAS"].Visible = false;

            }


        }//metodo para buscar por ordenes de aprehension
        public void mostrarDatosControles()
        {

            if (comboBox1.Text == "DELITO DE ALTO IMPACTO")
            {
                CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by CONTROL_DETENCION, TOTAL_CARPETAS, DELITO_ALTO_IMPACTO, TOTAL_IMPUTADOS, TOTAL_VICTIMAS, id", "jueces");
                dataGridView1.DataSource = CON.ds.Tables["jueces"];
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Total de carpetas";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Formulaciones";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].HeaderText = "Control de detensión";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].HeaderText = "Imputados";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].HeaderText = "Victimas";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["ESTATUS"].Visible = false;
                dataGridView1.Columns["ALIAS"].Visible = false;

            }
            else if (comboBox1.Text == "DELITO DE BAJO IMPACTO")
            {
                CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by CONTROL_DETENCION, TOTAL_CARPETAS, DELITO_BAJO_IMPACTO, TOTAL_IMPUTADOS, TOTAL_VICTIMAS, id", "jueces");
                dataGridView1.DataSource = CON.ds.Tables["jueces"];
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Total de carpetas";
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].HeaderText = "Formulaciones";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].HeaderText = "Ordenes de Aprenhensión";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].HeaderText = "Control de detensión";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].HeaderText = "Delito de alto impacto";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].HeaderText = "Delito de Bajo impacto ";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].HeaderText = "Imputados";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].HeaderText = "Victimas";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["ESTATUS"].Visible = false;
                dataGridView1.Columns["ALIAS"].Visible = false;


            }

        }//metodo para buscar por controles de detencion
        //public void mostrarDatosAltoI()
        //{


        //    CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by DELITO_ALTO_IMPACTO, TOTAL_CARPETAS, DELITO_ALTO_IMPACTO", "jueces");
        //    dataGridView1.DataSource = CON.ds.Tables["jueces"];

        //}
        //public void mostrarDatosBajoI()
        //{


        //    CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by DELITO_BAJO_IMPACTO", "jueces");
        //    dataGridView1.DataSource = CON.ds.Tables["jueces"];

        //}
        //public void mostrarDatosImputados()
        //{


        //    CON.consulta("select  * from jueces where Estatus = '" + lb_disponible.Text + "'order by TOTAL_IMPUTADOS", "jueces");
        //    dataGridView1.DataSource = CON.ds.Tables["jueces"];

        //}
        //public void mostrarDatosVictimas()
        //{


        //    CON.consulta("select  * from Jueces where Estatus = '" + lb_disponible.Text + "'order by TOTAL_VICTIMAS", "Jueces");
        //    dataGridView1.DataSource = CON.ds.Tables["Jueces"];

        //}
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)// metodo para mandar datos del data grid a elemtos del formulario 
        {

          
            //.Font = new Font("Tahoma", 8, FontStyle.Bold).Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
          //  textBox1.Text = dgv.Cells[0].Value.ToString();

            TB_JUEZ.Text = dgv.Cells[1].Value.ToString();
            id.Text = dgv.Cells[0].Value.ToString();
            label14.Text = dgv.Cells[2].Value.ToString();
            label12.Text = dgv.Cells[8].Value.ToString();
            label13.Text = dgv.Cells[9].Value.ToString();
            label17.Text = dgv.Cells[3].Value.ToString();
            label19.Text = dgv.Cells[4].Value.ToString();
            label21.Text = dgv.Cells[5].Value.ToString();
            label23.Text = dgv.Cells[6].Value.ToString();
            label24.Text = dgv.Cells[7].Value.ToString();

            dataGridView1.Enabled = false;
            MessageBox.Show("haz seleccionado un juez para registro, si deseas cambiar a otro juez dar click en el boton habilitar", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //groupBox1.Enabled = true;
            tb_imputado.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox5.Enabled = true;
            dataGridView2.Enabled = true;
            TB_VICTIMA.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox6.Enabled = true;
            dataGridView3.Enabled = true;
            bt_aceptar.Visible = true;
            DT_FECHA_RECEP.Enabled = true;
            TB_DELITO.Enabled = true;
            comboBox2.Enabled = true;

            TB_CARP_JUD.Enabled = true;
            TB_NUM_OFICIO.Enabled = true;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;//CAMBIA EL COLOR DE LA CABECERA A GRIS CUANDO ESTA BLOQUEDO EL DATAGGRID

           

        }

        private void TB_CONT_IMPU_TextChanged(object sender, EventArgs e)
        {
            //TB_CONT_IMPU.Text = tb_imputado.Lines.Count;
        }

        private void pictureBox1_Click(object sender, EventArgs e)// boton para agregar imputado
        {

            if (tb_imputado.Text == "")
            {

                MessageBox.Show("no se ha registrado ningun imputado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                NOM = tb_imputado.Text;//NOM AHORA CONTIENE LO QUE TIENE EL TEXTBOX DE IMPUTADO
                                       //DG_IMPUTADOS.Rows.Add(NOM);//AGREGARMOS  AL DATAGRIDVIWS LO QUE TENEMOS EN LA VARIABLE NOM
                                       //DG_IMPUTADOS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//AJUSTAMOS EL CONTENIDO DE LA FILA AL DATAGRID
                                       //dataGridView2.ClearSelection();
                dataGridView2.Rows.Add(NOM);

                //dataGridView4.Rows.Add(NOM);
                dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                TB_CONT_IMPU.Text = dataGridView2.Rows.Count.ToString();
                R1 = Convert.ToInt32(TB_CONT_IMPU.Text);
                R2 = Convert.ToInt32(label12.Text);
                CONT_IMP_2.Text = dataGridView2.Rows.Count.ToString();

                /* TB_CONT_IMPU.Text = DG_IMPUTADOS.Rows.Count.ToString();
                 R1 = Convert.ToInt32(TB_CONT_IMPU.Text);//CONVIERTE EL VALOR DEL TEXTBOX DE IMPUTADO Y LO ALMACENA EN LA VARIABLE R1
                 R2 = Convert.ToInt32(label12.Text);
                 CONT_IMP_2.Text = DG_IMPUTADOS.Rows.Count.ToString();//EL TEXTBOX RECIBE EL NUMERO DE IMPUTADOS ALMACENADOS EN EL DATAGRIDVIWE PARA AGREGARSE AL TOTAL DE IMPUTADOS DE LA CAUSA PENAL
                 */



                SUMA = R1 + R2;//SUMA LOS DATOS DE R1 Y R2 Y LOS ALMACENA EN SUMA COMO ENTEROS

                TB_CONT_IMPU.Text = SUMA.ToString();
                //TB_CONT_IMPU.Text = SUMA.ToString();//TB_CON MANDA EL RESULTADO AL TEXBOX PARA AGREGARLO A LA ESTADISTICA DEL JUEZ

                tb_imputado.Text = "";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TB_CONT_IMPU.Text = dataGridView2.Rows.Count.ToString();//TEXBOX DEL CONTADOR DEL IMPUTADO CUENTA LOS RENGLONES DEL DATAGRID


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int valor1, valor2, resultado_Imputado;

            //R1 = 0;
            //R2 = 0;
            //SUMA = 0;
            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            CONT_IMP_2.Text = dataGridView2.Rows.Count.ToString();


            valor1 = Convert.ToInt32(CONT_IMP_2.Text);
            valor2 = Convert.ToInt32(label12.Text);
            CONT_IMP_2.Text = dataGridView2.Rows.Count.ToString();

            resultado_Imputado = valor1 + valor2;

            //SUMA = R1 + R2;//SUMA LOS DATOS DE R1 Y R2 Y LOS ALMACENA EN SUMA COMO ENTEROS
            TB_CONT_IMPU.Text = resultado_Imputado.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            int PrimerValor, SegundoValor, resultado_Victima;
            dataGridView3.Rows.Remove(dataGridView3.CurrentRow);
            CONT_VICT_2.Text = dataGridView3.Rows.Count.ToString();

            PrimerValor = Convert.ToInt32(CONT_VICT_2.Text);
            SegundoValor = Convert.ToInt32(label13.Text);
            CONT_VICT_2.Text = dataGridView3.Rows.Count.ToString();

            resultado_Victima = PrimerValor + SegundoValor;

            //SUMA = R1 + R2;//SUMA LOS DATOS DE R1 Y R2 Y LOS ALMACENA EN SUMA COMO ENTEROS
      
            TB_CONT_VICTIMA.Text = resultado_Victima.ToString();

            //...................................................


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {

                mostrarDatosFormulacion();
                label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                MessageBox.Show("EL JUEZ CON MENOS FORMULACIONES DE IMPUTACION ES EL LIC.:" + label10.Text);

                checkBox2.Checked = false;
               
                checkBox5.Checked = false;
               
                TB_JUEZ.Text = label10.Text;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {

                mostrarDatosOrdenes();
                label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                MessageBox.Show("EL JUEZ CON MENOS ORDENES DE APRHENSIÓN ES EL LIC.:" + label10.Text);

                checkBox1.Checked = false;
               
                checkBox5.Checked = false;
                
                TB_JUEZ.Text = label10.Text;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {

                mostrarDatosControles();
                label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                MessageBox.Show("EL JUEZ CON MENOS CONTROLES ES EL LIC.:" + label10.Text);

                checkBox1.Checked = false;
                checkBox2.Checked = false;
              
                TB_JUEZ.Text = label10.Text;
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            ESTADISTICAS rf = new ESTADISTICAS();
            rf.Show();
            this.Hide();

        }//boton regresar

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView2.SelectedRows[0].Selected = false;

        }

        private void tb_resul_control_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

}

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            imprimir();
        }// boton para imprimir
        public void imprimir() {
            Directory.Delete("C:\\PDFs\\", true);
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 103;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(137, 243, 126);

                pdfTable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            //string folderPath = "C:\\PDFs\\";
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            //using (FileStream stream = new FileStream(folderPath + "Datos_Jueces.pdf", FileMode.Create))
            //{
            //    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();
            //    pdfDoc.Add(pdfTable);
            //    pdfDoc.Close();
            //    stream.Close();
            //}
            Document document = new Document(iTextSharp.text.PageSize.LEGAL.Rotate());
            PdfWriter.GetInstance(document, new FileStream(folderPath+"Datos_Juecez.pdf", FileMode.OpenOrCreate));
            document.Open();
            // var fuente_texto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, Element.ALIGN_CENTER);
            iTextSharp.text.Font fuente = new iTextSharp.text.Font();
            document.Add(new Paragraph("                                                                                                REPORTE DE JUECES DEL JUZGADO DE CONTROL DE ACAPULCO"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("                      " +DT_FECHA_RECEP.Text ));
            document.Add(new Paragraph("\n"));
            document.Add(pdfTable);


            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Recursos_TurnosJueces\21761930_1498902300203631_6112178357467530526_n.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 80 / imagen.Width;
            imagen.ScalePercent(percentage * 150);
            imagen.SetAbsolutePosition(870, 510);

            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(@"C:\Recursos_TurnosJueces\12299228_1526794907618863_1923735897809301275_n.png");
            imagen2.BorderWidth = 0;
            imagen2.Alignment = Element.ALIGN_LEFT;
            float percentage2 = 0.0f;
            percentage2 = 80 / imagen2.Width;
            imagen2.ScalePercent(percentage2 * 70);
            imagen2.SetAbsolutePosition(50, 525);

            // Insertamos la imagen en el documento
            document.Add(imagen);
            document.Add(imagen2);

            document.Close();

            System.Diagnostics.Process.Start(@"C:\PDFs\Datos_Juecez.pdf");


        }//metodo para  crear pdf e imprimir
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //registro();

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


            }
              



        }//boton para buscar si existe el numero de investigacion

        public void registro()
        {
            //SqlConnection con = new SqlConnection("Data Source =(local)\\SQLEXPRESS; Initial Catalog = Turnos; Integrated Security = True");// CREAMOS UN METODO  CONEXION EL CUAL CONTENDRA LA CADENA DE CONEXION LA CUAL SERA EL MEDIO PARA PODER  TENER ACCESO A LA BASE DE DATOS
            SqlConnection con = new SqlConnection("Server=(local); Initial Catalog = Turnos; Integrated Security = True");
            //SqlConnection con = new SqlConnection("Data Source = DESKTOP-4BK74NR\\SQLEXPRESS; Initial Catalog = Turnos; Integrated Security = True");


            con.Open();

            SqlCommand consulta = new SqlCommand("select * from Causa_Penal where NUM_OFICIO= '" + TB_NUM_OFICIO.Text + "'", con);
            SqlDataReader ejecutar = consulta.ExecuteReader();
            if (ejecutar.Read() == true)
            {


                MessageBox.Show("EL NUMERO DE INVESTIGACION YA EXISTE", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DISPONIBILIDAD_JUECES rf = new DISPONIBILIDAD_JUECES();
                rf.Show();
                this.Hide();




            }
            else
            {
                MessageBox.Show("EL NUMERO DE INVESTIGACION NO EXISTE, CAMPOS HABILITADOS PARA REGISTRAR", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

              
                DT_FECHA_RECEP.Enabled = true;
                TB_DELITO.Enabled = true;
                comboBox2.Enabled = true;
                tb_imputado.Enabled = true;
                pictureBox1.Enabled = true;
                pictureBox5.Enabled = true;
                dataGridView2.Enabled = true;
                TB_VICTIMA.Enabled = true;
                pictureBox4.Enabled = true;
                pictureBox6.Enabled = true;
                dataGridView3.Enabled = true;
                bt_aceptar.Visible = true;

                con.Close();
            }


        }// metodo para buscar si existe el numero de investigacion 

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.Text == "DELITO DE ALTO IMPACTO") {
            //    cb_solicitud.Enabled = true;
            //}
            //else /*if (comboBox1.Text == "DELITO DE ALTO IMPACTO")*/ {
            //    cb_solicitud.Enabled = true;
            //}
        }

        private void tb_imputado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }//evento para validaciones

        private void TB_VICTIMA_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Información de los jueces habilitada", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.Enabled = true;
            
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;

        }

        private void TB_DELITO_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_solicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_solicitud.Text == "FORMULACION DE IMPUTACIÓN")
            {
                //mostrarDatosFormulacion();


                mostrarDatosFormulacion();
                label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                const string mensaje = "EL JUEZ SELECCIONADO ES EL LIC.:";

                 MessageBox.Show(mensaje + label10.Text + " " + "DAR DOBLE CLICK EN EL NOMBRE PARA REGISTRAR CAUSA PENAL", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //pictureBox8.Visible = true;


            }
            else if (cb_solicitud.Text == "ORDEN DE APREHENSIÓN")
            {

                mostrarDatosOrdenes();
                label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                const string mensaje = "EL JUEZ SELECCIONADO ES EL LIC.:";

                MessageBox.Show(mensaje + label10.Text +" " + "DAR DOBLE CLICK EN EL NOMBRE PARA REGISTRAR CAUSA PENAL", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //MessageBox.Show("EL JUEZ CON MENOS ORDENES DE APRHENSIÓN ES EL LIC.:" + label10.Text);

                //checkBox1.Checked = false;

                //checkBox5.Checked = false;

                TB_JUEZ.Text = label10.Text;

                //pictureBox8.Visible = true;

            }
            else if (cb_solicitud.Text == "CONTROL DE DETENCIÓN") {

                mostrarDatosControles();
                label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                const string mensaje = "EL JUEZ SELECCIONADO ES EL LIC.:";

                MessageBox.Show(mensaje + label10.Text + " " + "DAR DOBLE CLICK EN EL NOMBRE PARA REGISTRAR CAUSA PENAL", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //MessageBox.Show("EL JUEZ CON MENOS CONTROLES ES EL LIC.:" + label10.Text);

                //    checkBox1.Checked = false;
                //    checkBox2.Checked = false;

                //    TB_JUEZ.Text = label10.Text;
                //pictureBox8.Visible = true;

            }
        }

      

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Refresh();
            //this.Show();

            groupBox1.Enabled = true;
            tb_imputado.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox5.Enabled = true;
            dataGridView2.Enabled = true;
            TB_VICTIMA.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox6.Enabled = true;
            dataGridView3.Enabled = true;
            this.Load += new System.EventHandler(this.CAUSA_PENAL_Load);
            //Application.Run();
            mostrarDatos();


            //TB_CARP_JUD.Enabled = true;
            //TB_NUM_OFICIO.Enabled = true;
            //DT_FECHA_RECEP.Enabled = true;
            //cb_solicitud.Enabled = true;
            //comboBox1.Enabled = true;
            //TB_DELITO.Enabled = true;
            //tb_imputado.Enabled = true;
            //TB_VICTIMA.Enabled = true;
            //dataGridView1.Enabled = true;

            //TB_CARP_JUD.Text = "";
            //TB_NUM_OFICIO.Text = "";
            //cb_solicitud.Text = null;
            //comboBox1.Text = null;
            //TB_DELITO.Text = "";
            //tb_imputado.Text = "";
            //TB_VICTIMA.Text = "";
            //dataGridView2.Rows.Clear();
            //dataGridView3.Rows.Clear();

            //checkBox2.Enabled = true;
            //checkBox1.Enabled = true;

            //checkBox5.Enabled = true;

            //bt_aceptar.Enabled = true;


            //// txtTuTextBox.Text = tuDataGrid.CurrentRow.Cells["nombreColumna"].Value.ToString();
            //label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            //id.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            //label12.Text = dataGridView1.CurrentRow.Cells["TOTAL_IMPUTADOS"].Value.ToString();
            //label13.Text = dataGridView1.CurrentRow.Cells["TOTAL_VICTIMAS"].Value.ToString();
            //label14.Text = dataGridView1.CurrentRow.Cells["TOTAL_CARPETAS"].Value.ToString();
            //label17.Text = dataGridView1.CurrentRow.Cells["FORMULACIONES"].Value.ToString();
            //label19.Text = dataGridView1.CurrentRow.Cells["ORDENES_A"].Value.ToString();
            //label21.Text = dataGridView1.CurrentRow.Cells["CONTROL_DETENCION"].Value.ToString();
            //MessageBox.Show("EL JUEZ CON MENOS CARPETAS JUDICIALES ES EL LIC: " + label10.Text + " SI DESEA HACER CAMBIO DE JUEZ DAR DOBLE CLICK EN EL  NOMBRE DEL JUEZ DE LA TABLA");
            //TB_JUEZ.Text = label10.Text;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            MENU2 rf = new MENU2();
            rf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)//boton de aceptar y registrar la causapenal
        {
            if (comboBox1.Text == "DELITO DE ALTO IMPACTO")
            {
                if (cb_solicitud.Text == "FORMULACION DE IMPUTACIÓN")
                {
                    // CON.Eliminar_Disponibilidad("disponibilidad");
                    registrar_formulacion();
                   
                    Registro_causas();
                    registrar_DAI();
                    mostrarDatos();

                    //TB_CARP_JUD.Enabled = false;
                    //TB_NUM_OFICIO.Enabled = false;
                    //DT_FECHA_RECEP.Enabled = false;
                    ////cb_solicitud.Enabled = false;
                    //checkBox1.Enabled = false;
                    //TB_DELITO.Enabled = false;
                    //tb_imputado.Enabled = false;
                    //TB_VICTIMA.Enabled = false;
                    //dataGridView1.Enabled = false;

                    //checkBox1.Checked = false;
                    //checkBox2.Checked = false;

                    //checkBox5.Checked = false;


                    //checkBox1.Enabled = false;
                    //checkBox2.Enabled = false;

                    //checkBox5.Enabled = false;

                    //bt_aceptar.Enabled = false;



                }
                else if (cb_solicitud.Text == "ORDEN DE APREHENSIÓN")
                {

                    //CON.Eliminar_Disponibilidad("disponibilidad");
                    registrar_ordenes();
                    Registro_causas();
                    registrar_DAI();

                    mostrarDatos();
                    //TB_CARP_JUD.Enabled = false;
                    //TB_NUM_OFICIO.Enabled = false;
                    //DT_FECHA_RECEP.Enabled = false;
                    ////cb_solicitud.Enabled = false;
                    //TB_DELITO.Enabled = false;
                    //tb_imputado.Enabled = false;
                    //TB_VICTIMA.Enabled = false;
                    //dataGridView1.Enabled = false;

                    //checkBox1.Checked = false;
                    //checkBox2.Checked = false;

                    //checkBox5.Checked = false;


                    //checkBox1.Enabled = false;
                    //checkBox2.Enabled = false;

                    //checkBox5.Enabled = false;

                    //bt_aceptar.Enabled = false;


                }
                else if (cb_solicitud.Text == "CONTROL DE DETENCIÓN")
                {

                    // CON.Eliminar_Disponibilidad("disponibilidad");
                    registrar_control();
                    Registro_causas();

                    registrar_DAI();
                    mostrarDatos();
                    //TB_CARP_JUD.Enabled = false;
                    //TB_NUM_OFICIO.Enabled = false;
                    //DT_FECHA_RECEP.Enabled = false;
                    ////cb_solicitud.Enabled = false;
                    //TB_DELITO.Enabled = false;
                    //tb_imputado.Enabled = false;
                    //TB_VICTIMA.Enabled = false;
                    //dataGridView1.Enabled = false;

                    //checkBox1.Checked = false;
                    //checkBox2.Checked = false;

                    //checkBox5.Checked = false;


                    //checkBox1.Enabled = false;
                    //checkBox2.Enabled = false;

                    //checkBox5.Enabled = false;

                    //bt_aceptar.Enabled = false;


                }

                else
                {
                    MessageBox.Show("SELECCIONA UN TIPO DE SOLICITUD");
                }
            }
            else if (comboBox1.Text == "DELITO DE BAJO IMPACTO")
            {
                if (cb_solicitud.Text == "FORMULACION DE IMPUTACIÓN")
                {
                    // CON.Eliminar_Disponibilidad("disponibilidad");
                    registrar_formulacion();
                    Registro_causas();
                    registrar_DBI();
                    mostrarDatos();

                    //TB_CARP_JUD.Enabled = false;
                    //TB_NUM_OFICIO.Enabled = false;
                    //DT_FECHA_RECEP.Enabled = false;
                    ////cb_solicitud.Enabled = false;
                    //TB_DELITO.Enabled = false;
                    //tb_imputado.Enabled = false;
                    //TB_VICTIMA.Enabled = false;
                    //dataGridView1.Enabled = false;

                    //checkBox1.Checked = false;
                    //checkBox2.Checked = false;

                    //checkBox5.Checked = false;


                    //checkBox1.Enabled = false;
                    //checkBox2.Enabled = false;

                    //checkBox5.Enabled = false;

                    //bt_aceptar.Enabled = false;


                }
                else if (cb_solicitud.Text == "ORDEN DE APREHENSIÓN")
                {

                    //CON.Eliminar_Disponibilidad("disponibilidad");
                    registrar_ordenes();
                    Registro_causas();
                    registrar_DBI();

                    mostrarDatos();
                    //TB_CARP_JUD.Enabled = false;
                    //TB_NUM_OFICIO.Enabled = false;
                    //DT_FECHA_RECEP.Enabled = false;
                    ////cb_solicitud.Enabled = false;
                    //TB_DELITO.Enabled = false;
                    //tb_imputado.Enabled = false;
                    //TB_VICTIMA.Enabled = false;
                    //dataGridView1.Enabled = false;

                    //checkBox1.Checked = false;
                    //checkBox2.Checked = false;

                    //checkBox5.Checked = false;


                    //checkBox1.Enabled = false;
                    //checkBox2.Enabled = false;

                    //checkBox5.Enabled = false;

                    //bt_aceptar.Enabled = false;

                }
                else if (cb_solicitud.Text == "CONTROL DE DETENCIÓN")
                {

                    // CON.Eliminar_Disponibilidad("disponibilidad");
                    registrar_control();
                    Registro_causas();

                    registrar_DBI();
                    mostrarDatos();
                    //TB_CARP_JUD.Enabled = false;
                    //TB_NUM_OFICIO.Enabled = false;
                    //DT_FECHA_RECEP.Enabled = false;
                    ////cb_solicitud.Enabled = false;
                    //TB_DELITO.Enabled = false;
                    //tb_imputado.Enabled = false;
                    //TB_VICTIMA.Enabled = false;
                    //dataGridView1.Enabled = false;

                    //checkBox1.Checked = false;
                    //checkBox2.Checked = false;

                    //checkBox5.Checked = false;


                    //checkBox1.Enabled = false;
                    //checkBox2.Enabled = false;

                    //checkBox5.Enabled = false;

                    //bt_aceptar.Enabled = false;


                }

                else
                {
                    MessageBox.Show("SELECCIONA UN TIPO DE SOLICITUD");
                }

            }
            else
            {
                MessageBox.Show("INGRESA EL ESTATUS DEL DELITO");
            }
            //groupBox1.Enabled = true;
            //tb_imputado.Enabled = true;
            //pictureBox1.Enabled = true;
            //pictureBox5.Enabled = true;
            //dataGridView2.Enabled = true;
            //TB_VICTIMA.Enabled = true;
            //pictureBox4.Enabled = true;
            //pictureBox6.Enabled = true;
            //dataGridView3.Enabled = true;
            //cb_solicitud.Enabled = true;

            DISPONIBILIDAD_JUECES rf = new DISPONIBILIDAD_JUECES();
            rf.Show();
            this.Hide();


        }
        private void registrar_DBI() {
            c9 = Convert.ToInt32(label24.Text);
            c10 = Convert.ToInt32(TB_SUMA_DBI.Text);

            SUMA_DBI = c9 + c10;
            TB_RE_DBI.Text = SUMA_DBI.ToString();
            string actualiza_DBI = "DELITO_BAJO_IMPACTO = " + TB_RE_DBI.Text + "";
            CON.actualizar("Jueces", actualiza_DBI, "id = " + id.Text);

           

        }
        private void registrar_DAI() {
            c7 = Convert.ToInt32(label23.Text);
            c8 = Convert.ToInt32(tb_suma_DAI.Text);
            suma_DAI = c7 + c8;
            TB_RESULT_DAI.Text = suma_DAI.ToString();
            string actualiza_DAI = "DELITO_ALTO_IMPACTO = " + TB_RESULT_DAI.Text + "";
            CON.actualizar("Jueces", actualiza_DAI, "id = " + id.Text);

           


        }
        private void registrar_control() {

            c5 = Convert.ToInt32(label21.Text);
            c6 = Convert.ToInt32(tb_indice_control.Text);

            suma_control = c5 + c6;

           textBox2.Text  = suma_control.ToString();

            string actualizar_control = "CONTROL_DETENCION =" + textBox2.Text + " ";
            CON.actualizar("Jueces", actualizar_control, "id = " + id.Text);

        }
        private void registrar_ordenes() {


            c3 = Convert.ToInt32(label19.Text);
            c4 = Convert.ToInt32(tb_indice_ordenes.Text);

            suma_ordenes = c3 + c4;

            tb_resul_ordenes.Text = suma_ordenes.ToString();

            string actualizar_ordenes = "ORDENES_A =" + tb_resul_ordenes.Text + " ";
            CON.actualizar("Jueces", actualizar_ordenes, "id = " + id.Text);

        }
        private void registrar_formulacion() {// metodo para actualizar el campo de formulaciones
           
            
            c1 = Convert.ToInt32(label17.Text);
            c2 = Convert.ToInt32(tb_indice_formulacion.Text);

            suma_formulacion = c1 + c2;

            tb_resultado_formulacion.Text = suma_formulacion.ToString();

            string actualizar_formulacion = "FORMULACIONES =" + tb_resultado_formulacion.Text + " ";
            CON.actualizar("Jueces", actualizar_formulacion, "id = " + id.Text);
          
            

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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_restaurar.Visible = false;
            btn_maximizar.Visible = true;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox7.Checked)
            //{
            //    mostrarDatosImputados();
            //    label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            //    MessageBox.Show("EL JUEZ CON MENOS IMPUTADOS ES EL LIC.:" + label10.Text);

            //    checkBox1.Checked = false;
            //    checkBox2.Checked = false;
            //    checkBox3.Checked = false;
            //    checkBox4.Checked = false;
            //    checkBox5.Checked = false;
            //    checkBox6.Checked = false;
            //    TB_JUEZ.Text = label10.Text;

            //}
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            //if (checkBox3.Checked)
            //{

            //    mostrarDatosBajoI();
            //    label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            //    MessageBox.Show("EL JUEZ CON MENOS DELITOS DE BAJO IMPACTO ES EL LIC.:" + label10.Text);

            //    checkBox1.Checked = false;
            //    checkBox2.Checked = false;
            //    checkBox5.Checked = false;
            //    checkBox4.Checked = false;
            //    checkBox6.Checked = false;
            //    checkBox7.Checked = false;
            //    TB_JUEZ.Text = label10.Text;

            //}
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox6.Checked)
            //{
            //    mostrarDatosImputados();
            //    label10.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            //    MessageBox.Show("EL JUEZ CON MENOS IMPUTADOS ES EL LIC.:" + label10.Text);

            //    checkBox1.Checked = false;
            //    checkBox2.Checked = false;
            //    checkBox3.Checked = false;
            //    checkBox4.Checked = false;
            //    checkBox5.Checked = false;
            //    checkBox7.Checked = false;
            //    TB_JUEZ.Text = label10.Text;

            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {


            CON.Eliminar_Disponibilidad("disponibilidad");

            Registro_causas();



        }

        public void Registro_causas() {

            //AQUI SE REGISTRA LOS DATOS DE LA CAUSA PENAL EN LA BASE DE DATOS
            string agregar1 = "insert into Causa_Penal (CARPETA_JUDICIAL, NUM_OFICIO, FECHA_RECEPCION, TIPO_SOLICITUD, DELITO, TOTAL_IMPUTADOS, TOTAL_VICTIMAS, JUEZ, DEPENDENCIA) values('" + TB_CARP_JUD.Text + "', '" + TB_NUM_OFICIO.Text + "', '" + DT_FECHA_RECEP.Text + "', '" + cb_solicitud.Text + "', '" + TB_DELITO.Text + "', " + CONT_IMP_2.Text + ", " + CONT_VICT_2.Text + ", '" + TB_JUEZ.Text + "', '"+comboBox2.Text+"' )";// se inserta dato en la tabla disponibilidad
            if (CON.insertar(agregar1))
            {

                //MessageBox.Show("CAUSA PENAL REGISTRADA");
                NotificacionCausaPenal();
                //EnviarWhatsapp();


            }
            else {

                MessageBox.Show("NO SE PUDO REGISTRAR LA CAUSA PENAL");
            }

            // AQUI SE ACTUALIZA EL TOTAL DE IMPUTADOS 
            string actualizar2 = "TOTAL_IMPUTADOS =" + TB_CONT_IMPU.Text + ", TOTAL_VICTIMAS=" + TB_CONT_VICTIMA.Text + " ";

            if (CON.actualizar("Jueces", actualizar2, "id = " + id.Text))
            {
                //MessageBox.Show("LOS DATOS SE MODIFICARON CORRECTAMENTE!!");

            }
            else
            {

                MessageBox.Show("ERROR AL ACTULIZAR  LOS DATOS");

            }


            //aqui se actualiza el total de CARPETAS JUDICILES




            B1 = Convert.ToInt32(label14.Text);
            B2 = Convert.ToInt32(TB_INDICE_SUMA.Text);

            SUMA_CARPETAS = B1 + B2;

            TB_RESULTADO.Text = SUMA_CARPETAS.ToString();



            string actualizar_TOTAL_CARPETAS = "TOTAL_CARPETAS=" + TB_RESULTADO.Text + "";
            if (CON.actualizar("Jueces", actualizar_TOTAL_CARPETAS, "id="+ id.Text)) {

                //MessageBox.Show("LOS DATOS SE MODIFICARON CORRECTAMENTE!!");
            }
            else
            {

                MessageBox.Show("ERROR AL ACTULIZAR  LOS DATOS");

            }

  

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (TB_VICTIMA.Text == "")
            {


                MessageBox.Show("no se ha registrado ningun Victima", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                NOM_VICTIMA = TB_VICTIMA.Text;//NOM AHORA CONTIENE LO QUE TIENE EL TEXTBOX DE IMPUTADO
                dataGridView3.Rows.Add(NOM_VICTIMA);//AGREGARMOS  AL DATAGRIDVIWS LO QUE TENEMOS EN LA VARIABLE NOM
                dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//AJUSTAMOS EL CONTENIDO DE LA FILA AL DATAGRID
                TB_CONT_VICTIMA.Text = dataGridView3.Rows.Count.ToString();
                CONT_VICT_2.Text = dataGridView3.Rows.Count.ToString();

                A1 = Convert.ToInt32(TB_CONT_VICTIMA.Text);
                A2 = Convert.ToInt32(label13.Text);

                SUMA_VICTIMAS = A1 + A2;

                TB_CONT_VICTIMA.Text = SUMA_VICTIMAS.ToString();

                TB_VICTIMA.Text = "";

            }
        }
    }
}
