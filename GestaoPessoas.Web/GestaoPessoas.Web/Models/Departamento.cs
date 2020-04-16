using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GestaoPessoas.Web.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        /* propriedade de navegação: serve para viabilizar o acesso por entidades relacionadas. E adicionada como virtual */
        public virtual ICollection<Empregado> Empregados { get; set; }
    }
}