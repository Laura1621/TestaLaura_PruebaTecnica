using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_laura.Dtos;
using prueba_tecnica_laura.Servicios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prueba_tecnica_laura.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosControlador : ControllerBase
    {
        private readonly IProductoServicio _productoService;

        public ProductosControlador(IProductoServicio productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetAllProductos()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return Ok(productos);
        }

        [HttpGet("actualizar_por_id")]
        public async Task<ActionResult<ProductoDTO>> GetProductoById(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost("crear_producto")]
        public async Task<ActionResult<ProductoDTO>> CreateProducto(ProductoDTO producto)
        {
            try
            {
                var nuevoProducto = await _productoService.CreateProductoAsync(producto);
                return CreatedAtAction(nameof(GetProductoById), new { id = nuevoProducto.Id }, nuevoProducto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("actualizar_por_id")]
        public async Task<IActionResult> UpdateProducto(int id, ProductoDTO producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }
            try
            {
                await _productoService.UpdateProductoAsync(id, producto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); 
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                await _productoService.DeleteProductoAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}