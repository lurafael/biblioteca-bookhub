using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public interface ILivroRepository : IRepository<Livro, string>
    {
    }
}
