using BibliotecaBookHub.Models.Contracts.Services;
using BibliotecaBookHub.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
                var livros = _livroService.Listar();
                return View(livros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome, Autor, Editora")] LivroDTO livro)
        {
            try
            {
                _livroService.Cadastrar(livro);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Edit(string? id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _livroService.PesquisarPorId(id);
            if(livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Nome, Autor, Editora")] LivroDTO livro)
        {
            if(string.IsNullOrEmpty(livro.Id))
            {
                NotFound();
            }

            try 
            {
                _livroService.Atualizar(livro);
                return RedirectToAction("List");
            } 
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public IActionResult Details(string? id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _livroService.PesquisarPorId(id);
            if(livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _livroService.PesquisarPorId(id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id, Nome, Autor, Editora")] LivroDTO livro)
        {
            try
            {
                _livroService.Deletar(livro.Id);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
