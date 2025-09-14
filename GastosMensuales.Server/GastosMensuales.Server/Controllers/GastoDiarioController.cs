using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastosMensuales.BD.Datos;
using GastosMensuales.BD.Datos.Entity;
using GastosMensuales.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GastosMensuales.Server.Controllers
{
    [ApiController]
    [Route("api/GastoDiario")]
    public class GastoDiarioController : ControllerBase
    {
        private readonly IRepositorio<GastoDiario> repositorio;

        public GastoDiarioController(IRepositorio<GastoDiario> repositorio)
        {
            this.repositorio = repositorio;
        }
        [HttpGet] 
        public async Task<ActionResult<List<GastoDiario>>> GetGastosDiarios()
        {
            var gastoDiario = await repositorio.Select();
            if (gastoDiario == null)
            {
                return NotFound("No se encontraron resultados");
            }
            if (gastoDiario.Count == 0)
            {
                return Ok("No existe este resultado por el momento");
            }
            return Ok(gastoDiario);
        }
        // Caso de uso ELEGIDO
        [HttpPost] 
        public async Task<ActionResult<int>> Post(GastoDiario DTO)
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
        public async Task<ActionResult> Put(int id, GastoDiario DTO)
        {
            try
            {
                var resultado = await repositorio.Update(id, DTO);
                if (!resultado)
                {
                    return NotFound($"No se encontro el registro con id {id}");
                }
                return Ok("El registro se actualizo correctamente");
            }
            catch (Exception e)
            {
                return BadRequest($"No se pudo actualizar el registro {e.Message}");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var resultado = await repositorio.Delete(id);
                if (!resultado)
                {
                    return NotFound($"No se encontro el registro con id {id}");
                }
                return Ok("El registro se elimino correctamente");
            }
            catch (Exception e)
            {
                return BadRequest($"No se pudo eliminar el registro {e.Message}");
            }
        }
    }
}
