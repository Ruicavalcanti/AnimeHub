using AnimeHub.Domain.Validation;
using System.Text.Json.Serialization;

namespace AnimeHub.Domain.Entities
{
    public sealed class Anime : Entity
    {
        public string Nome { get; private set; } = string.Empty;
        public string Diretor { get; private set; } = string.Empty;
        public string Resumo { get; private set; } = string.Empty;
        public Anime() { }
        public Anime(string nome, string diretor, string resumo)
        {
            Nome = nome;
            Diretor = diretor;
            Resumo = resumo;
            ValidateDomain(nome, diretor, resumo);
        }
        public void Update(string nome, string diretor, string resumo)
        {
            Nome = nome;
            Diretor = diretor;
            Resumo = resumo;
            ValidateDomain(nome, diretor, resumo);
        }
        [JsonConstructor]
        public Anime(int id, string nome, string diretor, string resumo)
        {
            DomainValidation.When(id < 0, "ID inválido");
            Id = id;
            Nome = nome;
            Diretor = diretor;
            Resumo = resumo;
            ValidateDomain(nome, diretor, resumo);
        }
        private void ValidateDomain(string nome, string diretor, string resumo)
        {
            DomainValidation.When(string.IsNullOrEmpty(nome),
                "Nome é Obrigatório");
            DomainValidation.When(nome.Length < 3,
                "Minimo de e caracteres para o Nome");
            DomainValidation.When(string.IsNullOrEmpty(diretor),
                "Nome é Obrigatório");
            DomainValidation.When(diretor.Length < 3,
                "Minimo de e caracteres para o Nome");
            DomainValidation.When(string.IsNullOrEmpty(resumo),
                "Nome é Obrigatório");
            DomainValidation.When(resumo.Length < 3,
                "Minimo de e caracteres para o Nome");
        }
    }
}
