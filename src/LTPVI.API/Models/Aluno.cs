using System;

namespace LTPVI.API.Models
{
    public class Aluno
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Curso { get; private set; }

        public Aluno(int id, string nome, DateTime dataNascimento, string curso)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Curso = curso;
        }
    }
}