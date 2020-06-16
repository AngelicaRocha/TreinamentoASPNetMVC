using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab01Cap02.ADONet.Models;
using Lab01Cap02.ADONet.Business;

namespace Lab01Cap02.ADONet.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NovaTarefa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovaTarefa(Tarefas tarefa)
        {
            TarefasBLL tarefaBLL = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefaBLL = new TarefasBLL();
                    var resultado = tarefaBLL.AdicionaTarefa(tarefa);
                    if (!resultado)
                    {
                        ModelState.AddModelError("", "ops! ocorreu um erro ao adicionar a tarefa :( tente novamente");
                        return View();
                    }
                    else
                    {
                        TempData["Sucesso"] = "sua tarefa foi adicionada! :)";
                        return RedirectToAction("NovaTarefa");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "há erros no formulário!");
                    // TODO: Colocar validações individuais para cada campo
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("nome"))
                {
                    ModelState.AddModelError("Nome", ex.Message);
                }
                else if (ex.Message.ToLower().Contains("trata"))
                {
                    ModelState.AddModelError("Descricao", ex.Message);
                }
                // TODO: Validar também a prioridade
                else
                {
                    // TODO: Impedir que chame o validatio summary
                    ModelState.AddModelError("", "aconteceu uma falha ao tentar adicionar essa tarefa :( tente novamente");
                }
            }
            return View();
        }

        public ActionResult ListaTarefas()
        {
            TarefasBLL tarefaBLL = null;
            List<Tarefas> tarefas = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefaBLL = new TarefasBLL();
                    tarefas = tarefaBLL.SelecionarTodasTarefas();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(tarefas);
        }

        public ActionResult EditarTarefa(int id)
        {
            TarefasBLL tarefaBLL = null;
            Tarefas tarefa = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefaBLL = new TarefasBLL();
                    tarefa = tarefaBLL.SelecionarTarefaPorId(id);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu uma falha na pesquisa da tarefa informada :(");
            }
            return View(tarefa);
        }

        [HttpPost]
        public ActionResult EditarTarefa(Tarefas tarefa)
        {
            TarefasBLL tarefaBLL = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefaBLL = new TarefasBLL();
                    tarefaBLL.AtualizarTarefa(tarefa);
                    TempData["Sucesso"] = "sua tarefa foi alterada! :)";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu uma falha na atualização da tarefa :(");
            }
            return View(tarefa);
        }

        public ActionResult ExcluirTarefa(int id)
        {
            TarefasBLL tarefaBLL = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefaBLL = new TarefasBLL();
                    if (tarefaBLL.ExcluirTarefa(id))
                    {
                        TempData["SucessoExclusao"] = "sua tarefa foi excluida! :)";
                        return RedirectToAction("ListaTarefas");                        
                    }
                    else
                    {
                        TempData["ErroExclusao"] = "algo deu errado ao exluir a tarefa";         
                    }
                }                
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "aconteceu uma falha ao tentar excluir essa tarefa :( tente novamente");                
            }            
            return RedirectToAction("ListaTarefas"); 
        }

        public ActionResult DetalheTarefa(int id)
        {
            TarefasBLL tarefasBLL = null;
            Tarefas tarefasMOD = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefasBLL = new TarefasBLL();
                    tarefasMOD = tarefasBLL.SelecionarTarefaPorId(id);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Ocorreu uma falha na pesquisa da tarefa selecionada: " + ex.Message);
            }
            return View(tarefasMOD);
        }

        public ActionResult ConcluirTarefa(int id)
        {
            TarefasBLL tarefaBLL = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefaBLL = new TarefasBLL();
                    if (tarefaBLL.MarcarConcluida(id))
                    {
                        return RedirectToAction("ListaTarefas");
                    }                    
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "aconteceu uma falha ao tentar concluir essa tarefa :( tente novamente");
            }
            return RedirectToAction("ListaTarefas");
        }
    }
}