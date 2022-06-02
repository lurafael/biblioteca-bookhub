using BibliotecaBookHub.Models.Contracts.Services;
using BibliotecaBookHub.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            try
            {
                UsuarioDTO usuario = new UsuarioDTO { Login = login, Senha = senha };
                UsuarioDTO resultado =  _usuarioService.EfetuarLogin(usuario);

                if(resultado != null)
                {
                    HttpContext.Session.SetString("_UserId", resultado.Id.ToString());
                    HttpContext.Session.SetString("_Login", resultado.Login);

                    TempData["loginError"] = false;

                    return Redirect("/Emprestimo/Consulta");
                } else
                {
                    TempData["loginError"] = true;

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserId");
            HttpContext.Session.Remove("_Login");

            TempData["loginError"] = false;

            return Redirect("/Home");
        }
    }
}
