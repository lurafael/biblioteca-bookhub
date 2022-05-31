using BibliotecaCacau.Models.Entities;
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

        public void EfetuarDevolucao(EmprestimoLivro emprestimoLivro)
        {
            _contextData.EfetuarDevolucaoLivro(emprestimoLivro);
        }

        public void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro)
        {
            _contextData.EfetuarEmprestimoLivro(emprestimoLivro);
        }
    }
}
