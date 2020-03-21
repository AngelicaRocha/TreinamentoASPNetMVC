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

        [HttpGet]
        public ActionResult Editar (string id)
        {
            //declaro a variavel do tipo livro e so devo instanciar quando for utilizar
            LivrosBLL livroBLL = null;
            LivrosMOD livroMOD = null;

            //Verificar se o status da chamada POST é válido
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(id))
                {
                    ModelState.AddModelError("","O Id do livro é inválido");
                }

                livroBLL = new LivrosBLL();

                //obtemos o valor de retorno para objeto igual, a view espera livro MOD
                livroMOD = livroBLL.BuscarLivroPorId(id);
            }
            return View(livroMOD);
        }

        [HttpPost]
        public ActionResult Editar(LivrosMOD livro)
        {
            //Cria um objeto do tipo LivroBLL para fazer a validação de regra de negócio
            LivrosBLL livrosBLL = null;

            if (ModelState.IsValid)
            {
                //Só instancio se estiver tudo ok
                livrosBLL = new LivrosBLL();
                livrosBLL.SalvarLivro(livro);
            }
            return RedirectToAction("TodosLivros");
        }

        public ActionResult Excluir(string Id)
        {
            //Cria um objeto do tipo LivroBLL para fazer a validação de regra de negócio
            LivrosBLL livrosBLL = null;

            if (ModelState.IsValid)
            {
                //Só instancio se estiver tudo ok
                livrosBLL = new LivrosBLL();
                livrosBLL.ExcluirLivro(Id);
            }
            return RedirectToAction("TodosLivros");
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