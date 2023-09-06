using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace moda_modas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string enrollment = textBox2.Text;


            MessageBox.Show("ta baratooo hein!",
                "ATENÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information

                );
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Student VALUES (@name,@e-mail,senha)";  


            sqlCommand.Parameters.AddWithValue("name", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("e-mail", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("senha", textBox3.Text);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Cadastrado com sucesso",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

              textBox1.Clear();
              textBox2.Clear();
              textBox3.Clear();





        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
