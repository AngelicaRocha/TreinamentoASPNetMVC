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
        [Required(ErrorMessage = "O ID ou código é obrigatório")]
        [Display(Name = "Código:")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Por favor preencher o título do livro")]
        [StringLength(100, ErrorMessage = "O nome do livro permite até {1} caracteres")]
        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Display(Name = "Assunto:")]
        public string Categoria { get; set; }

        [Display(Name = "Preço R$:")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Por favor preencha a resenha")]
        [StringLength(50, ErrorMessage = "A resenha permite até {1} caracteres")]
        [Display(Name = "Resenha:")]
        public string Resenha { get; set; }
    }
}
