using BibliotecaBookHub.Models.DTO;
using BibliotecaBookHub.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly IContextData _contextData;

        public LivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(LivroDTO livro)
        {
            _contextData.AtualizarLivro(livro);
        }

        public void Cadastrar(LivroDTO livro)
        {
            _contextData.CadastrarLivro(livro);
        }

        public void Deletar(LivroDTO livro)
        {
            _contextData.DeletarLivro(livro.Id);
        }

        public List<LivroDTO> Listar()
        {
            return _contextData.ListarLivro();
        }

        public LivroDTO PesquisarPorId(string id)
        {
            return _contextData.PesquisarLivroPorId(id);
        }
    }
}
