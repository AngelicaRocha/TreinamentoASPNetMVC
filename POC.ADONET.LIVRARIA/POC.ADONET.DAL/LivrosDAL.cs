using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;
using System.Data.SqlClient;

namespace POC.ADONET.DAL
{
    public class LivrosDAL
    {
        Repository repoDB;

        //Instancia Banco de Dados
        private void InstanciarRepositorio()
        {
            if (repoDB == null)
            {
                //Se não tiver, crio uma
                repoDB = new Repository();

                //Adiciona a string de conexão
                //repoDB.Conn.ConnectionString = "Data Source=3P47_01;Initial Catalog=pubs;User ID=sa;Password=Imp@ct@";
                repoDB.Conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = pubs; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

                //Atribuindo o objeto SlConnections ja instanciado para a propriedade conection
                repoDB.Cmd.Connection = repoDB.Conn;
            }
        }

        public List<LivrosMOD> GetBooks()
        {
            SqlDataReader dataReader = null;
            List<LivrosMOD> listaLivros = new List<LivrosMOD>();

            try
            {
                InstanciarRepositorio();                
                repoDB.Cmd.CommandText = @"SELECT * FROM TITLES ORDER BY TITLE";
                if (repoDB.OpenConection())
                {
                    LivrosMOD livro;                    
                    dataReader = repoDB.Cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        livro = new LivrosMOD();
                        livro.Id = dataReader["title_id"].ToString();
                        livro.Titulo = dataReader["title"].ToString();
                        livro.Categoria = dataReader["type"].ToString();
                        livro.Preco = dataReader["price"] == System.DBNull.Value ? 0 : Convert.ToDecimal(dataReader["price"]); ;
                        livro.Resenha = dataReader["notes"].ToString();
                        listaLivros.Add(livro);
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                repoDB.CloseConnection();
                dataReader.Close();
            }
            return listaLivros;
        }

        public bool UpdateBook(LivrosMOD livro)
        {
            //varivel de retorno
            int retorno = 0;

            try
            {
                InstanciarRepositorio();
                repoDB.Cmd.CommandText = @"UPDATE TITLES SET TITLE = @titulo," +
                                                            " TYPE = @categoria," +
                                                            " NOTES = @resenha" +
                                                            " PRICE = @preco" +
                                                            " WHERE ID = @livroId";

                //Substitui o parametro
                repoDB.Cmd.Parameters.AddWithValue("@titulo", livro.Titulo);
                repoDB.Cmd.Parameters.AddWithValue("@categoria", livro.Categoria);
                repoDB.Cmd.Parameters.AddWithValue("@resenha", livro.Resenha);
                repoDB.Cmd.Parameters.AddWithValue("@preco", livro.Preco);
                repoDB.Cmd.Parameters.AddWithValue("@livroId", livro.Id);

                if (repoDB.OpenConection())
                {
                    retorno = repoDB.Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                repoDB.CloseConnection();
            }

            return (retorno > 0);
        }

        public bool DeleteBookById(string Id)
        {
            int retorno = 0;

            try
            {
                InstanciarRepositorio();

                //Montar o comando SQL
                repoDB.Cmd.CommandText = @"DELETE TITLES WHERE TITLE_ID = @livroId";

                //Substitui parametro
                repoDB.Cmd.Parameters.AddWithValue("@livroId", Id);

                if (repoDB.OpenConection())
                {
                    retorno = repoDB.Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                repoDB.CloseConnection();
            }

            return (retorno > 0);
        }

        public LivrosMOD GetBooksById(string id)
        {
            SqlDataReader dataReader = null;
            LivrosMOD livro = null;

            try
            {
                InstanciarRepositorio();
                repoDB.Cmd.CommandText = @"SELECT * FROM TITLES WHERE TITLE_ID = @codigo";
                repoDB.Cmd.Parameters.AddWithValue("@codigo", id);

                if (repoDB.OpenConection())
                {                 
                    dataReader = repoDB.Cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        livro = new LivrosMOD();
                        livro.Id = dataReader["title_id"].ToString();
                        livro.Titulo = dataReader["title"].ToString();
                        livro.Categoria = dataReader["type"].ToString();
                        //No c#, nulo = null
                        //No SqlServer, nulo = data type DbNull
                        //Fizemos um tratamento para que, se DbNull 0, se não, converte pra decimal
                        livro.Preco = dataReader["price"] == System.DBNull.Value ? 0 : Convert.ToDecimal(dataReader["price"]);
                        livro.Resenha = dataReader["notes"].ToString();                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {                
                dataReader.Close();
                repoDB.CloseConnection();
            }
            return livro;
        }
    }
}
