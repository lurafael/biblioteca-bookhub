using BibliotecaBookHub.Models.DTO;
using System.Collections.Generic;


namespace BibliotecaBookHub.Models.Contracts.Services
{
    public interface IEmprestimoLivroService
    {
        void EfetuarEmprestimo(EmprestimoLivroDTO emprestimoLivro);
        void EfetuarDevolucao(EmprestimoLivroDTO emprestimoLivro);
    }
}
