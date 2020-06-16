using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax_Lab01.Models;

namespace Ajax_Lab01.Db
{
    public class ChatDb
    {
        private const string chaveChat = "chat";
        private const string chaveParticipantes = "participantes";
        private const string adminNome = "admin";
        private const string adminMensagemInicial = "Chat iniciado com sucesso";

        internal static void Iniciar()
        {
            var lista = new List<ChatMensagem>();
            HttpContext
                .Current
                .Application
                .Add(chaveChat, lista);

            var participantes = new List<string>();
            HttpContext
                .Current
                .Application
                .Add(chaveParticipantes, participantes);

            participantes.Add(adminNome);
        }

        public static List<ChatMensagem> Mensagens
        {
            get
            {
                return
                (List<ChatMensagem>)HttpContext
                .Current
                .Application[chaveChat];
            }
        }

        public static List<string> Participantes
        {
            get
            {
                return (List<string>)HttpContext
                .Current
                .Application[chaveParticipantes];
            }
        }

        private static void ValidarMensagem(string participante, string mensagem)
        {
            if (string.IsNullOrEmpty(participante) ||
            participante.Trim().Length == 0)
            {
                throw new Exception(
                "Participante não informado");
            }
            if (string.IsNullOrEmpty(mensagem) ||
            mensagem.Trim().Length == 0)
            {
                throw new Exception("Mensagem não informada");
            }
        }

        public static void EnviarMensagem(string participante, string mensagem)
        {
            ValidarMensagem(participante, mensagem);
            var msg = new ChatMensagem();
            msg.DataHora = DateTime.Now;
            msg.Participante = participante;
            msg.Mensagem = mensagem;
            Mensagens.Add(msg);
        }

        private static void ValidarEntrar(string participante)
        {
            if (string.IsNullOrEmpty(participante))
            {
                throw new Exception("Informe o nome do participante");
            }
            foreach (string nome in Participantes)
            {
                if (participante == nome)
                {
                    throw new Exception("Este nome já está sendo usado.");
                }
            }
        }

        public static void Entrar(string participante)
        {
            ValidarEntrar(participante);
            Participantes.Add(participante);
            string msg = string.Format("{0} entrou no chat.", participante);
            EnviarMensagem(adminNome, msg);
        }

        public static List<ChatMensagem> UltimasMensagens()
        {
            var lista = (from m in Mensagens orderby m.DataHora descending select m).Take(100);
            return lista.ToList();
        }
    }
}