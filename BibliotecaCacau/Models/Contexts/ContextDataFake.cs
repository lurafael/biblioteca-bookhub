using BibliotecaBookHub.Models.Contracts;
using BibliotecaBookHub.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaBookHub.Models.Contexts
{
    public class ContextDataFake : IContextData
    {
        private static List<LivroDTO> livros;

        public ContextDataFake()
        {
            livros = new List<LivroDTO>();
            InitializeData();
        }

        private static void InitializeData()
        {
            livros.Add(new LivroDTO("Implementando Domain-Driven Design", "Vaugh Vernon", "Alta Books"));
            livros.Add(new LivroDTO("Domain-Driven Design", "Eric Evans", "Alta Books"));
            livros.Add(new LivroDTO("Redes Guia Prático", "Carlos E. Morimoto", "Sul Editores"));
            livros.Add(new LivroDTO("PHP Programando com Orientação a Objetos", "Pablo Dall'Oglio", "Novatec"));
            livros.Add(new LivroDTO("Introdução a Programação com Python", "Nilo N. C. Menezes", "Novatec"));
        }

        public void AtualizarLivro(LivroDTO livro)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(livro.Id);
                livros.Remove(objPesquisa);

                objPesquisa.Nome = livro.Nome;
                objPesquisa.Editora = livro.Editora;
                objPesquisa.Autor = livro.Autor;

                CadastrarLivro(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CadastrarLivro(LivroDTO livro)
        {
            try
            {
                livros.Add(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarLivro(string id)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(id);
                livros.Remove(objPesquisa); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDTO> ListarLivro()
        {
            try
            {
                return livros
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public LivroDTO PesquisarLivroPorId(string id)
        {
            try
            {
                return livros.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
