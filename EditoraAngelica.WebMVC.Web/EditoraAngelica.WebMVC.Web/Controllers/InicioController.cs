using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditoraAngelica.WebMVC.Web.Utils;

namespace EditoraAngelica.WebMVC.Web.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contato()
        {
            //Retorna o HTML da View correspondente com a actionResult contato
            return View();
        }

        [HttpPost]
        public ActionResult Contato(FormCollection formulario)
        {
            try
            {
                var remetente = "angelicarocha12345@gmail.com";
                var nomeDestinatario = formulario["Nome"];
                var destinatario = formulario["Email"];
                var assunto = formulario["Assunto"];
                var menssagem = formulario["Mensagem"];

                EnviarEmail enviarEmail = new EnviarEmail(remetente, nomeDestinatario, destinatario, menssagem, assunto);

                //TODO: comentado abaixo para testar depois
                //enviarEmail.Send();    

                ViewBag.MensagemEnviada = "Mensagem Enviada com sucesso"; //dinamico, não precisa declarar nada
                ViewData["MensagemEnviada"] = "Mensagem Enviada via View Data";
                TempData["MensagemEnviada"] = "Mensagem Enviada via Tem Data";
            }
            catch (Exception)
            {
                throw;
            }

            return View();
        }
    }
}