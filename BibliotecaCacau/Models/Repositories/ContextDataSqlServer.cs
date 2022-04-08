using BibliotecaBookHub.Models.Contracts;
using BibliotecaBookHub.Models.Contracts.Repositories;
using BibliotecaBookHub.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Models.Repositories
{
    public class ContextDataSqlServer : IContextData
    {
        private readonly SqlConnection _connection = null;

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }

        public void AtualizarLivro(LivroDTO livro)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(LivroDTO livro)
        {
            throw new NotImplementedException();
        }

        public void DeletarLivro(string id)
        {
            throw new NotImplementedException();
        }

        public List<LivroDTO> ListarLivro()
        {
            throw new NotImplementedException();
        }

        public LivroDTO PesquisarLivroPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
