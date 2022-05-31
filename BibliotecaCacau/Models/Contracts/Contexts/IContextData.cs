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
        #region Livros
        void CadastrarLivro(Livro livro);
        List<Livro> ListarLivro();
        Livro PesquisarLivroPorId(string id);
        void AtualizarLivro(Livro livro);
        void DeletarLivro(string id);
        #endregion

        #region Clientes
        void CadastrarCliente(Cliente cliente);
        List<Cliente> ListarClientes();
        Cliente PesquisarClientePorId(string id);
        void AtualizarCliente(Cliente cliente);
        void DeletarCliente(string id);
        #endregion

        #region Usuários
        void CadastrarUsuario(Usuario usuario);
        List<Usuario> ListarUsuarios();
        Usuario PesquisarUsuarioPorId(int id);
        void AtualizarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        UsuarioDTO EfetuarLogin(UsuarioDTO usuario);
        #endregion

        #region Empréstimo
        void EfetuarEmprestimoLivro(EmprestimoLivro emprestimoLivro);
        void EfetuarDevolucaoLivro(EmprestimoLivro emprestimoLivro);
        #endregion
    }
}
