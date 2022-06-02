using BibliotecaBookHub.Models.DTO;
using System.Collections.Generic;


namespace BibliotecaBookHub.Models.Contracts.Services
{
    public interface IGenericService<T, Y>
    {
        void Cadastrar(T entidade);
        List<T> Listar();
        T PesquisarPorId(Y id);
        void Atualizar(T entidade);
        void Deletar(Y id);
    }
}
