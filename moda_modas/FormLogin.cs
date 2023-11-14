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
            string usuario = textBox1.Text;
            string senha = textBox2.Text;

            //Criar objeto da classe UsuarioDAO
            UsuarioDAO Usuario = new UsuarioDAO();

            //Chamar o metodo que verifica  o Login

            if (Usuario.LoginUsuario(usuario, senha)) {
                editar tela = new editar();
                tela.ShowDialog();

            }
            else
            {
                MessageBox.Show("Verifique os dados inseridos!",
                    "ERROUUUU",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
