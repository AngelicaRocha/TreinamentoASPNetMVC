using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace EditoraAngelica.WebMVC.Web.Utils
{
    public class EnviarEmail
    {
        SmtpClient smtpClient;
        MailAddress from;
        MailAddress to;
        MailMessage Message;

        /// <summary>
        /// Construtor da classe que envia e-mails.
        /// </summary>
        /// <param name="emailFrom">E-mail do remetente</param>
        /// <param name="nameFrom">Nome do remetente</param>
        /// <param name="emailTo">E-mail do destinatario</param>
        /// <param name="emailMessage">Mensagem que será enviada</param>
        /// <param name="mailAssunto">Assunto do e-mail</param>

        public EnviarEmail(string emailFrom, string nameFrom, string emailTo, string emailMessage, string mailAssunto)
        {
            //vamos intanciar os objetos na execução do construtor
            smtpClient = new SmtpClient();
            from = new MailAddress(emailFrom,nameFrom, System.Text.Encoding.UTF8);
            to = new MailAddress(emailTo);
            //Instanciando o MailMessage
            Message = new MailMessage(from, to);
            //mensagem
            Message.Body = emailMessage;
            //assunto
            Message.Subject = mailAssunto;
        }

        public void Send()
        {
            //configurações de e-mail
            smtpClient.Host = "smtps.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587; //ou 465
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            //credenciais
            smtpClient.Credentials = new System.Net.NetworkCredential("angelicarocha12345@gmail.com", "senha");
            //envia o e-mail
            smtpClient.Send(Message);
        }
    }
}