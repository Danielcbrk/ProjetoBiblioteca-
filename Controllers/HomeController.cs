﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AutenticacaoController.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



/*        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {

            UsuarioRepository ur = new UsuarioRepository();
            Usuario user = ur.ValidarLogin(usuario);

            if (user == null)
            {
                ViewBag.Message = "Falha no login!";
                return View();

            }
            else
            {
                ViewBag.Message = "Você está logado!";


                HttpContext.Session.SetInt32("IdUsuario", user.Id);
                HttpContext.Session.SetString("NomeUsuario", user.Nome);
                HttpContext.Session.SetString("NomeUsuario", user.Senha);


                return View();
            }

        }

   */    


        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            /*
            if(login != "admin" || senha != "123")
            {
                ViewData["Erro"] = "Senha inválida";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("user", "admin");
                return RedirectToAction("Index");
            }

            */

            if (AutenticacaoController.verificaLoginSenha(login,senha, this))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Erro"] = "Senha Inválida";
                return View();
            }
            

        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
