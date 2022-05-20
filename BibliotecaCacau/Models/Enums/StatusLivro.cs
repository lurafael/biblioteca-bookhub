using BibliotecaBookHub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCacau.Models.Entities
{
    public enum StatusLivro 
    {
       DISPONIVEL = 1,
       EMPRESTADO,
       ATRASO_DEVOLUCAO,
       USO_LOCAL
    }
}
