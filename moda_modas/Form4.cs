using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace moda_modas
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listaView.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario1();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.Id.ToString());
                item.SubItems.Add(usuario.Rua);
                item.SubItems.Add(usuario.Bairro);
                item.SubItems.Add(usuario.Numero);
                item.SubItems.Add(usuario.CEP);
                listaView.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua","Bairro","Numero","CEP");
            usuario.Rua = textBox2.Text;
            usuario.Bairro = textBox3.Text;
            usuario.Numero = textBox4.Text;
            usuario.CEP = textBox5.Text;


            UsuarioDAO usuarioDAO = new UsuarioDAO();
            textBox1.Clear();
            usuarioDAO.InsertUsuario1(usuario);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            UpdateListView();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua", "Bairro", "Numero", "CEP");
            usuario.Id = int.Parse(textBox1.Text);
            usuario.Rua = textBox2.Text;
            usuario.Bairro = textBox3.Text;
            usuario.Numero = textBox4.Text;
            usuario.CEP = textBox5.Text;


            UsuarioDAO usuarioDAO = new UsuarioDAO();
            textBox1.Clear();
            usuarioDAO.UpdateUsuario1(usuario);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            UpdateListView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeleteUsuario1(id);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            UpdateListView();
        }
    }
}
