namespace Concessionaria.Models
{
    public class Carro
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public int Ano { get; set; }

        public bool Usado { get; set; }

        public decimal Preco { get; set; }

        public Categoria Categoria { get;set; }

        public long MarcaId { get; set; }

        public Marca? Marca { get; set; }
    }
}
