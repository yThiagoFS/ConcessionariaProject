namespace Concessionaria.Models
{
    public class Usuario
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string NomeCompleto => $"{Nome} {Sobrenome}";

        public string? Telefone { get; set; }

        public string? CPF { get; set; }

        //public DateTime DataDeNascimento { get; set; }

        public IEnumerable<Carro>? CarrosAnunciados { get; set; }
    }
}
