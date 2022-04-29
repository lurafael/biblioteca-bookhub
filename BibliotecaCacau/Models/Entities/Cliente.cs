using BibliotecaBookHub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCacau.Models.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public StatusCliente StatusClienteId { get; set; }
    }
}
