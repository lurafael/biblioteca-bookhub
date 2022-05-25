using BibliotecaBookHub.Models.Contracts.Repositories;
using BibliotecaBookHub.Models.DTO;
using System;
using System.Collections.Generic;

namespace BibliotecaBookHub.Models.Contracts.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Deletar(ClienteDTO cliente)
        {
            try
            {
                var objCliente = cliente.ConverterParaEntidade();
                _clienteRepository.Deletar(objCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(ClienteDTO cliente)
        {
            try
            {
                var objCliente = cliente.ConverterParaEntidade();
                _clienteRepository.Atualizar(objCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(ClienteDTO cliente)
        {
            try
            {
                var objCliente = cliente.ConverterParaEntidade();
                objCliente.Cadastrar();
                _clienteRepository.Cadastrar(objCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteDTO> Listar()
        {
            try
            {
                var clientesDTO = new List<ClienteDTO>();
                var clientes = _clienteRepository.Listar();

                foreach(var item in clientes)
                {
                    clientesDTO.Add(item.ConverterParaDTO());
                }

                return clientesDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ClienteDTO PesquisarPorId(string id)
        {
            try
            {
                var cliente = _clienteRepository.PesquisarPorId(id);
                return cliente.ConverterParaDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
