using BibliotecaBookHub.Models.Contracts;
using BibliotecaBookHub.Models.Contracts.Repositories;
using BibliotecaBookHub.Models.DTO;
using BibliotecaBookHub.Models.Enums;
using BibliotecaBookHub.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Models.Contexts
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
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.ATUALIZAR_LIVRO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public void CadastrarLivro(LivroDTO livro)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;
                command.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = livro.StatusLivroId;

                command.ExecuteNonQuery();
            } 
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public void DeletarLivro(string id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_LIVRO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public List<LivroDTO> ListarLivro()
        {
            var livros = new List<LivroDTO>();
            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_LIVRO);
                var command = new SqlCommand(query, _connection);
                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach(DataRow row in rows)
                {
                    var colunas = row.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();

                    var livro = new LivroDTO {Id = id, Nome = nome, Autor = autor, Editora = editora };
                    livros.Add(livro);
                }

                adapter = null;
                dataSet = null;

                return livros;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public LivroDTO PesquisarLivroPorId(string id)
        {
            try
            {
                LivroDTO livro = null;
                var query = SqlManager.GetSql(TSql.PESQUISAR_LIVRO);
                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;

                    var codigo = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();

                    livro = new LivroDTO { Id = id, Nome = nome, Autor = autor, Editora = editora };
                }

                adapter = null;
                dataSet = null;

                return livro;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
    }
}
