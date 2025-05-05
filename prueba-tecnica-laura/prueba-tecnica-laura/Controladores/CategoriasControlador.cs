using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_laura.Modelos;
using prueba_tecnica_laura.Servicios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace prueba_tecnica_laura.Controladores
{
    [ApiController]
    [Route("api/categorias/controlador")]
    public class CategoriasControlador : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaService;

        public CategoriasControlador(ICategoriaServicio categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("traer_todos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAllCategorias()
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync();
            return Ok(categorias);
        }

        [HttpGet("traer_por_id")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost("crear")]
        public async Task<ActionResult<Categoria>> CreateCategoria(Categoria categoria)
        {
            await _categoriaService.CreateCategoriaAsync(categoria);
            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("actualizar_por_id")]
        public async Task<IActionResult> UpdateCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }
            try
            {
                await _categoriaService.UpdateCategoriaAsync(categoria);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _categoriaService.GetCategoriaByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                await _categoriaService.DeleteCategoriaAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception)
            {
                if (await _categoriaService.GetCategoriaByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}