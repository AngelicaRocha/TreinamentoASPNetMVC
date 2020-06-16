using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_Lab01.Models
{
    public class ChatMensagem
    {
        public string Participante { get; set; }
        public DateTime DataHora { get; set; }
        public string Mensagem { get; set; }
    }
}