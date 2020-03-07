using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ADONET.DAL
{
    public class ClienteDAL
    {
        //Verifica se já existe uma instância válida de SqlConnection e de SqlCommand
        Repository repoDB;
        
        public bool Add(string nome, string email, string observacao = "")
        {
            if (repoDB == null)
            {
                //Se não tiver, crio uma
                repoDB = new Repository();
            }

            //Vamos atribuir uma string de conexão
            repoDB.Conn.ConnectionString = "Data Source=3P47_01;Initial Catalog=Livraria;User ID=sa;Password=Imp@ct@";

            //Montar o comando SQL
            repoDB.Cmd.CommandText = @"insert into Cliente values(@Nome, @Email, @Observacao)";

            //Substituir os placeholders pelos valores reais
            repoDB.Cmd.Parameters.AddWithValue("@Nome", nome);
            repoDB.Cmd.Parameters.AddWithValue("@Email", email);
            repoDB.Cmd.Parameters.AddWithValue("@Observacao", observacao);

            //Atribuindo o objeto SlConnections ja instanciado para a propriedade conection
            repoDB.Cmd.Connection = repoDB.Conn;

            int retorno = 0;

            //Abre a conexão com o banco de dados
            if (repoDB.OpenConection())
            {
                //Executando o comando insert na base
                //ExecuteNonQuery retorna o número de linhas afetadas
                retorno = repoDB.Cmd.ExecuteNonQuery();
                
            }

            return (retorno > 0);
        }
    }
}
