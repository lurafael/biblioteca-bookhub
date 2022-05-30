using BibliotecaCacau.Models.Entities;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Repositories
{
    public class UsuarioRepository : IUsuarioRepository 
    { 
        private readonly IContextData _contextData;

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

        public List<Usuario> Listar()
        {
            throw new System.NotImplementedException();
        }

        public Usuario PesquisarPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
