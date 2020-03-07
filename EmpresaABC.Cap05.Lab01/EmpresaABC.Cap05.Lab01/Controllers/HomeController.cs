using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpresaABC.Cap05.Lab01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuemSomos()
        {
            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Concluido = false;
            return View();
        }

        [HttpPost]
        public ActionResult Contato(Models.ContatoViewModel contato)
        {
            try
            {
                Classes.RotinasWeb.ContatoGravar(contato);
                ViewBag.Concluido = true;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}