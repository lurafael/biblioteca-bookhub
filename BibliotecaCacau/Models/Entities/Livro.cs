using BibliotecaBookHub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCacau.Models.Entities
{
    public class Livro : BaseEntity
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public StatusLivro StatusLivroId { get; set; }
    }
}
