using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;

namespace POC.ADONET.DAL
{
    public class ClienteDAL
    {
        //Verifica se já existe uma instância válida de SqlConnection e de SqlCommand
        Repository repoDB;

        //Instancia Banco de Dados
        private void InstanciarRepositorio()
        {
            if (repoDB == null)
            {
                //Se não tiver, crio uma
                repoDB = new Repository();

                //Adiciona a string de conexão
                repoDB.Conn.ConnectionString = "Data Source=3P47_01;Initial Catalog=Livraria;User ID=sa;Password=Imp@ct@";

                //Atribuindo o objeto SlConnections ja instanciado para a propriedade conection
                repoDB.Cmd.Connection = repoDB.Conn;
            }
        }

        //INSERT
        public bool Add(string nome, string email, string observacao = "")
        {
            int retorno = 0;

            try
            {
                InstanciarRepositorio();

                //Montar o comando SQL
                repoDB.Cmd.CommandText = @"insert into Cliente values(@Nome, @Email, @Observacao)";

                //Substituir os placeholders pelos valores reais
                repoDB.Cmd.Parameters.AddWithValue("@Nome", nome);
                repoDB.Cmd.Parameters.AddWithValue("@Email", email);
                repoDB.Cmd.Parameters.AddWithValue("@Observacao", observacao);                

                //Abre a conexão com o banco de dados
                if (repoDB.OpenConection())
                {
                    //Executando o comando insert na base
                    //ExecuteNonQuery retorna o número de linhas afetadas
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

        //DELETE
        public bool DeleteByID(int id)
        {
            int retorno = 0;

            try
            {
                InstanciarRepositorio();

                //Montar o comando SQL
                repoDB.Cmd.CommandText = @"DELETE CLIENTE WHERE ID = @clienteId";

                //Substitui parametro
                repoDB.Cmd.Parameters.AddWithValue("@clienteId", id);

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


        //UPDATE
        public bool Update(ClienteMOD cliente, int id = 0)
        {

            //varivel de retorno
            int retorno = 0;

            try
            {
                InstanciarRepositorio();
                repoDB.Cmd.CommandText = @"UPDATE CLIENTE SET NOME = @nome," +
                                                            " EMAIL = @email," +
                                                            " OBSERVACAO = @observacao" +
                                                            " WHERE ID = @clienteId";

                //Substitui o parametro
                repoDB.Cmd.Parameters.AddWithValue("@clienteId", cliente.Id);
                repoDB.Cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                repoDB.Cmd.Parameters.AddWithValue("@email", cliente.Email);
                repoDB.Cmd.Parameters.AddWithValue("@observacao", cliente.Observacao);

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


        //SELECT ALL (*)
        public List<ClienteMOD> SelectAll()
        {
            //Variável para capturar o resultado do select
            var lista = new List<ClienteMOD>();

            //Objeto do tipo cliente mod
            var cliente = new ClienteMOD();

            try
            {
                //Cria instancia de repoDB
                InstanciarRepositorio();
                repoDB.Cmd.CommandText = @"SELECT * FROM CLIENTE";

                //Abrindo a conexão
                if (repoDB.OpenConection())
                {
                    SqlDataReader resultadoSelect = repoDB.Cmd.ExecuteReader();

                    //Método read vai ler todo mundo
                    while (resultadoSelect.Read())
                    {
                        //tudo que é retornado do execure reader é objeto. Por isso precisamos converter para os respectivos tipos
                        cliente.Id = (int)resultadoSelect["Id"];
                        cliente.Nome = resultadoSelect["Nome"].ToString();
                        cliente.Email = resultadoSelect["Email"].ToString();
                        cliente.Observacao = resultadoSelect["Observacao"].ToString();

                        //Adiciona na lista
                        lista.Add(cliente);
                    }

                    //Fecha e deixa disponível para leitura ou exclusão pelo garbage collector
                    resultadoSelect.Close();
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

            return lista;
        }


        //SELECT COM WHERE
        public ClienteMOD SelectByID(int id)
        {
            //Objeto do tipo cliente mod
            var cliente = new ClienteMOD();

            try
            {
                //Cria instancia de repoDB
                InstanciarRepositorio();
                repoDB.Cmd.CommandText = @"SELECT * FROM CLIENTE WHERE Id = @id";

                //Substitui o parametro
                repoDB.Cmd.Parameters.AddWithValue("@id", id);

                //Abrindo a conexão
                if (repoDB.OpenConection())
                {
                    SqlDataReader resultadoSelect = repoDB.Cmd.ExecuteReader();

                    //Método read vai ler todo mundo
                    while (resultadoSelect.Read())
                    {
                        //tudo que é retornado do execure reader é objeto. Por isso precisamos converter para os respectivos tipos
                        cliente.Id = (int)resultadoSelect["Id"];
                        cliente.Nome = resultadoSelect["Nome"].ToString();
                        cliente.Email = resultadoSelect["Email"].ToString();
                        cliente.Observacao = resultadoSelect["Observacao"].ToString();
                    }

                    //Fecha e deixa disponível para leitura ou exclusão pelo garbage collector
                    resultadoSelect.Close();
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

            return cliente;
        }
    }
}
