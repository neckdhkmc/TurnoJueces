using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class BUSQUEDAS : Form
    {
        public BUSQUEDAS()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "JUEZ")
            {

                TB_JUEZ.Visible = true;

                CB_TIPO_SOLICITUD.Visible = false;
                dateTimePicker1.Visible = false;
            }
            else if (comboBox2.Text == "CARPETA JUDICIAL")
            {

                TB_JUEZ.Visible = true;
                CB_TIPO_SOLICITUD.Visible = false;
                dateTimePicker1.Visible = false;
                
            }
            else if (comboBox2.Text == "FECHA")
            {

                TB_JUEZ.Visible = false;
                CB_TIPO_SOLICITUD.Visible = false;
                dateTimePicker1.Visible = true;
            }
            else if (comboBox2.Text == "TIPO DE SOLICITUD") {

                CB_TIPO_SOLICITUD.Visible = true;
                dateTimePicker1.Visible = false;
                TB_JUEZ.Visible = false;

            }
            else if (comboBox2.Text == "IMPUTADO") {

                CB_TIPO_SOLICITUD.Visible = false;
                dateTimePicker1.Visible = false;
                TB_JUEZ.Visible = true; ;

            }
            else if (comboBox2.Text == "VICTIMA")
            {

                CB_TIPO_SOLICITUD.Visible = false;
                dateTimePicker1.Visible = false;
                TB_JUEZ.Visible = true; ;

            }
            else if (comboBox2.Text == "DELITOS")
            {

                CB_TIPO_SOLICITUD.Visible = false;
                dateTimePicker1.Visible = false;
                TB_JUEZ.Visible = true; ;

            }
            else if (comboBox2.Text == "CAUSA PENAL")
            {
                mostrarCausasPenales();
                CB_TIPO_SOLICITUD.Visible = false;
                dateTimePicker1.Visible = true;
                TB_JUEZ.Visible = false;

            }
        }
        public void mostrarCausasPenales() {
            
            //CON.consulta("select  * from Causa_Penal order by CAST(CARPETA_JUDICIAL AS INT) ASC", "Causa_Penal");
            CON.consulta("select  * from Causa_Penal order by CARPETA_JUDICIAL", "Causa_Penal");
            dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
            dataGridView1.Columns["ID"].Visible = false;


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
        }
        private void bt_aceptar_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "JUEZ")
            {
                CON.consulta("select  * from Causa_Penal where JUEZ = '" + TB_JUEZ.Text + "'", "Causa_Penal");
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);

            }
            else if (comboBox2.Text == "CARPETA JUDICIAL")
            {
                CON.consulta("select  * from Causa_Penal where CARPETA_JUDICIAL = '" + TB_JUEZ.Text + "'", "Causa_Penal");
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);


            }
            else if (comboBox2.Text == "FECHA")
            {
                CON.consulta("select  * from Causa_Penal where FECHA_RECEPCION = '" + dateTimePicker1.Text + "'", "Causa_Penal");
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);

            }
            else if (comboBox2.Text == "TIPO DE SOLICITUD")
            {
                CON.consulta("select  * from Causa_Penal where TIPO_SOLICITUD = '" + CB_TIPO_SOLICITUD.Text + "'", "Causa_Penal");
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);

            }
            else if (comboBox2.Text == "IMPUTADO")
            {
                CON.consulta("select  * from Causa_Penal where TOTAL_IMPUTADOS = '" + TB_JUEZ.Text + "'", "Causa_Penal");
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);

            }
            else if (comboBox2.Text == "VICTIMA")
            {
                CON.consulta("select  * from Causa_Penal where TOTAL_VICTIMAS = '" + TB_JUEZ.Text + "'", "Causa_Penal");
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);

            }
            else if (comboBox2.Text == "DELITOS")
            {
                CON.consulta("select  * from Causa_Penal where DELITO = '" + TB_JUEZ.Text + "'", "Causa_Penal");
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
            }
            else if (comboBox2.Text == "CAUSA PENAL")
            {
                CON.consulta("select  * from Causa_Penal where FECHA_RECEPCION = '"+dateTimePicker1.Text+ "' order by CARPETA_JUDICIAL ", "Causa_Penal");
               
                dataGridView1.DataSource = CON.ds.Tables["Causa_Penal"];
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma",12, FontStyle.Bold);

            }
            else { MessageBox.Show("SELECCIONA UNA BUSQUEDA"); }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_maximizar.Visible = false;
            btn_restaurar.Visible = true;
        }

        private void BUSQUEDAS_Load(object sender, EventArgs e)
        {
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
            //mostrarCausasPenales();
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
     private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MENU2 rf = new MENU2();
            rf.Show();
            this.Hide();
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            btn_restaurar.Visible = false;
            btn_maximizar.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            imprimir_juez();
        }
        public void imprimir_juez()
        {
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
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            //using (FileStream stream = new FileStream(folderPath + "consulta.pdf", FileMode.Create))
            //{
            //    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();
            //    pdfDoc.Add(pdfTable);
            //    pdfDoc.Close();
            //    stream.Close();
            //}
            Document document = new Document(iTextSharp.text.PageSize.LEGAL.Rotate());
            PdfWriter.GetInstance(document, new FileStream( folderPath+"consulta.pdf", FileMode.OpenOrCreate));
            document.Open();
            // var fuente_texto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, Element.ALIGN_CENTER);
            iTextSharp.text.Font fuente = new iTextSharp.text.Font();
            document.Add(new Paragraph("                                                                                                REPORTE DE JUECES DEL JUZGADO DE CONTROL DE ACAPULCO"));
            document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("                      " + DT_FECHA_RECEP.Text));
            document.Add(new Paragraph("\n"));
            document.Add(pdfTable);


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

            ////Insertamos la imagen en el documento;
            //document.Add(imagen);
            //document.Add(imagen2);

            document.Close();

            System.Diagnostics.Process.Start(@"C:\PDFs\consulta.pdf");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
