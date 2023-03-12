using Newtonsoft.Json;

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

        [JsonIgnore]
        public Marca Marca { get; set; }

        public string NomeMarca => Marca.Nome; 
    }
}
