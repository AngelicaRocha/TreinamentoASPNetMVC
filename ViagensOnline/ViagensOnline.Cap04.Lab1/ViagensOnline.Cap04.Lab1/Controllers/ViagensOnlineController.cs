using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.Cap04.Lab1.Db;

namespace ViagensOnline.Cap04.Lab1.Controllers
{
    public class ViagensOnlineController : Controller
    {
        // GET: ViagensOnline
        public ActionResult Inicio()
        {
            return View();
        }

        //Lista os destinos oferecidos no site
        public ActionResult Destinos()
        {
            using (var db = new ViagensOnlineDb())
            {
                return View(db.Destinos.ToArray());
            }
        }
    }
}