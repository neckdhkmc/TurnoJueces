using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoEmail;

namespace Mensajeria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnviarEmail x = new EnviarEmail();
            string usu = "Escribe tu correo";
            string pass = "Escribe tu contraseña";
            bool exito = x.EnviarMail(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,usu,pass);
            if (exito == true)
            {
                MessageBox.Show("Correo enviado");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                
            }
            else {
                MessageBox.Show("El Correo no se envio");
            }
        }
    }
}
