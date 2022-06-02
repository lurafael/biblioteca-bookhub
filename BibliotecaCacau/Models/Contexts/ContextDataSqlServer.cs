using BibliotecaBookHub.Models.Contracts;
using BibliotecaBookHub.Models.Contracts.Repositories;
using BibliotecaBookHub.Models.DTO;
using BibliotecaBookHub.Models.Enums;
using BibliotecaBookHub.Models.Repositories;
using BibliotecaCacau.Models.DTO;
using BibliotecaCacau.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaBookHub.Models.Contexts
{
    public class ContextDataSqlServer : IContextData
    {
        private readonly SqlConnection _connection = null;

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }

        #region Livros
        public void AtualizarLivro(Livro livro)
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

        public void CadastrarLivro(Livro livro)
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
                command.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = livro.StatusLivro.GetHashCode();

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

        public List<Livro> ListarLivro()
        {
            var livros = new List<Livro>();
            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_LIVRO);
                var command = new SqlCommand(query, _connection);
                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();
                    var statusLivroId = colunas[4].ToString();

                    var livro = new Livro { Id = id, Nome = nome, Autor = autor, Editora = editora, StatusLivroId = Int32.Parse(statusLivroId) };
                    livro.StatusLivro = GerenciadorDeStatus.PesquisarStatusDoLivroPeloId(livro.StatusLivroId);
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

        public Livro PesquisarLivroPorId(string id)
        {
            try
            {
                Livro livro = null;
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

                    livro = new Livro { Id = id, Nome = nome, Autor = autor, Editora = editora };
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

        #endregion

        #region Clientes
        public void AtualizarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.ATUALIZAR_CLIENTE);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.Cpf;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;

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

        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.CADASTRAR_CLIENTE);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.Cpf;
                command.Parameters.Add("@statusClienteId", SqlDbType.Int).Value = cliente.StatusCliente.GetHashCode();

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

        public void DeletarCliente(string id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_CLIENTE);
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

        public List<Cliente> ListarClientes()
        {
            var clientes = new List<Cliente>();
            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_CLIENTE);
                var command = new SqlCommand(query, _connection);
                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusClienteId = colunas[5].ToString();

                    var cliente = new Cliente { Id = id, Nome = nome, Cpf = cpf, Fone = fone, Email = email, StatusClienteId = Int32.Parse(statusClienteId) };
                    cliente.StatusCliente = GerenciadorDeStatus.PesquisarStatusDoClientePeloId(cliente.StatusClienteId);
                    clientes.Add(cliente);
                }

                adapter = null;
                dataSet = null;

                return clientes;
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

        public Cliente PesquisarClientePorId(string id)
        {
            try
            {
                Cliente cliente = null;
                var query = SqlManager.GetSql(TSql.PESQUISAR_CLIENTE);
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
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusClienteId = colunas[5].ToString();

                    cliente = new Cliente { Id = id, Nome = nome, Cpf = cpf, Fone = fone, Email = email, StatusClienteId = Int32.Parse(statusClienteId) };
                    cliente.StatusCliente = GerenciadorDeStatus.PesquisarStatusDoClientePeloId(cliente.StatusClienteId);
                }

                adapter = null;
                dataSet = null;

                return cliente;
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
        #endregion

        #region Usuários
        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.ATUALIZAR_USUARIO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

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

        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.CADASTRAR_USUARIO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

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

        public void DeletarUsuario(int id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_USUARIO);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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

        public List<Usuario> ListarUsuarios()
        {
            var usuarios = new List<Usuario>();
            try
            {
                var query = SqlManager.GetSql(TSql.LISTAR_USUARIO);
                var command = new SqlCommand(query, _connection);
                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;

                    var id = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                    var senha = colunas[2].ToString();

                    var usuario = new Usuario { Id = id, Login = login, Senha = senha };
                    usuarios.Add(usuario);
                }

                adapter = null;
                dataSet = null;

                return usuarios;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario PesquisarUsuarioPorId(int id)
        {
            try
            {
                Usuario usuario = null;
                var query = SqlManager.GetSql(TSql.PESQUISAR_USUARIO);
                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;

                    var codigo = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                    var senha = colunas[2].ToString();

                    usuario = new Usuario { Id = codigo, Login = login, Senha = senha };
                }

                adapter = null;
                dataSet = null;

                return usuario;
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

        public UsuarioDTO EfetuarLogin(UsuarioDTO usuario)
        {
            try
            {
                UsuarioDTO result = null;
                var query = SqlManager.GetSql(TSql.EFETUAR_LOGIN);
                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;

                    var codigo = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();

                    result = new UsuarioDTO { Id = codigo, Login = login };
                }

                adapter = null;
                dataSet = null;

                return result;
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
        #endregion

        #region Empréstimos
        public void EfetuarEmprestimoLivro(EmprestimoLivro emprestimoLivro)
        {
            SqlTransaction transaction = null;
            try
            {
                _connection.Open();
                transaction = _connection.BeginTransaction();

                var queryEmprestimo = SqlManager.GetSql(TSql.EFETUAR_EMPRESTIMO_LIVRO);
                var commandEmprestimo = new SqlCommand(queryEmprestimo, _connection, transaction);

                commandEmprestimo.Parameters.Add("@clienteId", SqlDbType.VarChar).Value = emprestimoLivro.ClienteId;
                commandEmprestimo.Parameters.Add("@usuarioId", SqlDbType.Int).Value = emprestimoLivro.UsuarioId;
                commandEmprestimo.Parameters.Add("@livroId", SqlDbType.VarChar).Value = emprestimoLivro.LivroId;
                commandEmprestimo.Parameters.Add("@dataEmprestimo", SqlDbType.DateTime).Value = emprestimoLivro.DataEmprestimo;
                commandEmprestimo.Parameters.Add("@dataDevolucao", SqlDbType.DateTime).Value = emprestimoLivro.DataDevolucao;
                commandEmprestimo.ExecuteNonQuery();

                var queryDevolucao = SqlManager.GetSql(TSql.ATUALIZAR_STATUS_LIVRO);
                var commandDevolucao = new SqlCommand(queryDevolucao, _connection, transaction);

                commandDevolucao.Parameters.Add("@id", SqlDbType.VarChar).Value = emprestimoLivro.LivroId;
                commandDevolucao.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = StatusLivro.EMPRESTADO.GetHashCode();
                commandDevolucao.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception e)
            {
                if(transaction != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public void EfetuarDevolucaoLivro(int emprestimoId, string livroId)
        {
            SqlTransaction transaction = null;
            try
            {
                _connection.Open();
                transaction = _connection.BeginTransaction();

                var queryEmprestimo = SqlManager.GetSql(TSql.EFETUAR_DEVOLUCAO_LIVRO);
                var commandEmprestimo = new SqlCommand(queryEmprestimo, _connection, transaction);

                commandEmprestimo.Parameters.Add("@id", SqlDbType.Int).Value = emprestimoId;
                commandEmprestimo.Parameters.Add("@dataDevolucaoEfetiva", SqlDbType.DateTime).Value = DateTime.Now;
                commandEmprestimo.ExecuteNonQuery();

                var queryDevolucao = SqlManager.GetSql(TSql.ATUALIZAR_STATUS_LIVRO);
                var commandDevolucao = new SqlCommand(queryDevolucao, _connection, transaction);

                commandDevolucao.Parameters.Add("@id", SqlDbType.VarChar).Value = livroId;
                commandDevolucao.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = StatusLivro.DISPONIVEL.GetHashCode();
                commandDevolucao.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception e)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public List<ConsultaEmprestimoDTO> ConsultarEmprestimos()
        {
            var emprestimos = new List<ConsultaEmprestimoDTO>();
            try
            {
                var query = SqlManager.GetSql(TSql.CONSULTAR_EMPRESTIMOS_LIVROS);
                var command = new SqlCommand(query, _connection);
                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;
                    var emprestimo = new ConsultaEmprestimoDTO
                    {
                        Livro = colunas[0].ToString(),
                        Autor = colunas[1].ToString(),
                        Editora = colunas[2].ToString(),
                        Cliente = colunas[3].ToString(),
                        CPF = colunas[4].ToString(),
                        DataEmprestimo = DateTime.Parse(colunas[5].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucao = DateTime.Parse(colunas[6].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucaoEfetiva = colunas[7].ToString(),
                        StatusLivro = colunas[8].ToString(),
                        LoginBibliotecario = colunas[9].ToString(),
                        Id = Int32.Parse(colunas[10].ToString()),
                        LivroId = colunas[11].ToString()
                    };
                    
                    emprestimos.Add(emprestimo);
                }

                adapter = null;
                dataSet = null;

                return emprestimos;
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

        public ConsultaEmprestimoDTO PesquisarEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo)
        {
            ConsultaEmprestimoDTO emprestimo = null;

            try
            {
                var query = SqlManager.GetSql(TSql.PESQUISAR_EMPRESTIMOS_LIVROS);
                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@nomeLivro", SqlDbType.VarChar).Value = nomeLivro;
                command.Parameters.Add("@nomeCliente", SqlDbType.VarChar).Value = nomeCliente;
                command.Parameters.Add("@dataEmprestimo", SqlDbType.DateTime).Value = dataEmprestimo;

                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    var colunas = row.ItemArray;
                    
                    emprestimo = new ConsultaEmprestimoDTO
                    {
                        Livro = colunas[0].ToString(),
                        Autor = colunas[1].ToString(),
                        Editora = colunas[2].ToString(),
                        Cliente = colunas[3].ToString(),
                        CPF = colunas[4].ToString(),
                        DataEmprestimo = DateTime.Parse(colunas[5].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucao = DateTime.Parse(colunas[6].ToString()).ToString("dd/MM/yyyy"),
                        DataDevolucaoEfetiva = colunas[7].ToString(),
                        StatusLivro = colunas[8].ToString(),
                        LoginBibliotecario = colunas[9].ToString(),
                        Id = Int32.Parse(colunas[10].ToString()),
                        LivroId = colunas[11].ToString()
                    };
                }

                adapter = null;
                dataSet = null;

                return emprestimo;
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

        public void AtualizarStatusEmprestimoLivros()
        {
            try
            {
                string proc = SqlManager.GetSql(TSql.ATUALIZAR_STATUS_EMPRESTIMOS_LIVROS);

                _connection.Open();
                var command = new SqlCommand(proc, _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command = null;
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
        #endregion
    }
}
