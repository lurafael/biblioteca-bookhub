using BibliotecaBookHub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCacau.Models.Entities
{
    public class EmprestimoLivro
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string LivroId { get; set; }
        public Livro Livro { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolucaoEfetiva { get; set; }

        public void RealizarEmprestimo()
        {
            ValidarEmprestimo();
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DateTime.Parse(DataEmprestimo.AddDays(7).ToShortDateString());
        }

        public void RealizarDevolucao()
        {
            DataDevolucaoEfetiva = DateTime.Now;
        }

        public void ValidarEmprestimo()
        {
            if(string.IsNullOrEmpty(ClienteId) || string.IsNullOrEmpty(LivroId) || UsuarioId == 0)
            {
                throw new Exception("Dados Inválidos");
            }

        }
    }
}
