﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnoJueces
{
    public partial class MenuSolicitud : Form
    {
        public MenuSolicitud()
        {
            InitializeComponent();
        }

        private void MenuSolicitud_Load(object sender, EventArgs e)
        {
            txt_pass.PasswordChar = '*';
        }

        public void AUTENTICACION()
        {
            //SqlConnection con = new SqlConnection("Server =(local)\\SQLEXPRESS; Initial Catalog = Turnos; Integrated Security = True");// CREAMOS UN METODO  CONEXION EL CUAL CONTENDRA LA CADENA DE CONEXION LA CUAL SERA EL MEDIO PARA PODER  TENER ACCESO A LA BASE DE DATOS
            //SqlConnection con = new SqlConnection("Server =(local); Initial Catalog = Turnos; Integrated Security = True");
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-4BK74NR\\SQLEXPRESS; Initial Catalog = Turnos; Integrated Security = True");

            con.Open();

            SqlCommand consulta = new SqlCommand("select * from usuarios where nickname= '" + txt_user.Text + "' and pass ='" + txt_pass.Text + "'", con);
            SqlDataReader ejecutar = consulta.ExecuteReader();
            if (ejecutar.Read() == true)
            {


                //MessageBox.Show("AUTORIZACION ACEPTADA");
                MessageBox.Show("AUTORIZACION ACEPTADA", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EDITAR_REGISTROS RF = new EDITAR_REGISTROS();
                RF.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("AUTORIZACION RECHASADA REVISA USUARIO Y CONTRASEÑA", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                con.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AUTENTICACION();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
        }
    }
}