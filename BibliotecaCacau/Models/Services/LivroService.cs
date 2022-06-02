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

        public void Deletar(string Id)
        {
            try
            {
                var livro = PesquisarPorId(Id);
                var objLivro = livro.ConverterParaEntidade();
                _livroRepository.Deletar(objLivro.Id);
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
                var objLivro = livro.ConverterParaEntidade();
                _livroRepository.Atualizar(objLivro);
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
                var objLivro = livro.ConverterParaEntidade();
                objLivro.Cadastrar();
                _livroRepository.Cadastrar(objLivro);
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
                var livrosDTO = new List<LivroDTO>();
                var livros = _livroRepository.Listar();

                foreach(var item in livros)
                {
                    livrosDTO.Add(item.ConverterParaDTO());
                }

                return livrosDTO;
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
                var livro = _livroRepository.PesquisarPorId(id);
                return livro.ConverterParaDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
