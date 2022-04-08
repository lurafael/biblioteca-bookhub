using BibliotecaBookHub.Models.DTO;
using System.Collections.Generic;


namespace BibliotecaBookHub.Models.Contracts.Services
{
    public interface ILivroService
    {
        void Cadastrar(LivroDTO livro);
        List<LivroDTO> Listar();
        LivroDTO PesquisarPorId(string id);
        void Atualizar(LivroDTO livro);
        void Deletar(LivroDTO livro);
    }
}
