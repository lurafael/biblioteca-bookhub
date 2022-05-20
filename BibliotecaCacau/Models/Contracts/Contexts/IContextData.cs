using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Models.Contracts
{
    public interface IContextData
    {
        void CadastrarLivro(Livro livro);
        List<Livro> ListarLivro();
        Livro PesquisarLivroPorId(string id);
        void AtualizarLivro(Livro livro);
        void DeletarLivro(string id);

        void CadastrarCliente(Cliente cliente);
        List<Cliente> ListarClientes();
        Cliente PesquisarClientePorId(string id);
        void AtualizarCliente(Cliente cliente);
        void DeletarCliente(string id);
    }
}
