using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab01Cap02.ADONet.Models;
using Lab01Cap02.ADONet.Data;

namespace Lab01Cap02.ADONet.Business
{
    public class TarefasBLL
    {
        public bool AdicionaTarefa(Tarefas tarefa)
        {
            if (ValidarTarefa(tarefa))
            {
                return (Repository.Incluir(tarefa) != 0);
            }
            return false;
        }

        public List<Tarefas> SelecionarTodasTarefas()
        {
            return Repository.SelecionarTarefas();
        }

        public Tarefas SelecionarTarefaPorId(int id)
        {
            return Repository.SelectTarefaPorId(id);
        }

        public bool AtualizarTarefa(Tarefas tarefa)
        {            
            if (ValidarTarefa(tarefa))
            {
                return Repository.AtualizarTarefa(tarefa);
            }
            return false;
        }

        public bool ExcluirTarefa(int id)
        {
            return Repository.ExcluirTarefa(id);
        }

        public bool MarcarConcluida(int id)
        {
            return Repository.ConcluirTarefa(id);
        }

        public bool ValidarTarefa(Tarefas tarefa)
        {
            //Nome é obrigatório
            if (string.IsNullOrEmpty(tarefa.Nome) ||
            tarefa.Nome.Trim().Length == 0)
            {
                throw new Exception("informe o nome da tarefa");
            }
            // Decrição é obrigatória
            if (string.IsNullOrEmpty(tarefa.Descricao) ||
            tarefa.Descricao.Trim().Length == 0)
            {
                throw new Exception("informe de que se trata a tarefa");
            }
            //Prioridade é um número entre 1 e 3
            if (tarefa.Prioridade < 1 ||
            tarefa.Prioridade > 3)
            {
                throw new Exception("a prioridade deve ser entre 1 e 3");
            }
            // Formata observações para ficar Null
            // Isso facilita algumas Conversões de Dados
            if (tarefa.Observacao == null)
            {
                tarefa.Observacao = string.Empty;
            }            
            return true;
        }
        
    }
}
