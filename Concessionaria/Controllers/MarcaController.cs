using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Concessionaria.Controllers
{
    [ApiController]
    [Route("marca/[controller]")]
    public class MarcaController : ControllerBase
    {
        public IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepo)
        {
            _marcaRepository = marcaRepo;
        }

        [HttpGet("/{id}")]
        public ActionResult VerMarca(long id) 
        {
            var marca = JsonConvert.SerializeObject(_marcaRepository.PegarMarca(id));

            return Ok(marca);
        }

        [HttpPost("/inserirMarca")]
        public ActionResult InserirMarca(MarcaDto marca)
        {
            _marcaRepository.InserirMarca(marca);


            return Ok();
        }
    }
}
