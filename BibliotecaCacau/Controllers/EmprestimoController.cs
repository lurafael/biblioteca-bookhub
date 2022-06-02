using BibliotecaBookHub.Models.Contracts.Services;
using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoLivroService _emprestimoService;
        private readonly IClienteService _clienteService;
        private readonly ILivroService _livroService;

        public EmprestimoController(IEmprestimoLivroService emprestimoService,
            IClienteService clienteService,
            ILivroService livroService)
        {
            _emprestimoService = emprestimoService;
            _clienteService = clienteService;
            _livroService = livroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }

        public IActionResult PesquisarEmprestimo(string nomeLivro, string nomeCliente, string dataEmprestimo)
        {
            DateTime dataEmprestimoFormatada = DateTime.Parse(dataEmprestimo);
            try
            {
                ConsultaEmprestimoDTO result = _emprestimoService.PesquisarEmprestimo(nomeLivro, nomeCliente, dataEmprestimoFormatada);
                return View(result);
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EfetuarEmprestimo([Bind("Cliente, Livro")] EmprestimoDTO emprestimo)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.Session.GetString("_UserId"));
                string login = HttpContext.Session.GetString("_Login");

                EmprestimoLivroDTO entidade = new EmprestimoLivroDTO();
                entidade.Cliente = PesquisarCliente(emprestimo.Cliente);
                entidade.ClienteId = entidade.Cliente.Id;

                entidade.Livro = PesquisarLivro(emprestimo.Livro);
                entidade.LivroId = entidade.Livro.Id;

                entidade.UsuarioId = userId;
                entidade.Usuario = new UsuarioDTO { Id = userId, Login = login };

                _emprestimoService.EfetuarEmprestimo(entidade);

                return RedirectToAction("Consulta");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult EfetuarDevolucao(int emprestimoId, string livroId)
        {
            try
            {
                _emprestimoService.EfetuarDevolucao(emprestimoId, livroId);
                return RedirectToAction("Consulta");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteDTO PesquisarCliente(string nome)
        {
            var cliente = _clienteService.Listar()
                .Where(p => p.Nome
                .Equals(nome))
                .FirstOrDefault();

            return cliente;
        }

        public LivroDTO PesquisarLivro(string nome)
        {
            var livro = _livroService.Listar()
                .Where(p => p.Nome
                .Equals(nome))
                .FirstOrDefault();

            return livro;
        }

        public LivroDTO PesquisarUsuario(string nome)
        {
            var livro = _livroService.Listar()
                .Where(p => p.Nome
                .Equals(nome))
                .FirstOrDefault();

            return livro;
        }

        public IActionResult PesquisarClientes(string term)
        {
            var clientes = _clienteService.Listar();
            var clientesAtivos = clientes.Where(p => p.StatusClienteId.Equals("1")).ToList();
            var listaNomeClientes = clientesAtivos.Select(p => p.Nome).ToList();
            var filtro = listaNomeClientes.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return Json(filtro);
        }

        public IActionResult PesquisarLivros(string term)
        {
            var livros = _livroService.Listar();
            var livrosDisponiveis = livros.Where(p => p.StatusLivroId == 1).ToList();
            var listaLivros = livrosDisponiveis.Select(p => p.Nome).ToList();
            var filtro = listaLivros.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return Json(filtro);
        }
    }
}
