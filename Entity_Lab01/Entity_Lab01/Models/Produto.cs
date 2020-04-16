using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity_Lab01.Models
{
    [Table("Products")]
    public class Produto
    {        
        [Column("ProductID")]
        [Key]
        public int IdProduto { get; set; }

        [Column("ProductName")]
        public string Nome { get; set; }

        [Column("UnitPrice")]
        public decimal Preco { get; set; }

        [Column("UnitsInStock")]
        public short Estoque { get; set; }

        [ForeignKey("Categoria")]
        [Column("CategoryID")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}