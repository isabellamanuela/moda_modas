using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moda_modas
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Nome", "Senha");
            usuario.Nome = textBox1.Text;
            usuario.Senha = Criptografia.CriptografarSenha(textBox2.Text);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.LoginUsuario(usuario);

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            editar fomr1 = new editar();
            fomr1.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            form3.Show();
        }
    }
}
