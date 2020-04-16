using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity_Lab01.DAL;

namespace Entity_Lab01.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var db = new CategoriaDb();
            var lista = db.ListarCategorias();
            return View(lista);
        }

        public ActionResult ProdutosPorCategoria(int id)
        {
            var db = new CategoriaDb();
            var lista = db.ListarProdutosPorCategoria(id);
            var categoria = db.SelecionaCategoriaPorId(id);
            ViewBag.CategoriaNome = categoria.Nome;
            return View(lista);
        }
    }
}