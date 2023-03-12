using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet]
        public ActionResult Carros()
        {
            var carros = JsonConvert.SerializeObject(_repository.PegarTodosOsCarros());

            return carros != null 
                ? Ok(carros)
                : BadRequest();
        }


        [HttpGet("{id}")]
        public ActionResult PegarCarro(long id)
        {
            var carro = JsonConvert.SerializeObject(_repository.PegarCarro(id));

            return Ok(carro);
        }

        [HttpPost("/inserirCarro")]
        public ActionResult InserirCarro(CarroDto carro)
        {
            _repository.InserirCarro(carro);
            
            return Ok();
        }

        [HttpDelete("/deletarCarro/{id}")]
        public ActionResult DeletarCarro(long id)
        {
            var carroDeletado = _repository.DeletarCarro(id);

            return carroDeletado 
                ? Ok("Carro deletado")
                : BadRequest("Algo de inesperado aconteceu. Por favor, tente novamente.");
        }
    }
}
