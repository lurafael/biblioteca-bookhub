using BibliotecaBookHub.Models.DTO;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
        void Cadastrar(LivroDTO livro);
        List<LivroDTO> Listar();
        LivroDTO PesquisarPorId(string id);
        void Atualizar(LivroDTO livro);
        void Deletar(LivroDTO livro);
    }
}
