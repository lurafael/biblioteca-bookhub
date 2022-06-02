using BibliotecaBookHub.Models.DTO;
using BibliotecaBookHub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCacau.Models.Entities
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public UsuarioDTO ConverterParaDTO()
        {
            return new UsuarioDTO
            {
                Id = Id,
                Login = Login,
                Senha = Senha
            };
        }
    }
}
