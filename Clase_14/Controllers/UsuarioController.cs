using Clase_14.Controllers.PTOS;
using Clase_14.Modelo;
using Clase_14.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Clase_14.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuario();
        }

        [HttpDelete]

        public bool EliminarUsuario([FromBody] int Id)
        {
            return UsuarioHandler.EliminarUsuario(Id);
        }

        [HttpPut]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario
            {
                Nombre = usuario.Nombre,
                Id = usuario.Id
            });
        }
        [HttpPost]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            return UsuarioHandler.CrearUsuario(new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail,
                NombreUsuario = usuario.NombreUsuario
            });
        }
    }
}
