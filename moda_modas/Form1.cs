using moda_modas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace moda_modas
{
    public partial class editar : Form
    {
        private int id;
        Thread fdp;
        public editar()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listaView.Items.Clear();
            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Table_2";
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();
                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    int id = (int)dr["id"];
                    string Nome = (string)dr["Nome"];
                    string Senha = (string)dr["Senha"];
                    ListViewItem lv = new ListViewItem(id.ToString());
                    lv.SubItems.Add(Nome);
                    lv.SubItems.Add(Senha);
                    listaView.Items.Add(lv);
                }
                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Nome = textBox1.Text;
            string enrollment = textBox3.Text;


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
            sqlCommand.CommandText = @"UPDATE Table_2 SET
            Nome  =  @textBox1.Text,
            Senha = textBox3.Text
            WHERE id = @id ";

            sqlCommand.Parameters.AddWithValue("Nome", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("Senha", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Cadastrado com sucesso",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

              textBox1.Clear();
              textBox3.Clear();
            UpdateListView();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE Table_2 SET
            Nome     = @Nome,
            Senha    = @Senha,
            WHERE id = @id";

            
            sqlCommand.Parameters.AddWithValue("@Nome", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Senha", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show(
                " Login alterado com sucesso !",
                "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);



            textBox1.Clear();
            textBox3.Clear();
            UpdateListView();
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();



            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Table_2 VALUES(@Nome,@Senha)";



            sqlCommand.Parameters.AddWithValue("@Nome", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Senha", textBox3.Text);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Cadastro com sucesso",
                "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);



            textBox1.Clear();
            textBox3.Clear();
            UpdateListView();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String senha = textBox3.Text;
            if (name == "" && senha == "")
            {
                this.Close();
                fdp = new Thread(novoForm);
                fdp.SetApartmentState(ApartmentState.STA);
                fdp.Start();
            }
            else
            {
               String message = "Nome: " + name +
                                "\nSenha: " + senha;
                MessageBox.Show(message, "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                    );
            }
        }
        private void novoForm()
        {
            Application.Run(new Form2());
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Código para excluir
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Table_2 WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }

            textBox1.Clear();
            textBox3.Clear();

            UpdateListView();


        }

        private void Lista_MouseDoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listaView.FocusedItem.Index;
            id = int.Parse(listaView.Items[index].SubItems[0].Text);
            textBox1.Text = listaView.Items[index].SubItems[1].Text;
            textBox3.Text = listaView.Items[index].SubItems[2].Text;
        }
    }

}
