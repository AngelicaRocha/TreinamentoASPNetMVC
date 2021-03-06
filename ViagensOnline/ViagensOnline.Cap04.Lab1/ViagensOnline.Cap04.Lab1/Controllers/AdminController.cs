﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ViagensOnline.Cap04.Lab1.Db;
using ViagensOnline.Cap04.Lab1.Models;
using System.Security.Claims;

namespace ViagensOnline.Cap04.Lab1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private const string ActionDestinoListagem = "DestinoListagem";

        // GET: Admin
        //Carregando a tela
        [HttpGet]
        public ActionResult DestinoNovo()
        {
            return View();
        }

        // POST: Admin
        //Enviando os dados para gravar o novo destino
        [HttpPost]
        public ActionResult DestinoNovo(Destino destino)
        {
            //Verificar se alguma validação falhou
            //ModelState faz a validação das informações e garante que o que saiu da origem chegou ao destino
            if (!ModelState.IsValid)
            {
                return View(destino);
            }
            //Obrigatoriedade da foto
            if (Request.Files.Count == 0 || Request.Files[0].ContentLength == 0)
            {
                ModelState.AddModelError("", "É necessário enviar uma foto");
                return View(destino);
            }
            //Faz a gravação
            try
            {
                destino.Foto = GravarFoto(Request);
                using (var db = ObterDbContext())
                {
                    db.Destinos.Add(destino);
                    db.SaveChanges();
                    return RedirectToAction(ActionDestinoListagem);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View(destino);
            }
        }

        //Grava Foto
        private string GravarFoto(HttpRequestBase Request)
        {
            string nome = Path.GetFileName(Request.Files[0].FileName);
            string pastaVirtual = "~/Imagens";
            string pathVirtual = pastaVirtual + "/" + nome;
            string pathFisico = Request.MapPath(pathVirtual);
            Request.Files[0].SaveAs(pathFisico);
            return nome;
        }

        //Retorna uma instância de DbContext
        private ViagensOnlineDb ObterDbContext()
        {
            return new ViagensOnlineDb();
        }

        //Lista dos destinos
        public ActionResult DestinoListagem()
        {
            List<Destino> lista = null;
            using (var db = ObterDbContext())
            {
                lista = db.Destinos.ToList();
            }
            return View(lista);
        }

        //Alterar um destino
        [HttpGet]
        public ActionResult DestinoAlterar(int id)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);
                if (destino != null)
                {
                    return View(destino);
                }
                return RedirectToAction(ActionDestinoListagem);
            }
        }

        //Alterar um destino com POST, agora de verdade
        [HttpPost]
        public ActionResult DestinoAlterar(Destino destino)
        {
            //Verificar se o modelo é válido
            if (ModelState.IsValid)
            {
                using (var db =  ObterDbContext())
                {
                    //Obtem o original
                    var destinoOriginal = db.Destinos.Find(destino.DestinoId);
                    //Se encontrou o original, altera-o
                    if (destinoOriginal != null)
                    {
                        destinoOriginal.Nome = destino.Nome;
                        destinoOriginal.Pais = destino.Pais;
                        destinoOriginal.Cidade = destino.Cidade;

                        //Altera a imagem apenas se outra imagem foi enviada
                        if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                        {
                            destinoOriginal.Foto = GravarFoto(Request);
                        }

                        //Gravar as mudanças
                        db.SaveChanges();
                        return RedirectToAction(ActionDestinoListagem);
                    }
                }
            }

            return View(destino);
        }

        //Confirmar antes de excluir um destino
        [HttpGet]
        public ActionResult DestinoExcluir (int id)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);
                if (destino != null)
                {
                    return View(destino);
                }
            }
            return RedirectToAction(ActionDestinoListagem);
        }

        //Excluir um destino agora de verdade
        [HttpPost]
        public ActionResult DestinoExcluir(int id, FormCollection form)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);
                if (destino != null)
                {
                    db.Destinos.Remove(destino);
                    db.SaveChanges();
                }
            }
            return RedirectToAction(ActionDestinoListagem);
        }

        //Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string Usuario, string Senha)
        {
            if (string.IsNullOrEmpty(Usuario))
            {
                ViewBag.Mensagem = "Digite o usuário";
                return View();
            }

            if (string.IsNullOrEmpty(Senha))
            {
                ViewBag.Mensagem = "Digite a senha";
                return View();
            }

            if (Usuario != "admin" || Senha != "admin")
            {
                ViewBag.Mensagem = "Usuário ou senha inválido";
                return View();
            }

            //Um Array de claims. Claim é uma declaração que
            // o usuário faz. Nesse caso, são duas: Ele se chama
            // Administrador e pertence ao grupo admin
            Claim[] claims = new Claim[3];
            claims[0] = new Claim(ClaimTypes.Name, "Administrador");
            claims[1] = new Claim(ClaimTypes.Role, "admin");
            claims[2] = new Claim(ClaimTypes.NameIdentifier, "admin");

            //Nome para identificar
            string nomeAutenticacao = "AppViagensOnlineCookie";

            //Identidade
            ClaimsIdentity identity = new ClaimsIdentity(claims, nomeAutenticacao);

            //Autentica
            Request.GetOwinContext().Authentication.SignIn(identity);

            //Redireciona para a pasta destinos
            return RedirectToAction(ActionDestinoListagem);
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            //Encerra a sessão e o cookie de autenticação
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}