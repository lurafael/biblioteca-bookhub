using BibliotecaBookHub.Models.Entities;
using BibliotecaCacau.Models.Entities;

namespace BibliotecaBookHub.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario ConverterParaEntidade()
        {
            return new Usuario
            {
                Id = Id,
                Login = Login,
                Senha = Senha
            };
        }
    }
}
