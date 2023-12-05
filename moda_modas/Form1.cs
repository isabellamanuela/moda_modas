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
        public editar()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listaView.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.Id.ToString());
                item.SubItems.Add(usuario.Nome);
                item.SubItems.Add(usuario.Senha);
                listaView.Items.Add(item);
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


        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("O campo de senha está vazio. Por favor, insira uma senha válida.");
            }
            else if (checkBox1.Checked)
            {
                Usuario usuario = new Usuario("Nome", "Senha");
                usuario.Nome = textBox1.Text;
                usuario.Senha = Criptografia.CriptografarSenha(textBox3.Text);

                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.InsertUsuario(usuario);
                textBox1.Clear();
                textBox3.Clear();
                UpdateListView();
            }
            else
            {
                MessageBox.Show("Você precisa aceitar os Termos e Condições para se cadastrar.",
                    "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
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
            this.Close();
        }


        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void Lista_MouseDoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listaView.FocusedItem.Index;
            id = int.Parse(listaView.Items[index].SubItems[0].Text);
            textBox1.Text = listaView.Items[index].SubItems[1].Text;
            textBox3.Text = listaView.Items[index].SubItems[2].Text;

            UpdateListView();
        }

    }

}
