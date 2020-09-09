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
    public partial class JUECES_NODISP : Form
    {
        public JUECES_NODISP()
        {
            InitializeComponent();
        }
        CONEXION CON = new CONEXION();
        private void JUECES_NODISP_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void consulta() {

            CON.consulta("select  * from bitacora_disponibilidad where fecha = '" + dateTimePicker1.Text + "'", "bitacora_disponibilidad");
            dataGridView1.DataSource = CON.ds.Tables["bitacora_disponibilidad"];

           
            dataGridView1.Columns[1].HeaderText = "NOMBRE";
            dataGridView1.Columns[2].HeaderText = "ESTATUS DE LA DISPONIBILIDAD";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderText = "MOTIVO DE NO DISPONIBILIDAD";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderText = "FECHA";


            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
            consulta();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
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
            //using (FileStream stream = new FileStream(folderPath + "Juez_no_Disponible.pdf", FileMode.Create))
            //{
            //    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();
            //    pdfDoc.Add(pdfTable);
            //    pdfDoc.Close();
            //    stream.Close();
            //}
            Document document = new Document(iTextSharp.text.PageSize.LEGAL.Rotate());
            PdfWriter.GetInstance(document, new FileStream(folderPath + "Juez_no_Disponible.pdf", FileMode.OpenOrCreate));
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

            ////Insertamos la imagen en el documento
            //document.Add(imagen);
            //document.Add(imagen2);

            document.Close();

            System.Diagnostics.Process.Start(@"C:\PDFs\Juez_no_Disponible.pdf");


        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CAUSA_PENAL2 RF = new CAUSA_PENAL2();
            RF.Show();
            this.Hide();
        }
    }
}
