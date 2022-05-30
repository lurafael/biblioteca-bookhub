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
                    query = "SELECT CONVERT(VARCHAR(36), Id) Id, Nome, Autor, Editora " +
                            "FROM LIVRO " +
                            "ORDER BY NOME";
                    break;
                case TSql.PESQUISAR_LIVRO:
                    query = "SELECT CONVERT(VARCHAR(36), Id) Id, Nome, Autor, Editora " +
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
                    query =
                        "INSERT INTO CLIENTE (id, nome, cpf, email, fone, statusClienteId) " +
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
                    query =
                        "INSERT INTO USUARIO (LOGIN, SENHA) " +
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
                    #endregion
            }

            return query;
        }
    }
}
