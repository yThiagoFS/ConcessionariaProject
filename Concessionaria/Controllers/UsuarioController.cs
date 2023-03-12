using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.Controllers
{
    [ApiController]
    [Route("usuario/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/usuario/{id}")]
        public ActionResult PegarUsuario(long id)
        {
            var usuario = _repository.VerUsuario(id);

            return usuario != null 
                ? Ok(usuario)
                : BadRequest("Usuario não encontrado");
        }

        [HttpPost("/cadastrar")]
        public ActionResult CadastrarUsuario(UsuarioCadastroDto usuarioDto)
        {
           bool cadastro = _repository.Cadastrar(usuarioDto);

            return cadastro == true
                ? Ok("Usuario cadastrado com sucesso!")
                : BadRequest();
        }

        [HttpPut("/modificar/{id}")]
        public ActionResult ModificarUsuario(long id, Usuario usuario)
        {

            var modificou = _repository.ModificarDadosUsuario(id, usuario);

            return modificou == true 
                ? Ok(usuario)
                : BadRequest();
        }

        [HttpDelete("/deletarUsuario/{id}")]
        public ActionResult DeletarUsuario(long id)
        {
            var deletar = _repository.DeletarUsuario(id);

            return Ok();
        }

    }
}
