using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01Cap02.ADONet.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
// TODO: Colocar os requireds e tamanhos
        public string Nome { get; set; }
        public int Prioridade { get; set; }
        public bool Concluido { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInsercao { get; set; }
    }
}