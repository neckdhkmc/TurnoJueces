using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class CORREO : Form
    {
        public CORREO()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        EnviarCorreo c = new EnviarCorreo();
        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            c.enviarCorreo(txtEmisor.Text, txtPassword.Text, rtbMensaje.Text, txtAsunto.Text, txtReceptor.Text, txtRutaArchivo.Text);
            txtReceptor.Text = "";
            txtAsunto.Text = "";
            txtAsunto.Text = "";
            txtRutaArchivo.Text = "";
            rtbMensaje.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    txtRutaArchivo.Text = this.openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ruta del archivo: " + ex.ToString());
            }
        }

        private void CORREO_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mostrarDatos2();
        }
        public void mostrarDatos2()
        {


            CON.consulta("select  * from Jueces", "Jueces");
            dataGridView1.DataSource = CON.ds.Tables["Jueces"];


        }//

        //public void imprimir()
        //{
            
        //    Directory.Delete("C:\\pdf_datos_jueces\\", true);
        //    PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
        //    pdfTable.DefaultCell.Padding = 3;
        //    pdfTable.WidthPercentage = 103;
        //    pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
        //    pdfTable.DefaultCell.BorderWidth = 1;

        //    foreach (DataGridViewColumn column in dataGridView1.Columns)
        //    {
        //        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
        //        cell.BackgroundColor = new iTextSharp.text.BaseColor(137, 243, 126);

        //        pdfTable.AddCell(cell);
        //    }
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            pdfTable.AddCell(cell.Value.ToString());
        //        }
        //    }

        //    //Exporting to PDF
        //    //string folderPath = "C:\\PDFs\\";
        //    string folderPath = "C:\\pdf_datos_jueces\\";
        //    if (!Directory.Exists(folderPath))
        //    {
        //        Directory.CreateDirectory(folderPath);
        //    }
        //    //using (FileStream stream = new FileStream(folderPath + "Datos_Jueces.pdf", FileMode.Create))
        //    //{
        //    //    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
        //    //    PdfWriter.GetInstance(pdfDoc, stream);
        //    //    pdfDoc.Open();
        //    //    pdfDoc.Add(pdfTable);
        //    //    pdfDoc.Close();
        //    //    stream.Close();
        //    //}
        //    Document document = new Document(iTextSharp.text.PageSize.LEGAL.Rotate());
        //    PdfWriter.GetInstance(document, new FileStream(folderPath + "Datos_Juecez.pdf", FileMode.OpenOrCreate));
        //    document.Open();
        //    // var fuente_texto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
        //    //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, Element.ALIGN_CENTER);
        //    iTextSharp.text.Font fuente = new iTextSharp.text.Font();
        //    document.Add(new Paragraph("                                                                                                REPORTE DE JUECES DEL JUZGADO DE CONTROL DE ACAPULCO"));
        //    document.Add(new Paragraph("\n"));
        //    document.Add(new Paragraph("\n"));
        //    document.Add(pdfTable);


        //    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Recursos_TurnosJueces\21761930_1498902300203631_6112178357467530526_n.jpg");
        //    imagen.BorderWidth = 0;
        //    imagen.Alignment = Element.ALIGN_LEFT;
        //    float percentage = 0.0f;
        //    percentage = 80 / imagen.Width;
        //    imagen.ScalePercent(percentage * 150);
        //    imagen.SetAbsolutePosition(870, 510);

        //    iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(@"C:\Recursos_TurnosJueces\12299228_1526794907618863_1923735897809301275_n.png");
        //    imagen2.BorderWidth = 0;
        //    imagen2.Alignment = Element.ALIGN_LEFT;
        //    float percentage2 = 0.0f;
        //    percentage2 = 80 / imagen2.Width;
        //    imagen2.ScalePercent(percentage2 * 70);
        //    imagen2.SetAbsolutePosition(50, 525);

        //    // Insertamos la imagen en el documento
        //    document.Add(imagen);
        //    document.Add(imagen2);

        //    document.Close();

        //    //System.Diagnostics.Process.Start(@"C:\PDFs\Datos_Juecez.pdf");

        //    MessageBox.Show("REPORTE GENERADO CORRECTAMENTE LISTO PARA ADJUNTAR EN EL CORREO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //imprimir();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBox2.Image = System.Drawing.Image.FromFile(imagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Directory.Delete("C:\\pdf_datos_jueces\\", true);
            //PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            //pdfTable.DefaultCell.Padding = 3;
            //pdfTable.WidthPercentage = 103;
            //pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfTable.DefaultCell.BorderWidth = 1;

            //foreach (DataGridViewColumn column in dataGridView1.Columns)
            //{
            //    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //    cell.BackgroundColor = new iTextSharp.text.BaseColor(137, 243, 126);

            //    pdfTable.AddCell(cell);
            //}
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        pdfTable.AddCell(cell.Value.ToString());
            //    }
            //}

            ////Exporting to PDF
            ////string folderPath = "C:\\PDFs\\";
            //string folderPath = "C:\\pdf_datos_jueces\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
           
            //Document document = new Document(iTextSharp.text.PageSize.LETTER);
            //PdfWriter.GetInstance(document, new FileStream(folderPath + "Datos_Juecez.pdf", FileMode.OpenOrCreate));
            //document.Open();
            //// var fuente_texto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            ////var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, Element.ALIGN_CENTER);
            //iTextSharp.text.Font fuente = new iTextSharp.text.Font();
            //document.Add(new Paragraph(" REPORTE DE JUECES DEL JUZGADO DE CONTROL DE ACAPULCO"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
      


            //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(openFileDialog1.FileName);
            //imagen.BorderWidth = 0;
            //imagen.Alignment = Element.ALIGN_LEFT;
            //float percentage = 0.0f;
            //percentage = 150 / imagen.Width;
            //imagen.ScalePercent(percentage * 80);



            // Insertamos la imagen en el documento
            
         

            //document.Close();

            //System.Diagnostics.Process.Start(@"C:\PDFs\Datos_Juecez.pdf");

            //MessageBox.Show("REPORTE GENERADO CORRECTAMENTE LISTO PARA ADJUNTAR EN EL CORREO", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            System.Diagnostics.Process.Start(@"C:\pdf_datos_jueces\Datos_Juecez.pdf");
        }
    }
}
