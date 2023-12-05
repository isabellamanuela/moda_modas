using moda_modas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace moda_modas
{
    internal class UsuarioDAO
    {
        public void LoginUsuario(Usuario usuario)
        {
            // Conexão com o banco de dados
            Connection connect = new Connection();
            SqlConnection connection = connect.ReturnConnection();

            // Consulta SQL para verificar se o usuário existe
            string query = "SELECT ID FROM Table_2 WHERE Nome=@nome AND Senha=@Senha";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nome", usuario.Nome);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            int userId = Convert.ToInt32(command.ExecuteScalar());

            if (userId > 0)
            {
                MessageBox.Show("Login feito com sucesso");
                Form2 form2 = new Form2(userId);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Erro ao fazer login");
            }

            connect.CloseConnection();

        }
        public List<Usuario> SelectUsuario()
        {

            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = "SELECT * FROM Table_2 ";

            List<Usuario> Usuario = new List<Usuario>();

            try
            {
                SqlDataReader dr = sqlCommand.ExecuteReader();

                //Enquanto for possivel continuar a leitura
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                        (int)dr["id"],
                        (string)dr["Nome"],
                        (string)dr["Senha"]
                        );

                    Usuario.Add(objeto);
                }

                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
            return Usuario;
        }
        public List<Usuario> SelectUsuario1()
        {

            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = "SELECT * FROM Table_3 ";

            List<Usuario> Usuario = new List<Usuario>();

            try
            {
                SqlDataReader dr = sqlCommand.ExecuteReader();

                //Enquanto for possivel continuar a leitura
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                        (int)dr["ID"],
                        (string)dr["Rua"],
                        (string)dr["Bairro"],
                        (string)dr["Numero"],
                        (string)dr["CEP"]
                        );

                    Usuario.Add(objeto);
                }

                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
            return Usuario;
        }
        public void InsertUsuario(Usuario usuario)
        {
            Connection conexao = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Table_2 VALUES(@Nome,@Senha)";
            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Criado Com Sucesso Seu Cadastro",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        public void InsertUsuario1(Usuario usuario)
        {
            Connection conexao = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Table_3 VALUES(@Rua,@Bairro,@Numero,@CEP)";
            sqlCommand.Parameters.AddWithValue("@Rua", usuario.Rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.CEP);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Criado Com Sucesso Seu Cadastro",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        public void DeleteUsuario(int id)
        {
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
        }
        public void DeleteUsuario1(int id)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Table_3 WHERE id = @id";
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
        }
        public void UpdateUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE Table_2 SET
            Nome = @Nome,
            Senha = @Senha
            WHERE id = @id ";

            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@id", usuario.Id);
            sqlCommand.ExecuteNonQuery();

        }
        public void UpdateUsuario1(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE Table_3 SET
            Rua = @Rua,
            Bairro = @Bairro,
            Numero=@Numero,
            CEP=@CEP
            WHERE id = @id ";

            sqlCommand.Parameters.AddWithValue("@Rua", usuario.Rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.CEP);
            sqlCommand.Parameters.AddWithValue("@id", usuario.Id);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
