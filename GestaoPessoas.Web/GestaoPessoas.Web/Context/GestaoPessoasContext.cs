using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GestaoPessoas.Web.Models;

namespace GestaoPessoas.Web.Context
{
    //para usar o entity, a classe precisar herdar de DbContext
    public class GestaoPessoasContext : DbContext
    {
        public DbSet<Empregado> Empregado { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
    }
}