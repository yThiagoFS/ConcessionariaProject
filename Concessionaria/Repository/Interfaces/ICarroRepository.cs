using Concessionaria.Models;
using Concessionaria.Models.DTOs;

namespace Concessionaria.Repository.Interfaces
{
    public interface ICarroRepository
    {

        Carro PegarCarro(long id);

        bool InserirCarro(CarroDto carro);

        List<CarroDto>? PegarTodosOsCarros();

        bool DeletarCarro(long id);

    }
}
