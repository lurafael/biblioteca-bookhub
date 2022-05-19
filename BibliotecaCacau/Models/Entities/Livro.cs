using BibliotecaBookHub.Models.DTO;
using BibliotecaBookHub.Models.Entities;

namespace BibliotecaCacau.Models.Entities
{
    public class Livro : BaseEntity
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public StatusLivro StatusLivro { get; set; }
    

        public Livro()
            :base()
        {
        }

        public void Cadastrar()
        {
            this.StatusLivro = StatusLivro.DISPONIVEL;
        }

        public LivroDTO ConverterParaDTO()
        {
            return new LivroDTO
            {
                Id = Id,
                Nome = Nome,
                Autor = Autor,
                Editora = Editora,
                StatusLivroId = StatusLivro.GetHashCode(),
                Status = StatusLivro.ToString()
            };
        }
    }
}
