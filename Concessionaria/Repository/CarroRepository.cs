using AutoMapper;
using Concessionaria.Contexts;
using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private ConcessionariaContext _context;
        private IMapper _mapper;

        public CarroRepository(ConcessionariaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CarroDto PegarCarro(long id)
        {
            var carro = _context.Carros.Include(p => p.Marca).FirstOrDefault(c => c.Id == id); ;

            if(carro?.Marca != null)
            {
                carro.Marca = null;
            }

            return _mapper.Map<CarroDto>(carro)!;
        }

        public bool InserirCarro(CarroDto carro)
        {
            try
            {
                _context.Carros.Add(_mapper.Map<Carro>(carro));

                _context.SaveChanges();

            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return true;
        }
    }
}
