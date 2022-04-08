using BibliotecaBookHub.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Models.Contracts
{
    public interface IContextData
    {
        void CadastrarLivro(LivroDTO livro);
        List<LivroDTO> ListarLivro();
        LivroDTO PesquisarLivroPorId(string id);
        void AtualizarLivro(LivroDTO livro);
        void DeletarLivro(string id);
    }
}
