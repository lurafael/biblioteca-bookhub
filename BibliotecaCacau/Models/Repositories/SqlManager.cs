using BibliotecaBookHub.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBookHub.Models.Repositories
{
    public class SqlManager
    {
        public static string GetSql(TSql tsql)
        {
            var query = "";

            switch (tsql)
            {
                #region LIVROS
                case TSql.CADASTRAR_LIVRO:
                    query = 
                        "INSERT INTO LIVRO (id, nome, autor, editora, statusLivroId) " +
                        "VALUES (CONVERT(BINARY(36), @id), @nome, @autor, @editora, @statusLivroId)";
                    break;
                case TSql.LISTAR_LIVRO:
                    query = "SELECT CONVERT(VARCHAR(36), Id) ID, NOME, AUTOR, EDITORA, STATUSLIVROID " +
                            "FROM LIVRO " +
                            "ORDER BY NOME";
                    break;
                case TSql.PESQUISAR_LIVRO:
                    query = "SELECT CONVERT(VARCHAR(36), Id) ID, NOME, AUTOR, EDITORA  " +
                            "FROM LIVRO " +
                            "WHERE ID = @id";
                    break;
                case TSql.ATUALIZAR_LIVRO:
                    query = "UPDATE LIVRO " + 
                            "SET NOME = @nome, AUTOR = @autor, EDITORA = @editora " +
                            "WHERE ID = @id";
                    break;
                case TSql.EXCLUIR_LIVRO:
                    query = "DELETE FROM LIVRO " +
                            "WHERE ID = @id";
                    break;
                #endregion

                #region CLIENTES
                case TSql.CADASTRAR_CLIENTE:
                    query = "INSERT INTO CLIENTE (id, nome, cpf, email, fone, statusClienteId) " +
                            "VALUES (CONVERT(BINARY(36), @id), @nome, @cpf, @email, @fone, @statusClienteId)";
                    break;
                case TSql.LISTAR_CLIENTE:
                    query = "SELECT CONVERT(VARCHAR(36), Id) id, nome, cpf, email, fone, statusClienteId " +
                            "FROM CLIENTE " +
                            "ORDER BY NOME";
                    break;
                case TSql.PESQUISAR_CLIENTE:
                    query = "SELECT CONVERT(VARCHAR(36), Id) id, nome, cpf, email, fone, statusClienteId " +
                            "FROM CLIENTE " +
                            "WHERE ID = @id";
                    break;
                case TSql.ATUALIZAR_CLIENTE:
                    query = "UPDATE CLIENTE " +
                            "SET NOME = @nome, CPF = @cpf, EMAIL = @email, FONE = @email " +
                            "WHERE CONVERT(VARCHAR(36), Id) = @id";
                    break;
                case TSql.EXCLUIR_CLIENTE:
                    query = "DELETE FROM CLIENTE " +
                            "WHERE CONVERT(VARCHAR(36), Id) = @id";
                    break;
                #endregion

                #region USUÁRIO
                case TSql.CADASTRAR_USUARIO:
                    query = "INSERT INTO USUARIO (LOGIN, SENHA) " +
                            "VALUES (@login, @senha)";
                    break;
                case TSql.LISTAR_USUARIO:
                    query = "SELECT ID, LOGIN, SENHA " +
                            "FROM USUARIO " +
                            "ORDER BY NOME";
                    break;
                case TSql.PESQUISAR_USUARIO:
                    query = "SELECT ID, LOGIN, SENHA " +
                            "FROM USUARIO " +
                            "WHERE ID = @id";
                    break;
                case TSql.ATUALIZAR_USUARIO:
                    query = "UPDATE USUARIO " +
                            "SET SENHA = @senha " +
                            "WHERE Id = @id";
                    break;
                case TSql.EXCLUIR_USUARIO:
                    query = "DELETE FROM USUARIO " +
                            "WHERE Id = @id";
                    break;
                case TSql.EFETUAR_LOGIN:
                    query = "SELECT ID, LOGIN FROM USUARIO " +
                            "WHERE LOGIN = @login and SENHA = @senha";
                    break;
                #endregion


                #region Empréstimo de Livros
                case TSql.EFETUAR_EMPRESTIMO_LIVRO:
                    query = "INSERT INTO EMPRESTIMOLIVRO (CLIENTEID, USUARIOID, LIVROID, DATAEMPRESTIMO, DATADEVOLUCAO) " +
                            "VALUES (CONVERT(BINARY(36), @clienteId), @usuarioId, CONVERT(BINARY(36), @livroId), @dataEmprestimo, @dataDevolucao)";
                    break;
                case TSql.EFETUAR_DEVOLUCAO_LIVRO:
                    query = "UPDATE EMPRESTIMOLIVRO " +
                            "SET DATADEVOLUCAOEFETIVA = @dataDevolucaoEfetiva " +
                            "WHERE CLIENTEID = @clienteId and LIVROID = @livroId";
                    break;
                
                case TSql.ATUALIZAR_STATUS_LIVRO:
                    query = "UPDATE LIVRO " +
                            "SET STATUSLIVROID = @statusLivroId " +
                            "WHERE CONVERT(varchar(36), id) = @id";
                    break;
                    #endregion
            }
            return query;
        }
    }
}
