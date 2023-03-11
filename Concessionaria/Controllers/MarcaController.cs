using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            var marca = _marcaRepository.PegarMarca(id);

            return Ok(marca);
        }

        [HttpPost("/inserir")]
        public ActionResult InserirMarca(MarcaDto marca)
        {
            _marcaRepository.InserirMarca(marca);


            return Ok();
        }
    }
}
