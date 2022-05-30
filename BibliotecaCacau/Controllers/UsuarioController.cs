using BibliotecaBookHub.Models.Contracts.Services;
using BibliotecaBookHub.Models.DTO;
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
                    return RedirectToAction("/Home");
                }
                
                return RedirectToAction("/Home");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
