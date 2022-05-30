using BibliotecaBookHub.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public class UsuarioRepository : IUsuarioRepository 
    { 
        private readonly IContextData _contextData;

        public UsuarioRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(Usuario entidade)
        {
            _contextData.AtualizarUsuario(entidade);
        }

        public void Cadastrar(Usuario entidade)
        {
            _contextData.CadastrarUsuario(entidade);
        }

        public void Deletar(int Id)
        {
            _contextData.DeletarUsuario(Id);
        }

        public UsuarioDTO EfetuarLogin(UsuarioDTO usuario)
        {
            return _contextData.EfetuarLogin(usuario);
        }

        public List<Usuario> Listar()
        {
            return _contextData.ListarUsuarios();
        }

        public Usuario PesquisarPorId(int id)
        {
            return _contextData.PesquisarUsuarioPorId(id);
        }
    }
}
