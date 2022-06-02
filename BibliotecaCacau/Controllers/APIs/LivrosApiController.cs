using BibliotecaBookHub.Models.Contracts.Services;
using BibliotecaCacau.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibliotecaCacau.Controllers.APIs
{
    [Route("api/Livro")]
    [ApiController]
    public class LivrosApiController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosApiController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        [Route("ObterLivros")]
        public object ObterLivros()
        {
            try
            {
               return JsonSerializer.Serialize(_livroService.Listar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
