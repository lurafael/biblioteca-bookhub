using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public interface IEmprestimoLivroRepository
    {
        void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro);
        void EfetuarDevolucao(EmprestimoLivro emprestimoLivro);
    }
}
