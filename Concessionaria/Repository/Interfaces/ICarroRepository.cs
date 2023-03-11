using Concessionaria.Models;
using Concessionaria.Models.DTOs;

namespace Concessionaria.Repository.Interfaces
{
    public interface ICarroRepository
    {

        CarroDto PegarCarro(long id);

        bool InserirCarro(CarroDto carro);

    }
}
