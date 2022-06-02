using BibliotecaCacau.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public class EmprestimoLivroRepository : IEmprestimoLivroRepository
    { 
        private readonly IContextData _contextData;

        public EmprestimoLivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void AtualizarStatusEmprestimoLivros()
        {
            _contextData.AtualizarStatusEmprestimoLivros();
        }

        public List<ConsultaEmprestimoDTO> ConsultarEmprestimos()
        {
            return _contextData.ConsultarEmprestimos();
        }

        public void EfetuarDevolucao(int emprestimoId, string livroId)
        {
            _contextData.EfetuarDevolucaoLivro(emprestimoId, livroId);
        }

        public void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro)
        {
            _contextData.EfetuarEmprestimoLivro(emprestimoLivro);
        }

        public ConsultaEmprestimoDTO PesquisarEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo)
        {
            return _contextData.PesquisarEmprestimo(nomeLivro, nomeCliente, dataEmprestimo);
        }
    }
}
