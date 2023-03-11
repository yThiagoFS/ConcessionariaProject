using Concessionaria.Models;
using Concessionaria.Models.DTOs;

namespace Concessionaria.Repository.Interfaces
{
    public interface IMarcaRepository
    {
        Marca PegarMarca(long id);

        bool InserirMarca(MarcaDto marca);

        bool DeletarMarca(long id);
    }
}
