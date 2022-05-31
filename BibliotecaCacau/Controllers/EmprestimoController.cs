using BibliotecaBookHub.Models.Contracts.Services;
using BibliotecaBookHub.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public EmprestimoController(IUsuarioService usuarioService)
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
                    TempData["userId"] = resultado.Id;
                    TempData["userLogin"] = resultado.Login;
                    TempData["loginError"] = false;

                    return Redirect("/Home");
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
            TempData["userId"] = null;
            TempData["userLogin"] = null;
            TempData["loginError"] = false;

            return RedirectToAction("/Home");
        }
    }
}
