using BibliotecaBookHub.Models.Entities;
using BibliotecaCacau.Models.Entities;

namespace BibliotecaBookHub.Models.DTO
{
    public class LivroDTO : BaseEntity
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int StatusLivroId { get; set; }
        public string Status { get; set; }

        public LivroDTO()
        {
        }

        public Livro ConverterParaEntidade()
        {
            return new Livro
            {
                Id = Id, 
                Nome = Nome, 
                Autor = Autor, 
                Editora = Editora,
                StatusLivro = GerenciadorDeStatus.PesquisarStatusDoLivroPeloId(StatusLivroId)
            };
        }
    }
}
