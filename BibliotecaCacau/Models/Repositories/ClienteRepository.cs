using BibliotecaCacau.Models.Entities;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public class ClienteRepository : IClienteRepository { 
        private readonly IContextData _contextData;

        public ClienteRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(Cliente cliente)
        {
            _contextData.AtualizarCliente(cliente);
        }

        public void Cadastrar(Cliente cliente)
        {
            _contextData.CadastrarCliente(cliente);
        }

        public void Deletar(string Id)
        {
            _contextData.DeletarCliente(Id);
        }

        public List<Cliente> Listar()
        {
            return _contextData.ListarClientes();
        }

        public Cliente PesquisarPorId(string id)
        {
            return _contextData.PesquisarClientePorId(id);
        }
    }
}
