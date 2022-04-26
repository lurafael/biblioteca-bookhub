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

            switch(tsql)
            {
                case TSql.CADASTRAR_LIVRO:
                    query = 
                        "INSERT INTO LIVRO (id, nome, autor, editora) " +
                        "VALUES (@id, @nome, @autor, @editora)";
                    break;
                case TSql.LISTAR_LIVRO:
                    query = "SELECT * " +
                            "FROM LIVRO " +
                            "ORDER BY NOME";
                    break;
                case TSql.PESQUISAR_LIVRO:
                    query = "SELECT * " +
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
            }

            return query;
        }
    }
}
