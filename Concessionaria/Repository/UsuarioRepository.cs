using AutoMapper;
using Concessionaria.Contexts;
using Concessionaria.Models;
using Concessionaria.Models.DTOs;
using Concessionaria.Repository.Interfaces;

namespace Concessionaria.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConcessionariaContext _context;
        private readonly IMapper _usuarioMapper;

        public UsuarioRepository(ConcessionariaContext context, IMapper mapper)
        {
            _context = context;
            _usuarioMapper = mapper;
        }

        public Usuario VerUsuario(long id)
        {
            try
            {
                return _context.Usuarios.FirstOrDefault(p => p.Id == id);

            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public bool Cadastrar(UsuarioCadastroDto usuarioCadastroDto)
        {
            try
            {
           
                bool usuarioJaExiste = _context.Usuarios.Where(p => 
                    (p.Email == usuarioCadastroDto.Email) || 
                    ((p.CPF != null) &&  p.CPF == usuarioCadastroDto.CPF))
                    .Any();

                var usuario = _usuarioMapper.Map<Usuario>(usuarioCadastroDto);

                if(!usuarioJaExiste)
                {
                    _context.Usuarios.Add(_usuarioMapper.Map<Usuario>(usuarioCadastroDto));

                    _context.SaveChanges();
                }

            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }


            return true;
        }

        public bool ModificarDadosUsuario(long id,Usuario usuario)
        {
            try
            {
                    _context.Usuarios.Update(usuario);

                    _context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return true;
        }

        public bool DeletarUsuario(long id)
        {
            var usuario = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuario);

            _context.SaveChanges();

            return true;
        }

        public void Save() 
        {
            _context.SaveChanges();
        }


    }
}
