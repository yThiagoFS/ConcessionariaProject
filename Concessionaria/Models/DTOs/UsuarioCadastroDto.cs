namespace Concessionaria.Models.DTOs
{
    public class UsuarioCadastroDto
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        //public DateTime DataDeNascimento { get; set; }

        public string? CPF { get; set; }

    }
}
