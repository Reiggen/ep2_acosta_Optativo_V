using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Repository.Data;
using Services.Logica;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.personas.Controllers
{

    public class FacturaController : Controller
    {
        private FacturaService facturaService;

        public FacturaController(Repository.Context.ContextoAplicacionDB context)
        {
            facturaService = new FacturaService(context);
        }

        [HttpGet("Listar Facturas")]
        public async Task<ActionResult> ListarAsync()
        {
            try
            {
                var facturas = await facturaService.ListarAsync();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Consultar Factura/{id}")]
        public async Task<ActionResult> ConsultarAsync(int id)
        {
            var factura = await facturaService.ConsultarAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        [HttpPost("Agregar Factura")]
        public async Task<ActionResult> AgregarAsync(FacturaModel factura)
        {
            await facturaService.AgregarAsync(factura);
            return View();/*
            if (ModelState.IsValid)
            {
                await facturaService.AgregarAsync(factura);
                return View();
            }
            else
            {
                return BadRequest(ModelState);
            }*/
        }

        [HttpPut("Modificar factura")]
        public async Task<ActionResult> ModificarAsync(int id, FacturaModel factura)
        {
            if (id != factura.id)
            {
                return BadRequest();
            }
            await facturaService.ModificarAsync(factura);
            return NoContent();
        }

        [HttpDelete("Eliminar Factura/{id}")]
        public async Task<ActionResult> EliminarAsync(int id)
        {
            var factura = await facturaService.ConsultarAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            await facturaService.EliminarAsync(id);
            return NoContent();
        }
    }
}

