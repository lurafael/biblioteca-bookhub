using BibliotecaBookHub.Models.Contracts;
using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaBookHub.Models.Contexts
{
    public class ContextDataFake : IContextData
    {
        private static List<Livro> livros;

        public ContextDataFake()
        {
            livros = new List<Livro>();
            InitializeData();
        }

        private static void InitializeData()
        {
            livros.Add(new Livro { Nome = "Implementando Domain-Driven Design", Autor = "Vaugh Vernon", Editora = "Alta Books" });
            livros.Add(new Livro { Nome = "Domain-Driven Design", Autor = "Eric Evans", Editora = "Alta Books" });
            livros.Add(new Livro { Nome = "Redes Guia Prático", Autor = "Carlos E. Morimoto", Editora = "Sul Editores" });
            livros.Add(new Livro { Nome = "PHP Programando com Orientação a Objetos", Autor = "Pablo Dall'Oglio", Editora = "Novatec" });
            livros.Add(new Livro { Nome = "Introdução a Programação com Python", Autor = "Nilo N. C. Menezes", Editora = "Novatec" });
        }

        public void AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void AtualizarLivro(Livro livro)
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

        public void AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(Livro livro)
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

        public void CadastrarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void DeletarCliente(string id)
        {
            throw new NotImplementedException();
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

        public void DeletarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarClientes()
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarLivro()
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

        public List<Usuario> ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        public Cliente PesquisarClientePorId(string id)
        {
            throw new NotImplementedException();
        }

        public Livro PesquisarLivroPorId(string id)
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

        public Usuario PesquisarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
