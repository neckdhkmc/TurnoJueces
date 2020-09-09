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
    
    public partial class DISPONIBILIDAD_JUECES : Form
    {
        public DISPONIBILIDAD_JUECES()
        {
            InitializeComponent();
        }


        CONEXION CON = new CONEXION();
       
          

        private void DISPONIBILIDAD_JUECES_Load(object sender, EventArgs e)
        {

            mostrarDatos();

            // lb_nom_vianey.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();

            lb_nom_vianey.Text = dataGridView1.Rows[0].Cells["NOMBRE"].Value.ToString();
            lb_andres.Text = dataGridView1.Rows[1].Cells["NOMBRE"].Value.ToString();
            lb_edil.Text = dataGridView1.Rows[2].Cells["NOMBRE"].Value.ToString();
            lb_vicente.Text = dataGridView1.Rows[3].Cells["NOMBRE"].Value.ToString();
            lb_Salvador.Text = dataGridView1.Rows[4].Cells["NOMBRE"].Value.ToString();
            lb_emanuel.Text = dataGridView1.Rows[5].Cells["NOMBRE"].Value.ToString();
            lb_rodrigo.Text = dataGridView1.Rows[6].Cells["NOMBRE"].Value.ToString();
            lb_victor.Text = dataGridView1.Rows[7].Cells["NOMBRE"].Value.ToString();
            lb_nuevo1.Text = dataGridView1.Rows[8].Cells["NOMBRE"].Value.ToString();
            lb_nuevo2.Text = dataGridView1.Rows[9].Cells["NOMBRE"].Value.ToString();


        }
        public void mostrarDatos()
        {
            CON.consulta("select  * from jueces", "jueces");
            dataGridView1.DataSource = CON.ds.Tables["jueces"];
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]//mover el formulario
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]//mover el formulario

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.BackColor = Color.Green;
                checkBox2.Enabled = false;
                IND_Vianey.Checked = true;
             
               
               
            }
            else if(checkBox1.Checked == false) {

                checkBox2.Enabled = true;
                checkBox1.BackColor = Color.Transparent;
                IND_Vianey.Checked = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            //......................

            if (checkBox2.Checked)
            {
                checkBox2.BackColor = Color.Red;
                checkBox1.Enabled = false;
       

                lb_nom_vianey.Enabled = false;
                lb_uno.Enabled = false;
 

                CB_VIANEY.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_Vianey.Checked = true;



            }
            else if (checkBox1.Checked == false)
            {

               checkBox1.Enabled = true;
               checkBox2.BackColor = Color.Transparent;
                //labels del nombre y numero
               lb_nom_vianey.Enabled = true;
               lb_uno.Enabled = true;
                //muestra el textArea
               CB_VIANEY.Visible = false;
                LB_MOTIVO.Visible = false;
                IND_Vianey.Checked = false;

            }

            //.....................



        }

        private void check_andres_dispo_CheckedChanged(object sender, EventArgs e)
        {
            if (check_andres_dispo.Checked)
            {
                check_andres_dispo.BackColor = Color.Green;
               check_andres_nodispo.Enabled = false;
                IND_ANDRES.Checked = true;

               
             
            }
            else if (check_andres_dispo.Checked == false)
            {

                check_andres_nodispo.Enabled = true;
                check_andres_dispo.BackColor = Color.Transparent;
                IND_ANDRES.Checked = false;

            }
        }

        private void check_andres_nodispo_CheckedChanged(object sender, EventArgs e)
        {
            if  (check_andres_nodispo.Checked)
                {
                    check_andres_nodispo.BackColor = Color.Red;
                    check_andres_dispo.Enabled = false;
                    //labels del nombre y numero
                    lb_andres.Enabled = false;
                    lb_dos.Enabled = false;
                //muestra el textArea

                    CB_ANDRES.Visible = true;
                    LB_MOTIVO.Visible = true;
                IND_ANDRES.Checked = true;
            }
                else if (check_andres_dispo.Checked == false)
                {

                  check_andres_dispo.Enabled = true;
                   check_andres_nodispo.BackColor = Color.Transparent;
                    //labels del nombre y numero
                   lb_andres.Enabled = true;
                   lb_dos.Enabled = true;
                //muestra el textArea
                CB_ANDRES.Visible = false;
                LB_MOTIVO.Visible = false;
                IND_ANDRES.Checked = false;

            }
        }

        private void check_dis_calderon_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_calderon.Checked)
            {
                check_dis_calderon.BackColor = Color.Green;
                check_nodis_claderon.Enabled = false;
                IND_EDILBERTO.Checked = true;

               
               
            }
            else if (check_dis_calderon.Checked == false)
            {

                check_nodis_claderon.Enabled = true;
                check_dis_calderon.BackColor = Color.Transparent;
                IND_EDILBERTO.Checked = false;

            }
        }

        private void check_nodis_claderon_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_claderon.Checked)
            {
                check_nodis_claderon.BackColor = Color.Red;
                check_dis_calderon.Enabled = false;
                //labels del nombre y numero
                lb_edil.Enabled = false;
                lb_tres.Enabled = false;
                //muestra el textArea

                CB_EDILBERTO.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_EDILBERTO.Checked = true;
            }
            else if (check_dis_calderon.Checked == false)
            {

                check_dis_calderon.Enabled = true;
                check_nodis_claderon.BackColor = Color.Transparent;
                //labels del nombre y numero
                lb_edil.Enabled = true;
                lb_tres.Enabled = true;
                //muestra el textArea
                CB_EDILBERTO.Visible = false;
                LB_MOTIVO.Visible = false;
                IND_EDILBERTO.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_vicente.Checked)
            {
                check_dis_vicente.BackColor = Color.Green;
                check_nodis_vicente.Enabled = false;
                IND_VICENTE.Checked = true;
                //agregarmos al data grid
              
            }
            else if (check_dis_vicente.Checked == false)
            {

                check_nodis_vicente.Enabled = true;
                check_dis_vicente.BackColor = Color.Transparent;
                IND_VICENTE.Checked = false;
                

            }
        }

        private void check_nodis_vicente_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_vicente.Checked)
            {
                check_nodis_vicente.BackColor = Color.Red;
                check_dis_vicente.Enabled = false;
                //labels del nombre y numero
                lb_vicente.Enabled = false;
                lb_cuatro.Enabled = false;
                //muestra el textArea

                CB_VICENTE.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_VICENTE.Checked = true;


            }
            else if (check_dis_vicente.Checked == false)
            {

                check_dis_vicente.Enabled = true;
                check_nodis_vicente.BackColor = Color.Transparent;
                lb_vicente.Enabled = true;
                lb_cuatro.Enabled = true;
                CB_VICENTE.Visible = false;
                IND_VICENTE.Checked = false;
            }

        }

        private void check_dis_salvador_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_salvador.Checked)
            {
                check_dis_salvador.BackColor = Color.Green;
               check_nodis_salvador.Enabled = false;
                IND_SALVADOR.Checked = true;

               
            }
            else if (check_dis_salvador.Checked == false)
            {

                check_nodis_salvador.Enabled = true;
                check_dis_salvador.BackColor = Color.Transparent;
                IND_SALVADOR.Checked = false;

            }
        }

        private void check_nodis_salvador_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_salvador.Checked)
            {
                check_nodis_salvador.BackColor = Color.Red;
                check_dis_salvador.Enabled = false;
                //labels del nombre y numero
               lb_Salvador.Enabled = false;
               lb_cinco.Enabled = false;
                //muestra el textArea

                CB_SALVADOR.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_SALVADOR.Checked = true;



            }
            else if (check_dis_salvador.Checked == false)
            {

               check_dis_salvador.Enabled = true;
                check_nodis_salvador.BackColor = Color.Transparent;
                //labels del nombre y numero
                lb_Salvador.Enabled = true;
               lb_cinco.Enabled = true;
                //muestra el textArea
                CB_SALVADOR.Visible = false;
                LB_MOTIVO.Visible = false;
                IND_SALVADOR.Checked = false;

            }
        }

        private void check_dis_emanuel_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_emanuel.Checked)
            {
                check_dis_emanuel.BackColor = Color.Green;
                check_nodis_emanuel.Enabled = false;
                IND_EMANUEL.Checked = true;

            
            }
            else if (check_dis_emanuel.Checked == false)
            {

                check_nodis_emanuel.Enabled = true;
                check_dis_emanuel.BackColor = Color.Transparent;
                IND_EMANUEL.Checked = false;
            }
        }

        private void check_nodis_emanuel_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_emanuel.Checked)
            {
               check_nodis_emanuel.BackColor = Color.Red;
               check_dis_emanuel.Enabled = false;
                //labels del nombre y numero
               lb_emanuel.Enabled = false;
               lb_seis.Enabled = false;
                //muestra el textArea

                CB_EMANUEL.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_EMANUEL.Checked = true;

            }
            else if (check_dis_emanuel.Checked == false)
            {

                check_dis_emanuel.Enabled = true;
                check_nodis_emanuel.BackColor = Color.Transparent;
                //labels del nombre y numero
                lb_emanuel.Enabled = true;
                lb_seis.Enabled = true;
                //muestra el textArea
                CB_EMANUEL.Visible = false;
                LB_MOTIVO.Visible = false;
                IND_EMANUEL.Checked = false;

            }
        }

        private void check_dis_rodrigo_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_rodrigo.Checked)
            {
                check_dis_rodrigo.BackColor = Color.Green;
               check_nodis_rodrigo.Enabled = false;
                IND_RODRIGO.Checked = true;
                //agregarmos al data grid
               
            }
            else if (check_dis_rodrigo.Checked == false)
            {

                check_nodis_rodrigo.Enabled = true;
                check_dis_rodrigo.BackColor = Color.Transparent;
                IND_RODRIGO.Checked = false;

            }
        }

        private void check_nodis_rodrigo_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_rodrigo.Checked)
            {
                check_nodis_rodrigo.BackColor = Color.Red;
                check_dis_rodrigo.Enabled = false;
                //labels del nombre y numero
                lb_rodrigo.Enabled = false;
                lb_siete.Enabled = false;
                //muestra el textArea

                CB_RODRIGO.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_RODRIGO.Checked = true;


            }
            else if (check_dis_rodrigo.Checked == false)
            {

                check_dis_rodrigo.Enabled = true;
                check_nodis_rodrigo.BackColor = Color.Transparent;
                //labels del nombre y numero
                lb_rodrigo.Enabled = true;
                lb_siete.Enabled = true;
                //muestra el textArea
                CB_RODRIGO.Visible = false;
                LB_MOTIVO.Visible = false;
                IND_RODRIGO.Checked = false;

            }
        }

        private void check_dis_victor_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_victor.Checked)
            {
               check_dis_victor.BackColor = Color.Green;
               check_nodis_victor.Enabled = false;
                IND_VICTOR.Checked = true;

               
            }
            else if (check_dis_victor.Checked == false)
            {

              check_nodis_victor.Enabled = true;
              check_dis_victor.BackColor = Color.Transparent;
                IND_VICTOR.Checked = false;

            }
        }

        private void check_nodis_victor_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_victor.Checked)
            {
             check_nodis_victor.BackColor = Color.Red;
              check_dis_victor.Enabled = false;
                //labels del nombre y numero
               lb_victor.Enabled = false;
               lb_ocho.Enabled = false;
                //muestra el textArea

                CB_VICTOR.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_VICTOR.Checked = true;

            }
            else if (check_dis_victor.Checked == false)
            {

                check_dis_victor.Enabled = true;
                check_nodis_victor.BackColor = Color.Transparent;
                //labels del nombre y numero
                 lb_victor.Enabled = true;
                lb_ocho.Enabled = true;
                //muestra el textArea
                CB_VICTOR.Visible = false; 
                LB_MOTIVO.Visible = false;
                IND_VICTOR.Checked = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {




            //insertar disponibilidad de juez vianey 

            if (IND_Vianey.Checked & IND_ANDRES.Checked & IND_EDILBERTO.Checked & IND_RODRIGO.Checked & IND_EMANUEL.Checked & IND_SALVADOR.Checked & IND_VICENTE.Checked & IND_VICTOR.Checked)
            {

                //1.-disponibilidad juez vianey
                if (checkBox1.Checked)
                {

                    string agregar1 = "insert into disponibilidad (nombre) values('" + lb_nom_vianey.Text + "')";// se inserta dato en la tabla disponibilidad
                    CON.insertar(agregar1);


                    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                    string actualizar = "ESTATUS='" + checkBox1.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_uno.Text);
                   

                }
                else if (checkBox2.Checked)
                {

                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_nom_vianey.Text + "', '" + checkBox2.Text + "', '" + CB_VIANEY.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + checkBox2.Text + "'";
                    CON.actualizar("jueces", actualizar, "id=" + lb_uno.Text);//modifica el estatus



                }

                //................................................................

                //2.-Disponibilidad de juez andres.

                if (check_andres_dispo.Checked)
                {

                    string agregar1 = "insert into disponibilidad (nombre) values('" + lb_andres.Text + "')";
                    CON.insertar(agregar1);

                    string actualizar = "ESTATUS='" + check_andres_dispo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_dos.Text);

                }
                else if (check_andres_nodispo.Checked)
                {

                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_andres.Text + "', '" + check_andres_nodispo.Text + "', '" + CB_ANDRES.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" +check_andres_nodispo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_dos.Text);



                }
                //.....................................................................

                //3.-disponibilidad del juez edilberto



                if (check_dis_calderon.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_edil.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_calderon.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_tres.Text);
                }
                else if (check_nodis_claderon.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_edil.Text + "', '" + check_nodis_claderon.Text + "', '" + CB_EDILBERTO.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_claderon.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_tres.Text);
                }

                //............................................................................

                //4.-disponibilidad del juez vicente

                if (check_dis_vicente.Checked)
                {
                    string agregar = "insert into disponibilidad (nombre) values ('" + lb_vicente.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_vicente.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cuatro.Text);
                }
                else if (check_nodis_vicente.Checked)
                {
                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_vicente.Text + "', '" + check_nodis_vicente.Text + "', '" + CB_VICENTE.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);


                    string actualizar = "ESTATUS='" + check_nodis_vicente.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cuatro.Text);

                }



                //.............................................................................................

                //5.-disponibilidad del juez salvador

                if (check_dis_salvador.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_Salvador.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_salvador.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cinco.Text);

                }
                else if (check_nodis_salvador.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_Salvador.Text + "', '" + check_nodis_salvador.Text + "', '" + CB_SALVADOR.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);


                    string actualizar = "ESTATUS='" + check_nodis_salvador.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cinco.Text);
                }



                //...............................................................................................................................
                //6.-disponibilidad del juez emanuel
                if (check_dis_emanuel.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_emanuel.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_emanuel.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_seis.Text);
                }
                else if (check_nodis_emanuel.Checked)
                {

                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_emanuel.Text + "', '" + check_nodis_emanuel.Text + "', '" + CB_EMANUEL.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_emanuel.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_seis.Text);
                }

                //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                //7.- disponibilidad del juez rodrigo


                if (check_dis_rodrigo.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_rodrigo.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_rodrigo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_siete.Text);
                }
                else if (check_nodis_rodrigo.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_rodrigo.Text + "', '" + check_nodis_rodrigo.Text + "', '" + CB_RODRIGO.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_rodrigo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_siete.Text);
                }

                //....................................................................................................................................
                //8.- disponibilidad del juez victor


                if (check_dis_victor.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_victor.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_victor.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_ocho.Text);
                }
                else if (check_nodis_victor.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_victor.Text + "', '" + check_nodis_victor.Text + "', '" + CB_VICTOR.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_victor.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_ocho.Text);
                }





                tb_resul_control RF = new tb_resul_control();
                RF.Show();


            }
            else
            {

                MessageBox.Show("REVISAR DISPONIBILIDAD DE TODOS LOS JUECES");

            }
            // mostrarDatos();


         


        }

        private void button2_Click(object sender, EventArgs e)
        {


            //insertar disponibilidad de juez vianey 

            if (IND_Vianey.Checked & IND_ANDRES.Checked & IND_EDILBERTO.Checked & IND_RODRIGO.Checked & IND_EMANUEL.Checked & IND_SALVADOR.Checked & IND_VICENTE.Checked & IND_VICTOR.Checked & IND_NUEVO1.Checked & IND_NUEVO2.Checked)
            {

                //1.-disponibilidad juez vianey
                if (checkBox1.Checked)
                {

                    string agregar1 = "insert into disponibilidad (nombre) values('" + lb_nom_vianey.Text + "')";// se inserta dato en la tabla disponibilidad
                    CON.insertar(agregar1);


                    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                    string actualizar = "ESTATUS='" + checkBox1.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_uno.Text);


                }
                else if (checkBox2.Checked)
                {

                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_nom_vianey.Text + "', '" + checkBox2.Text + "', '" + CB_VIANEY.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + checkBox2.Text + "'";
                    CON.actualizar("jueces", actualizar, "id=" + lb_uno.Text);//modifica el estatus



                }

                //................................................................

                //2.-Disponibilidad de juez andres.

                if (check_andres_dispo.Checked)
                {

                    string agregar1 = "insert into disponibilidad (nombre) values('" + lb_andres.Text + "')";
                    CON.insertar(agregar1);

                    string actualizar = "ESTATUS='" + check_andres_dispo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_dos.Text);

                }
                else if (check_andres_nodispo.Checked)
                {

                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_andres.Text + "', '" + check_andres_nodispo.Text + "', '" + CB_ANDRES.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_andres_nodispo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_dos.Text);



                }
                //.....................................................................

                //3.-disponibilidad del juez edilberto



                if (check_dis_calderon.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_edil.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_calderon.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_tres.Text);
                }
                else if (check_nodis_claderon.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_edil.Text + "', '" + check_nodis_claderon.Text + "', '" + CB_EDILBERTO.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_claderon.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_tres.Text);
                }

                //............................................................................

                //4.-disponibilidad del juez vicente

                if (check_dis_vicente.Checked)
                {
                    string agregar = "insert into disponibilidad (nombre) values ('" + lb_vicente.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_vicente.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cuatro.Text);
                }
                else if (check_nodis_vicente.Checked)
                {
                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_vicente.Text + "', '" + check_nodis_vicente.Text + "', '" + CB_VICENTE.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);


                    string actualizar = "ESTATUS='" + check_nodis_vicente.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cuatro.Text);

                }



                //.............................................................................................

                //5.-disponibilidad del juez salvador

                if (check_dis_salvador.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_Salvador.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_salvador.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cinco.Text);

                }
                else if (check_nodis_salvador.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_Salvador.Text + "', '" + check_nodis_salvador.Text + "', '" + CB_SALVADOR.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);


                    string actualizar = "ESTATUS='" + check_nodis_salvador.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_cinco.Text);
                }



                //...............................................................................................................................
                //6.-disponibilidad del juez emanuel
                if (check_dis_emanuel.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_emanuel.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_emanuel.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_seis.Text);
                }
                else if (check_nodis_emanuel.Checked)
                {

                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_emanuel.Text + "', '" + check_nodis_emanuel.Text + "', '" + CB_EMANUEL.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_emanuel.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_seis.Text);
                }

                //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                //7.- disponibilidad del juez rodrigo


                if (check_dis_rodrigo.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_rodrigo.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_rodrigo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_siete.Text);
                }
                else if (check_nodis_rodrigo.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_rodrigo.Text + "', '" + check_nodis_rodrigo.Text + "', '" + CB_RODRIGO.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_rodrigo.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_siete.Text);
                }

                //....................................................................................................................................
                //8.- disponibilidad del juez victor


                if (check_dis_victor.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_victor.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_victor.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_ocho.Text);
                }
                else if (check_nodis_victor.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_victor.Text + "', '" + check_nodis_victor.Text + "', '" + CB_VICTOR.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_nodis_victor.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_ocho.Text);
                }

                //.............................................................................................
                //DISPONIBILIDAD JUEZ 9

                if (check_dis_nuevo1.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" +lb_nuevo1.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_nuevo1.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_nueve.Text);

                }
                else if (check_nodis_nuevo1.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_nuevo1.Text + "', '" + check_nodis_nuevo1.Text + "', '" + cb_nuevo1.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);


                    string actualizar = "ESTATUS='" +check_nodis_nuevo1.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" +lb_nueve.Text);
                }
                //.............................................................................................
                //DISPONIBILIDAD JUEZ 10

                if (check_dis_nuevo2.Checked)
                {

                    string agregar = "insert into disponibilidad (nombre) values('" + lb_nuevo2.Text + "')";
                    CON.insertar(agregar);

                    string actualizar = "ESTATUS='" + check_dis_nuevo2.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_diez.Text);

                }
                else if (check_nodis_nuevo2.Checked)
                {


                    string agregar = "insert into bitacora_disponibilidad(nom, disponibilidad, motivo, fecha) values('" + lb_nuevo2.Text + "', '" + check_nodis_nuevo2.Text + "', '" + cb_nuevo2.Text + "', '" + dt_fecha.Text + "')";
                    CON.insertar(agregar);


                    string actualizar = "ESTATUS='" + check_nodis_nuevo2.Text + "'";//modifica el estatus
                    CON.actualizar("jueces", actualizar, "id=" + lb_diez.Text);
                }


                tb_resul_control RF = new tb_resul_control();
                RF.TB_NUM_OFICIO.Text = label3.Text;
                RF.Show();
                this.Hide();


            }
            else
            {

                MessageBox.Show("REVISAR DISPONIBILIDAD DE TODOS LOS JUECES");

            }
            // mostrarDatos();

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void DISPONIBILIDAD_JUECES_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void IND_VICTOR_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CB_VICTOR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lb_ocho_Click(object sender, EventArgs e)
        {

        }

        private void lb_victor_Click(object sender, EventArgs e)
        {

        }

        private void cb_nuevo1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void check_nodis_nuevo1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_nuevo1.Checked)
            {
                check_nodis_nuevo1.BackColor = Color.Red;
                check_dis_nuevo1.Enabled = false;
                //labels del nombre y numero
                lb_nuevo1.Enabled = false;
                lb_nueve.Enabled = false;
                //muestra el textArea

                cb_nuevo1.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_NUEVO1.Checked = true;

            }
            else if (check_dis_nuevo1.Checked == false)
            {

               check_dis_nuevo1.Enabled = true;
               check_nodis_nuevo1.BackColor = Color.Transparent;
                //labels del nombre y numero
               lb_nuevo1.Enabled = true;
               lb_nueve.Enabled = true;
                //muestra el textArea
               cb_nuevo1.Visible = false;
                LB_MOTIVO.Visible = false;
               IND_NUEVO1.Checked = false;

            }
        }

        private void check_nodis_nuevo2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_nodis_nuevo2.Checked)
            {
                check_nodis_nuevo2.BackColor = Color.Red;
                check_dis_nuevo2.Enabled = false;
                //labels del nombre y numero
                lb_nuevo2.Enabled = false;
                lb_diez.Enabled = false;
                //muestra el textArea

                cb_nuevo2.Visible = true;
                LB_MOTIVO.Visible = true;
                IND_NUEVO2.Checked = true;

            }
            else if (check_dis_nuevo2.Checked == false)
            {

                check_dis_nuevo2.Enabled = true;
                check_nodis_nuevo2.BackColor = Color.Transparent;
                //labels del nombre y numero
                lb_nuevo2.Enabled = true;
                lb_diez.Enabled = true;
                //muestra el textArea
                cb_nuevo2.Visible = false;
                LB_MOTIVO.Visible = false;
                IND_NUEVO2.Checked = false;

            }
        }

        private void check_dis_nuevo1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_nuevo1.Checked)
            {
                check_dis_nuevo1.BackColor = Color.Green;
               check_nodis_nuevo1.Enabled = false;
               IND_NUEVO1.Checked = true;


            }
            else if (check_dis_nuevo1.Checked == false)
            {

                check_nodis_nuevo1.Enabled = true;
                check_dis_nuevo1.BackColor = Color.Transparent;
                IND_NUEVO1.Checked = false;

            }
        }

        private void check_dis_nuevo2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dis_nuevo2.Checked)
            {
                check_dis_nuevo2.BackColor = Color.Green;
                check_nodis_nuevo2.Enabled = false;
                IND_NUEVO2.Checked = true;


            }
            else if (check_dis_nuevo2.Checked == false)
            {

                check_nodis_nuevo2.Enabled = true;
                check_dis_nuevo2.BackColor = Color.Transparent;
                IND_NUEVO2.Checked = false;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {

                check_dis_nuevo1.Checked = true;
                check_dis_nuevo2.Checked = true;
                check_dis_rodrigo.Checked = true;
                check_dis_salvador.Checked = true;
                check_dis_vicente.Checked = true;
                check_dis_victor.Checked = true;
                check_dis_emanuel.Checked = true;
                check_dis_calderon.Checked = true;
                checkBox1.Checked = true;
                check_andres_dispo.Checked = true;
                
            
            }
        }
    }

}

