using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.Controllers
{
    [ApiController]
    [Route("carro/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _repository;

        public CarroController(ICarroRepository carroRepo)
        {
            _repository = carroRepo;
        }

        [HttpGet("{id}")]
        public ActionResult PegarCarro(long id)
        {
            var carro = _repository.PegarCarro(id);

            return Ok(carro);
        }

        [HttpPost("/inserir-carro")]
        public ActionResult InserirCarro(CarroDto carro)
        {
            _repository.InserirCarro(carro);
            
            return Ok();
        }
    }
}
