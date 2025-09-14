using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastosMensuales.BD.Datos;
using GastosMensuales.BD.Datos.Entity;
using GastosMensuales.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;
namespace GastosMensuales.Server.Controllers
{
    [ApiController]
    [Route("api/Ingreso")]
    public class IngresoController : ControllerBase
    {
        private readonly IRepositorio<Ingreso> repositorio;

        public IngresoController(IRepositorio<Ingreso> repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Ingreso DTO)
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
        [HttpGet]
        public async Task<ActionResult<List<Ingreso>>> GetIngresos()
        {
            var ingreso = await repositorio.Select();
            if (ingreso == null)
            {
                return NotFound("No se encontraron resultados");
            }
            if (ingreso.Count == 0)
            {
                return Ok("No existe este resultado por el momento");
            }
            return Ok(ingreso);
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
                return BadRequest($"No se pudo eliminar el registro{e.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Ingreso DTO)
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

    }
}
