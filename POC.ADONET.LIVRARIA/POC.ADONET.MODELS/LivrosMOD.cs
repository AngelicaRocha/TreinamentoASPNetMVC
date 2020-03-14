using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ADONET.MODELS
{
    public class LivrosMOD
    {
        [Display(Name = "Código")]
        public string Id { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }
        public string Categoria { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public string Resenha { get; set; }
    }
}
