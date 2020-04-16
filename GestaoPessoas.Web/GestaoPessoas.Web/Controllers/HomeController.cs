using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestaoPessoas.Web.Context;
using GestaoPessoas.Web.Models;

namespace GestaoPessoas.Web.Controllers
{
    public class HomeController : Controller
    {
        DataAccessHelper dataAccessHelper = null;

        public ActionResult Index()
        {
            Departamento departamento = new Departamento
            {
                Nome = "Tecnologia",
                Empregados = new List<Empregado>
                {
                    new Empregado() {Nome = "Angelica"},
                    new Empregado() {Nome = "Chaves"},
                    new Empregado() {Nome = "Chiquinha"}
                }
            };

            dataAccessHelper = new DataAccessHelper();
            dataAccessHelper.AddDepartamento(departamento);

            var departamentoAdicionado = dataAccessHelper.BuscarDepastamentos().FirstOrDefault();

            return View();
        }  
        
        public ActionResult Empregados()
        {
            return View();
        }
    }
}