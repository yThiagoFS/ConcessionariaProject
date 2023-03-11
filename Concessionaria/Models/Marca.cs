namespace Concessionaria.Models
{
    public class Marca
    {
        public long MarcaId { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Carro>? Carros { get; set; }

    }
}
