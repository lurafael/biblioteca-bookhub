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
    [Route("api/Emprestimo")]
    [ApiController]
    public class EmprestimosApiController : ControllerBase
    {
        private readonly IEmprestimoLivroService _emprestimoLivroService;

        public EmprestimosApiController(IEmprestimoLivroService emprestimoLivroService)
        {
            _emprestimoLivroService = emprestimoLivroService;
        }

        [Route("ConsultarEmprestimo")]
        public object ConsultarEmprestimo()
        {
            try
            {
                _emprestimoLivroService.AtualizarStatusEmprestimoLivros();
                var emprestimos = _emprestimoLivroService.ConsultarEmprestimos();
                return JsonSerializer.Serialize(emprestimos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
