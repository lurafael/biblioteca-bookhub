using BibliotecaBookHub.Models.Entities;

namespace BibliotecaBookHub.Models.DTO
{
    public class LivroDTO : BaseEntity
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

        public LivroDTO()
        {
        }

        public LivroDTO(string nome, string autor, string editora)
        {
            Nome = nome;
            Autor = autor;
            Editora = editora;
        }
    }
}
