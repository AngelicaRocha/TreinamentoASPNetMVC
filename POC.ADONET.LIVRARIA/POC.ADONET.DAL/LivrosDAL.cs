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
                repoDB.Conn.ConnectionString = "Data Source=3P47_01;Initial Catalog=pubs;User ID=sa;Password=Imp@ct@";

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
                    LivrosMOD livro = new LivrosMOD();
                    dataReader = repoDB.Cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        livro.Id = dataReader["title_id"].ToString();
                        livro.Titulo = dataReader["title"].ToString();
                        livro.Categoria = dataReader["type"].ToString();
                        //livro.Preco = Convert.ToDecimal(dataReader["price"]);
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
    }
}
