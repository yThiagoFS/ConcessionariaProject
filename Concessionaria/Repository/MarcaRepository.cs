using AutoMapper;
using Concessionaria.Contexts;
using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly IMapper _mapper;
        private ConcessionariaContext _context;

        public MarcaRepository(ConcessionariaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Marca PegarMarca(long id)
        {
            var marca = _context.Marcas.Include(c => c.Carros).FirstOrDefault(m => m.MarcaId == id);

            return marca!;
        }

        public bool InserirMarca(MarcaDto marca)
        {
            _context.Marcas.Add(_mapper.Map<Marca>(marca));

            _context.SaveChanges();

            return true;
        }

        public bool DeletarMarca(long id)
        {
            var marca = _context.Marcas.Find(id);

            _context.Marcas.Remove(marca);

            _context.SaveChanges();

            return true;
        }

    }
}
