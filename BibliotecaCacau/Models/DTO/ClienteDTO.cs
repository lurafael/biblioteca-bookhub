using BibliotecaBookHub.Models.Entities;
using BibliotecaCacau.Models.Entities;
using System;

namespace BibliotecaBookHub.Models.DTO
{
    public class ClienteDTO : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string StatusClienteId { get; set; }
        public string Status { get; set; }

        public ClienteDTO()
        {
        }

        public Cliente ConverterParaEntidade()
        {
            return new Cliente
            {
                Id = Id,
                Cpf = Cpf,
                Nome = Nome, 
                Email = Email,
                Fone = Fone,
                StatusClienteId = !string.IsNullOrEmpty(StatusClienteId) ? Int32.Parse(StatusClienteId) : StatusCliente.ATIVO.GetHashCode(),
                StatusCliente = !string.IsNullOrEmpty(StatusClienteId) ? GerenciadorDeStatus.PesquisarStatusDoClientePeloId(Int32.Parse(StatusClienteId)) : StatusCliente.ATIVO
            };
        }
    }
}
