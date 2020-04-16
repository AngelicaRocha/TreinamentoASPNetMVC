using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entity_Lab01.Models;

namespace Entity_Lab01.DAL
{
    public class NorthwindContext : DbContext
    {
        private const string Conexao = @"Data Source = (LocalDb)\MSSQLLocalDb;Initial Catalog = Northwind;Integrated Security = True";

        public NorthwindContext() : base(Conexao) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}