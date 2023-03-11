using Concessionaria.Models;
using Concessionaria.Models.DTOs;

namespace Concessionaria.Repository.Interfaces
{
    public interface IUsuarioRepository
    {

        Usuario VerUsuario(long id);

        bool Cadastrar(UsuarioCadastroDto usuarioCadastroDto);

        bool ModificarDadosUsuario(long id,Usuario usuario);

        bool DeletarUsuario(long id);

        void Save();

    }
}
