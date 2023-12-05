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
    public partial class Form3 : Form
    {
        public Form3()
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

        private void button5_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Nome", "Senha");
            usuario.Id = int.Parse(textBox1.Text);
            usuario.Nome = textBox2.Text;
            usuario.Senha = Criptografia.CriptografarSenha(textBox3.Text);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.UpdateUsuario(usuario);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            UpdateListView();
        }

        private void listaView_DockChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeleteUsuario(id);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            UpdateListView();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listaView_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listaView.FocusedItem.Index;
            textBox1.Text = listaView.Items[index].SubItems[0].Text;
            textBox3.Text = listaView.Items[index].SubItems[1].Text;
            textBox2.Text = listaView.Items[index].SubItems[2].Text;

            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
