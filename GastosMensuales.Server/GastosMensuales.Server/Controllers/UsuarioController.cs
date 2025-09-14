using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastosMensuales.BD.Datos;
using GastosMensuales.BD.Datos.Entity;
using GastosMensuales.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GastosMensuales.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorio<Usuario> repositorio;

        public UsuarioController(IRepositorio<Usuario> repositorio)
        {
            this.repositorio = repositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            var usuario = await repositorio.Select();

            if (usuario == null)
            {
                return NotFound("No se encontraron resultados");
            }
            if (usuario.Count == 0)
            {
                return Ok("No existe este resultado por el momento");
            }
            return Ok(usuario);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await repositorio.SelectById(id);
            if (usuario == null)
            {
                return NotFound("No se encontraron resultados");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuario DTO)
        {
            try
            {
                await repositorio.Insert(DTO);
                return Ok(DTO.Id);

            }
            catch (Exception e)
            {

                return BadRequest($"No se pudo insertar el registro{e.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Usuario DTO) 
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado) 
            {
                return BadRequest("No se pudo actualizar el registro");
            }
            return Ok($"El registro con el id: {id}, se ha actualizado correctamente!. ");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var resultado = await repositorio.Delete(id);
            if (!resultado)
            {
                return NotFound("No se pudo eliminar el registro");
            }
            return Ok($"El registro con el id: {id}, se ha eliminado correctamente!. ");
        }
    } 
}
