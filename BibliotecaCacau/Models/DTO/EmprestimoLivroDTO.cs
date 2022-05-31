using BibliotecaBookHub.Models.Entities;
using BibliotecaCacau.Models.Entities;
using System;

namespace BibliotecaBookHub.Models.DTO
{
    public class EmprestimoLivroDTO : BaseEntity
    {
        public string ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public string LivroId { get; set; }
        public LivroDTO Livro { get; set; }
        public string UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolucaoEfetiva { get; set; }

        public EmprestimoLivro ConverterParaEntidade()
        {
            return new EmprestimoLivro
            {
                ClienteId = ClienteId,
                Cliente = Cliente.ConverterParaEntidade(),
                LivroId = LivroId,
                Livro = Livro.ConverterParaEntidade(),
                UsuarioId = UsuarioId,
                Usuario = Usuario.ConverterParaEntidade(),
                DataEmprestimo = DataEmprestimo,
                DataDevolucao = DataDevolucao,
                DataDevolucaoEfetiva = DataDevolucaoEfetiva,
            };
        }
    }
}
