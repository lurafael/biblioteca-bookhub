using BibliotecaBookHub.Models.Contracts.Repositories;
using BibliotecaBookHub.Models.DTO;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Atualizar(UsuarioDTO usuario)
        {
            try
            {
                var objUsuario = usuario.ConverterParaEntidade();
                _usuarioRepository.Deletar(objUsuario.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(UsuarioDTO usuario)
        {
            try
            {
                var objUsuario = usuario.ConverterParaEntidade();
                _usuarioRepository.Cadastrar(objUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDTO EfetuarLogin(UsuarioDTO usuario)
        {
            return _usuarioRepository.EfetuarLogin(usuario);
        }

        public List<UsuarioDTO> Listar()
        {
            try
            {
                var usuariosDTO = new List<UsuarioDTO>();
                var usuarios = _usuarioRepository.Listar();

                foreach (var item in usuarios)
                {
                    usuariosDTO.Add(item.ConverterParaDTO());
                }

                return usuariosDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDTO PesquisarPorId(int id)
        {
            try
            {
                var usuario = _usuarioRepository.PesquisarPorId(id);
                return usuario.ConverterParaDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
