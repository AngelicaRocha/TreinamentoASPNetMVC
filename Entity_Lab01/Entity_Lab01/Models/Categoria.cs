using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity_Lab01.Models
{
    [Table("Categories")]
    public class Categoria
    {        
        [Column("CategoryID")]
        [Key]
        public int IdCategoria { get; set; }

        [Column("CategoryName")]
        public string Nome { get; set; }
    }
}