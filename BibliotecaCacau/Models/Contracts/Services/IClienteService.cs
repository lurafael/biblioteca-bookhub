using BibliotecaBookHub.Models.DTO;
using System.Collections.Generic;


namespace BibliotecaBookHub.Models.Contracts.Services
{
    public interface IClienteService
    {
        void Cadastrar(ClienteDTO livro);
        List<ClienteDTO> Listar();
        ClienteDTO PesquisarPorId(string id);
        void Atualizar(ClienteDTO livro);
        void Deletar(ClienteDTO livro);
    }
}
