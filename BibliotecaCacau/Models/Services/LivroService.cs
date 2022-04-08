using BibliotecaBookHub.Models.Contracts.Repositories;
using BibliotecaBookHub.Models.DTO;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Deletar(LivroDTO livro)
        {
            try
            {
                _livroRepository.Deletar(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(LivroDTO livro)
        {
            try
            {
                _livroRepository.Atualizar(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(LivroDTO livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDTO> Listar()
        {
            try
            {
                return _livroRepository.Listar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public LivroDTO PesquisarPorId(string id)
        {
            try
            {
                return _livroRepository.PesquisarPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
