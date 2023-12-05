using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace moda_modas
{
    public partial class Form2 : Form

    {
        private int userId;
        Thread fdp;
        public Form2(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            fdp = new Thread(novoForm);
            fdp.SetApartmentState(ApartmentState.STA);
            fdp.Start();
        }
        private void novoForm()
        {
            Application.Run(new editar());
        }
        bool visivel = false;
        bool visivel1 = false;
        bool visivel2 = false;
        bool visivel3 = false;
        private void button1_Click(object sender, EventArgs e)
        {

            if (visivel)
            {
                pictureBox1.Visible = false;
                visivel = false;
            }
            else
            {
                pictureBox1.Visible = true;
                visivel = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (visivel2)
            {
                pictureBox3.Visible = false;
                visivel2 = false;
            }
            else
            {
                pictureBox3.Visible = true;
                visivel2 = true;

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (visivel3)
            {
                pictureBox4.Visible = false;
                visivel3 = false;
            }
            else
            {
                pictureBox4.Visible = true;
                visivel3 = true;

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            monthCalendar1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (visivel1)
            {
                pictureBox2.Visible = false;
                visivel1 = false;
            }
            else
            {
                pictureBox2.Visible = true;
                visivel1 = true;
            }
        }
        bool visivel4 = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (visivel4)
            {
                pictureBox5.Visible = false;
                visivel4 = false;
            }
            else
            {
                pictureBox5.Visible = true;
                visivel4 = true;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start > DateTime.Today)
            {
                MessageBox.Show("A encomenda chegará dia " + e.Start.ToShortDateString(),
                    "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não é possível enviar encomendas para os dias passados",
                    "ERRO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                monthCalendar1.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            SqlConnection connection = connect.ReturnConnection();

            string query = "SELECT * FROM Table_2 WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Document document = new Document();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PdfWriter.GetInstance(document, new FileStream(path + "/Relatorio.pdf", FileMode.Create));
            document.Open();
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    document.Add(new Paragraph(row[column].ToString()));
                }
            }
            document.Close();
            connect.CloseConnection();

            MessageBox.Show("Relatório gerado com sucessoo!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}