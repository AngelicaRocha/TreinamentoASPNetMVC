using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GestaoPessoas.Web.Models
{
    public class Empregado
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdDepartamento { get; set; }

        public virtual Departamento Departamento { get; set; }
    }
}