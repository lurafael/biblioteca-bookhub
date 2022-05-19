using BibliotecaCacau.Models.Entities;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly IContextData _contextData;

        public LivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(Livro livro)
        {
            _contextData.AtualizarLivro(livro);
        }

        public void Cadastrar(Livro livro)
        {
            _contextData.CadastrarLivro(livro);
        }

        public void Deletar(Livro livro)
        {
            _contextData.DeletarLivro(livro.Id);
        }

        public List<Livro> Listar()
        {
            return _contextData.ListarLivro();
        }

        public Livro PesquisarPorId(string id)
        {
            return _contextData.PesquisarLivroPorId(id);
        }
    }
}
