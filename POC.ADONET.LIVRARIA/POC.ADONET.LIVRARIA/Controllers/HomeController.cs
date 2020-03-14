using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POC.ADONET.MODELS;
using POC.ADONET.BLL;

namespace POC.ADONET.LIVRARIA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TodosLivros()
        {
            LivrosBLL livrosBLL = new LivrosBLL();
            var lista = livrosBLL.BuscarTodosLivros();
            //Vamos retornar uma lista tipada de livros que obtivemos através da camada business layer
            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}