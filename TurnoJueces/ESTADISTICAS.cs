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
using System.Windows.Forms.DataVisualization.Charting;

namespace TurnoJueces
{
    public partial class ESTADISTICAS : Form
    {
        public ESTADISTICAS()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void ESTADISTICAS_Load(object sender, EventArgs e)
        {
            mostrarDatos();
            J1.Text = dataGridView1.Rows[0].Cells["NOMBRE"].Value.ToString();
            J2.Text = dataGridView1.Rows[1].Cells["NOMBRE"].Value.ToString();
            J3.Text = dataGridView1.Rows[2].Cells["NOMBRE"].Value.ToString();
            J4.Text = dataGridView1.Rows[3].Cells["NOMBRE"].Value.ToString();
            J5.Text = dataGridView1.Rows[4].Cells["NOMBRE"].Value.ToString();
            J6.Text = dataGridView1.Rows[5].Cells["NOMBRE"].Value.ToString();
            J7.Text = dataGridView1.Rows[6].Cells["NOMBRE"].Value.ToString();
            J8.Text = dataGridView1.Rows[7].Cells["NOMBRE"].Value.ToString();
            J9.Text = dataGridView1.Rows[8].Cells["NOMBRE"].Value.ToString();
            J10.Text = dataGridView1.Rows[9].Cells["NOMBRE"].Value.ToString();
            // cargarIndices_TOTAL_CARPETAS();
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;//centrar la ventana
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            //DataGridView.Sort(DataGridView[], ListSortDirection.Ascending);
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            //dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
        }

        public void imprimir()
        {
            Directory.Delete("C:\\PDFs\\", true);

            chart1.SaveImage("C:\\Recursos_TurnosJueces\\mychart1.png", ChartImageFormat.Png);
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
            PdfWriter.GetInstance(document, new FileStream(folderPath + "Estadisticas.pdf", FileMode.OpenOrCreate));
            document.Open();
            // var fuente_texto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, Element.ALIGN_CENTER);
            iTextSharp.text.Font fuente = new iTextSharp.text.Font();
            document.Add(new Paragraph("                                                            REPORTE DE ESTADISTICAS DE LOS JUECES DEL JUZGADO DE CONTROL DE ACAPULCO"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("                      " + comboBox1.Text));
            document.Add(new Paragraph("\n"));
           //document.Add(pdfTable);
            
            iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance(@"C:\Recursos_TurnosJueces\mychart1.png");
            imagen3.BorderWidth = 0;
            imagen3.Alignment = Element.ALIGN_CENTER;
            float percentage3 = 0.0f;
            percentage3 = 80 / imagen3.Width;
            imagen3.ScalePercent(percentage3 * 990);
            imagen3.SetAbsolutePosition(50, 15);


            document.Add(imagen3);

           


            //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Recursos_TurnosJueces\21761930_1498902300203631_6112178357467530526_n.jpg");
            //imagen.BorderWidth = 0;
            //imagen.Alignment = Element.ALIGN_LEFT;
            //float percentage = 0.0f;
            //percentage = 80 / imagen.Width;
            //imagen.ScalePercent(percentage * 150);
            //imagen.SetAbsolutePosition(870, 510);

            //iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(@"C:\Recursos_TurnosJueces\12299228_1526794907618863_1923735897809301275_n.png");
            //imagen2.BorderWidth = 0;
            //imagen2.Alignment = Element.ALIGN_LEFT;
            //float percentage2 = 0.0f;
            //percentage2 = 80 / imagen2.Width;
            //imagen2.ScalePercent(percentage2 * 70);
            //imagen2.SetAbsolutePosition(50, 525);

            //// Insertamos la imagen en el documento
            //document.Add(imagen);
            //document.Add(imagen2);

            document.Close();

            System.Diagnostics.Process.Start(@"C:\PDFs\Estadisticas.pdf");


        }




        //CODIGI PARA PODER MOVER LA VENTANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

       
        public void mostrarDatos()
        {
            CON.consulta("select * from Jueces order by TOTAL_CARPETAS", "Jueces");
            dataGridView1.DataSource = CON.ds.Tables["Jueces"];


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void cargarIndices_TOTAL_CARPETAS() {

            //int IndA, IndB, IndC, IndD, IndE, IndF, IndG, IndH, IndI, IndJ;
            I1.Text = dataGridView1.Rows[0].Cells["TOTAL_CARPETAS"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["TOTAL_CARPETAS"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["TOTAL_CARPETAS"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["TOTAL_CARPETAS"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["TOTAL_CARPETAS"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["TOTAL_CARPETAS"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["TOTAL_CARPETAS"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["TOTAL_CARPETAS"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["TOTAL_CARPETAS"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["TOTAL_CARPETAS"].Value.ToString();

            //IndA = Convert.ToInt32(I1.Text);
            //IndB = Convert.ToInt32(I2.Text);
            //IndC = Convert.ToInt32(I3.Text);
            //IndD = Convert.ToInt32(I4.Text);
            //IndE = Convert.ToInt32(I5.Text);
            //IndF = Convert.ToInt32(I6.Text);
            //IndG = Convert.ToInt32(I7.Text);
            //IndH = Convert.ToInt32(I8.Text);
            //IndI = Convert.ToInt32(I9.Text);
            //IndJ = Convert.ToInt32(I10.Text);
            //dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);


        }
        public void cargarIndices_FORMULACIONES()
        {

            I1.Text = dataGridView1.Rows[0].Cells["FORMULACIONES"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["FORMULACIONES"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["FORMULACIONES"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["FORMULACIONES"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["FORMULACIONES"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["FORMULACIONES"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["FORMULACIONES"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["FORMULACIONES"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["FORMULACIONES"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["FORMULACIONES"].Value.ToString();
        }
        public void cargarIndices_ORDENES()
        {

            I1.Text = dataGridView1.Rows[0].Cells["ORDENES_A"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["ORDENES_A"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["ORDENES_A"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["ORDENES_A"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["ORDENES_A"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["ORDENES_A"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["ORDENES_A"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["ORDENES_A"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["ORDENES_A"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["ORDENES_A"].Value.ToString();



        }
        public void cargarIndices_CONTROL_DETENCION()
        {

            I1.Text = dataGridView1.Rows[0].Cells["CONTROL_DETENCION"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["CONTROL_DETENCION"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["CONTROL_DETENCION"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["CONTROL_DETENCION"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["CONTROL_DETENCION"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["CONTROL_DETENCION"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["CONTROL_DETENCION"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["CONTROL_DETENCION"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["CONTROL_DETENCION"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["CONTROL_DETENCION"].Value.ToString();

        }
        public void cargarIndices_DAI()
        {

            I1.Text = dataGridView1.Rows[0].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["DELITO_ALTO_IMPACTO"].Value.ToString();

        }
        public void cargarIndices_DBI()
        {

            I1.Text = dataGridView1.Rows[0].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["DELITO_BAJO_IMPACTO"].Value.ToString();

        }
        public void cargarIndices_TOTAL_IMPUTADOS()
        {

            I1.Text = dataGridView1.Rows[0].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["TOTAL_IMPUTADOS"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["TOTAL_IMPUTADOS"].Value.ToString();
        }
        public void cargarIndices_TOTAL_VICTIMAS()
        {

            I1.Text = dataGridView1.Rows[0].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I2.Text = dataGridView1.Rows[1].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I3.Text = dataGridView1.Rows[2].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I4.Text = dataGridView1.Rows[3].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I5.Text = dataGridView1.Rows[4].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I6.Text = dataGridView1.Rows[5].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I7.Text = dataGridView1.Rows[6].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I8.Text = dataGridView1.Rows[7].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I9.Text = dataGridView1.Rows[8].Cells["TOTAL_VICTIMAS"].Value.ToString();
            I10.Text = dataGridView1.Rows[9].Cells["TOTAL_VICTIMAS"].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
               if (comboBox1.Text == "TOTAL CARPETAS")
            {

                using (TurnosEntities3 db = new TurnosEntities3())
                {
                    cargarIndices_TOTAL_CARPETAS();

                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE"; 
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "TOTAL_CARPETAS";
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    

                }



            }
            else if (comboBox1.Text == "FORMULACION DE IMPUTACION")
            {

                using (TurnosEntities3 db = new TurnosEntities3())
                {

                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "FORMULACIONES";
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_FORMULACIONES();

                }

            }
            else if (comboBox1.Text == "ORDENES DE APREHENSIÓN")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "ORDENES_A";//cargamos de la tabla jueces el numero de ordenes de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_ORDENES();
                }
            }
            else if (comboBox1.Text == "CONTROL DE DETENCIÓN")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "CONTROL_DETENCION";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_CONTROL_DETENCION();
                }
            }
            else if (comboBox1.Text == "DELITO DE ALTO IMPACTO")
            {
                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "DELITO_ALTO_IMPACTO";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_DAI();
                }
            }
            else if (comboBox1.Text == "DELITO DE BAJO IMPACTO")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "DELITO_BAJO_IMPACTO";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_DBI();
                }

            }
            else if (comboBox1.Text == "TOTAL DE IMPUTADOS")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "TOTAL_IMPUTADOS";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_TOTAL_IMPUTADOS();
                }

            }
            else if (comboBox1.Text == "TOTAL DE VICTIMAS") {
                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "TOTAL_VICTIMAS";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_TOTAL_VICTIMAS();
                }

            }

           }

        private void BarraTitulo_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MENU2 RF = new MENU2();
            RF.Show();
            this.Hide();
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //imprimir();
           
            chart1.Printing.PrintPreview();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //chart1.Printing.PrintPreview();

            
            imprimir();
     
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //chart1.Series[0].Sort(PointSortOrder.Ascending, "x");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "TOTAL CARPETAS")
            {

                using (TurnosEntities3 db = new TurnosEntities3())
                {

                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "TOTAL_CARPETAS";
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_TOTAL_CARPETAS();

                }



            }
            else if (comboBox1.Text == "FORMULACION DE IMPUTACION")
            {

                using (TurnosEntities3 db = new TurnosEntities3())
                {

                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "FORMULACIONES";
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_FORMULACIONES();

                }

            }
            else if (comboBox1.Text == "ORDENES DE APREHENSIÓN")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "ORDENES_A";//cargamos de la tabla jueces el numero de ordenes de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_ORDENES();
                }
            }
            else if (comboBox1.Text == "CONTROL DE DETENCIÓN")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "CONTROL_DETENCION";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_CONTROL_DETENCION();
                }
            }
            else if (comboBox1.Text == "DELITO DE ALTO IMPACTO")
            {
                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "DELITO_ALTO_IMPACTO";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_DAI();
                }
            }
            else if (comboBox1.Text == "DELITO DE BAJO IMPACTO")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "DELITO_BAJO_IMPACTO";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_DBI();
                }

            }
            else if (comboBox1.Text == "TOTAL DE IMPUTADOS")
            {

                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "TOTAL_IMPUTADOS";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_TOTAL_IMPUTADOS();
                }

            }
            else if (comboBox1.Text == "TOTAL DE VICTIMAS")
            {
                using (TurnosEntities3 db = new TurnosEntities3())//usando el mapeado de la base de datos
                {
                    chart1.DataSource = db.Jueces.ToList();
                    chart1.Series["Jueces"].XValueMember = "NOMBRE";//cargamos de la tabla jueces el nombre en el de x
                    chart1.Series["Jueces"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                    chart1.Series["Jueces"].YValueMembers = "TOTAL_VICTIMAS";//cargamos de la tabla jueces el numero de controles de aprencion en el eje y
                    chart1.Series["Jueces"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    cargarIndices_TOTAL_VICTIMAS();
                }

            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {
        
            

        }
    }
    }
    
    

