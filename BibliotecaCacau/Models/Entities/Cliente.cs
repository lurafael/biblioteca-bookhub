using BibliotecaBookHub.Models.DTO;
using BibliotecaBookHub.Models.Entities;

namespace BibliotecaCacau.Models.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public int StatusClienteId { get; set; }
        public StatusCliente StatusCliente { get; set; }

        public void Cadastrar()
        {
            StatusCliente = StatusCliente.ATIVO;
            StatusClienteId = StatusCliente.GetHashCode();
        }

        public ClienteDTO ConverterParaDTO()
        {
            return new ClienteDTO
            {
                Id = Id,
                Nome = Nome,
                Email = Email,
                Cpf = Cpf,
                StatusClienteId = StatusClienteId.ToString(),
                Status = GerenciadorDeStatus.PesquisarStatusDoClientePeloId(StatusClienteId).ToString()
            };
        }
    }
}
