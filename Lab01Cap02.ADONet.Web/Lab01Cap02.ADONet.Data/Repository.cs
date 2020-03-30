using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab01Cap02.ADONet.Models;
using System.Data.SqlClient;

namespace Lab01Cap02.ADONet.Data
{
    public static class Repository
    {
        private static string conexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Organizador;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Classes estáticas não precisam ser instanciadas
        public static string Conexao
        {
            get { return conexao; }
        }

        public static List<Tarefas> SelecionarTarefas()
        {
            var lista = new List<Tarefas>();
            string query = @"SELECT Id, Nome, Prioridade, Concluido, Descricao, Observacao, Data_Insercao
                            FROM Tarefa
                            ORDER BY Concluido, Prioridade";
            using (var cn = new SqlConnection(Conexao))
            {
                using (var cmd = new SqlCommand(query, cn))
                {
                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tarefa = new Tarefas();
                            tarefa.Id = Convert.ToInt32(dr["Id"]);
                            tarefa.Nome = Convert.ToString(dr["Nome"].ToString());
                            tarefa.Prioridade = Convert.ToInt32(dr["Prioridade"]);
                            tarefa.Concluido = Convert.ToBoolean(dr["Concluido"]);
                            tarefa.Descricao = Convert.ToString(dr["Descricao"]);
                            tarefa.Observacao = Convert.ToString(dr["Observacao"]);
                            tarefa.DataInsercao = Convert.ToDateTime(dr["Data_insercao"]);
                            lista.Add(tarefa);
                        }
                    }
                }
            }
            return lista;
        }

        public static bool AtualizarTarefa(Tarefas tarefa)
        {
            string query = @"UPDATE Tarefa SET Nome = @Nome, Prioridade = @Prioridade, 
                            Concluido = @Concluido, Descricao = @Descricao,
					        Observacao = @Observacao, Data_insercao = getdate()
					        WHERE Id = @IdTarefa";
            using (var cn = new SqlConnection(Conexao))
            {
                var cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Nome", tarefa.Nome);
                cmd.Parameters.AddWithValue("@Prioridade", tarefa.Prioridade);
                cmd.Parameters.AddWithValue("@Concluido", tarefa.Concluido);
                cmd.Parameters.AddWithValue("@Descricao", tarefa.Descricao);
                cmd.Parameters.AddWithValue("@Observacao", tarefa.Observacao);
                cmd.Parameters.AddWithValue("@IdTarefa", tarefa.Id);
                cn.Open();
                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public static int Incluir(Tarefas tarefa)
        {
            string query = @"INSERT INTO Tarefa
                            (Nome,Prioridade, Concluido, Descricao, Observacao, Data_insercao)
                            VALUES (@Nome, @Prioridade, @Concluido, @Descricao, @Observacao, getdate());
                            SELECT @@IDENTITY";
            //Receberá o novo id gerdao pelo banco de dados
            int novoId = 0;

            /*é uma boa pratica usar o "using" pois após a utilizacao do BD e a execucao
             encerrar o escopo do "using", é garantido que a conexão será encerrada. Outra
             forma de fazer seria utilizar o bloco finally dentro de um try-cath*/
            using (var cn = new SqlConnection(Conexao))
            {
                var cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Nome", tarefa.Nome);
                cmd.Parameters.AddWithValue("@Prioridade",tarefa.Prioridade);
                cmd.Parameters.AddWithValue("@Concluido",tarefa.Concluido);
                cmd.Parameters.AddWithValue("@Descricao", tarefa.Descricao);
                cmd.Parameters.AddWithValue("@Observacao",tarefa.Observacao);

                cn.Open();

                novoId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return novoId;
        }

        public static Tarefas SelectTarefaPorId(int id)
        {
            Tarefas tarefa = new Tarefas();
            string query = @"SELECT * FROM TAREFA WHERE Id = @IdTarefa";

            using (var cn = new SqlConnection(Conexao))
            {
                using (var cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdTarefa", tarefa.Id);
                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tarefa.Id = Convert.ToInt32(dr["Id"]);
                            tarefa.Nome = Convert.ToString(dr["Nome"].ToString());
                            tarefa.Prioridade = Convert.ToInt32(dr["Prioridade"]);
                            tarefa.Concluido = Convert.ToBoolean(dr["Concluido"]);
                            tarefa.Descricao = Convert.ToString(dr["Descricao"]);
                            tarefa.Observacao = Convert.ToString(dr["Observacao"]);
                            tarefa.DataInsercao = Convert.ToDateTime(dr["Data_insercao"]);
                        }
                    }
                }
            }

            return tarefa;
        }
    }
}
