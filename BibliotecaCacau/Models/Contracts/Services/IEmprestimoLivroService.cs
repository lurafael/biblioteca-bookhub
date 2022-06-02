using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.DTO;
using System;
using System.Collections.Generic;


namespace BibliotecaBookHub.Models.Contracts.Services
{
    public interface IEmprestimoLivroService
    {
        void EfetuarEmprestimo(EmprestimoLivroDTO emprestimoLivro);
        void EfetuarDevolucao(int emprestimoId, string livroId);
        List<ConsultaEmprestimoDTO> ConsultarEmprestimos();
        ConsultaEmprestimoDTO PesquisarEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo);
        void AtualizarStatusEmprestimoLivros();
    }
}
