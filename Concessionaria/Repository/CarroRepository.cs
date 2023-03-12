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

        public Carro PegarCarro(long id)
        {
            var carro = _context.Carros.Include(p => p.Marca).FirstOrDefault(c => c.Id == id); ;

            return carro!;
        }

        public bool InserirCarro(CarroDto carro)
        {
            try
            {
                _context.Carros.Add(_mapper.Map<Carro>(carro));

                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return true;
        }

        public List<CarroDto>? PegarTodosOsCarros()
        {
            try
            {
                var carrosRepo = _context.Carros.Include(p => p.Marca).ToList();

                if (carrosRepo.Any())
                {
                    return _mapper.Map<List<CarroDto>>(carrosRepo);
                }

                return null;
                
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public bool DeletarCarro(long id)
        {
            try
            {
                var carroSelecionado = _context.Carros.FirstOrDefault(x => x.Id == id);

                if(carroSelecionado != null)
                {
                    _context.Carros.Remove(carroSelecionado);

                    _context.SaveChanges();

                    return true;
                }


                return false;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

        }
    }
}
