using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public interface IEmprestimoLivroRepository
    {
        void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro);
        void EfetuarDevolucao(EmprestimoLivro emprestimoLivro);
        List<ConsultaEmprestimoDTO> ConsultarEmprestimos();
        ConsultaEmprestimoDTO PesquisarEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo);
    }
}
