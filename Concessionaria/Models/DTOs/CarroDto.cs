namespace Concessionaria.Models.DTOs
{
    public class CarroDto
    {
        public string Nome { get; set; }

        public int Ano { get; set; }

        public bool Usado { get; set; }

        public decimal Preco { get; set; }

        public Categoria Categoria { get; set; }

        public string NomeMarca { get; set; }
    }
}
