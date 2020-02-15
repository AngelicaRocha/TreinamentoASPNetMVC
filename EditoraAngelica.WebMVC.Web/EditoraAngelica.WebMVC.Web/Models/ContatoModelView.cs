using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EditoraAngelica.WebMVC.Web.Models
{
    public class ContatoModelView
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public string Assunto { get; set; }
    }
}