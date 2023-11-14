using moda_modas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace moda_modas
{
    internal class UsuarioDAO
    {
        public bool LoginUsuario(string usuario, string senha)
        {

            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Table_2  WHERE" +
                " Nome =  @nome AND Senha = @senha";
            sqlCom.Parameters.AddWithValue("@nome", usuario);
            sqlCom.Parameters.AddWithValue("@senha", senha);


            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    return true;
                }

                dr.Close();
                return false;
            }

            catch (Exception err)
            {
                throw new Exception("Eroo:Problemas ao excluir usuario no banco.\n" + err.Message);
            }

            finally
            {
                conn.CloseConnection();
            }

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







        public void InsertUsuario(Usuario usuario)
        {
            Connection conexao = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Table_2 VALUES(@Nome,@Senha)";
            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);


            sqlCommand.ExecuteNonQuery();
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







        public void UpdateUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE Table_2 SET
            Nome = @Nome,
            Senha = @Senha,
            WHERE id = @id ";

            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@id", usuario.Id);
            sqlCommand.ExecuteNonQuery();

        }





    }
}
