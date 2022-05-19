using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
        void Cadastrar(Livro livro);
        List<Livro> Listar();
        Livro PesquisarPorId(string id);
        void Atualizar(Livro livro);
        void Deletar(Livro livro);
    }
}
