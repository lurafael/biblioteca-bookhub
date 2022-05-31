using BibliotecaBookHub.Models.Contracts.Repositories;
using BibliotecaBookHub.Models.DTO;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Services
{
    public class EmprestimoLivroService : IEmprestimoLivroService
    {
        private readonly IEmprestimoLivroRepository _emprestimoLivroRepository;

        public EmprestimoLivroService(IEmprestimoLivroRepository emprestimoLivroRepository)
        {
            _emprestimoLivroRepository = emprestimoLivroRepository;
        }

        public void EfetuarDevolucao(EmprestimoLivroDTO emprestimoLivro)
        {
            try
            {
                var entidade = emprestimoLivro.ConverterParaEntidade();
                _emprestimoLivroRepository.EfetuarDevolucao(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EfetuarEmprestimo(EmprestimoLivroDTO emprestimoLivro)
        {
            try
            {
                var entidade = emprestimoLivro.ConverterParaEntidade();
                _emprestimoLivroRepository.EfetuarEmprestimo(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
