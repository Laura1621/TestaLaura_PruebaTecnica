using AutoMapper;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica_laura.Data;
using prueba_tecnica_laura.Modelos;
using prueba_tecnica_laura.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace prueba_tecnica_laura.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductoServicio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDTO>> GetAllProductosAsync()
        {
            var productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();
            return _mapper.Map<List<ProductoDTO>>(productos);
        }

        public async Task<ProductoDTO> GetProductoByIdAsync(int id)
        {
            var producto = await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductoDTO>(producto);
        }

        public async Task<ProductoDTO> CreateProductoAsync(ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);
            
            if (!await _context.Categorias.AnyAsync(c => c.Id == productoDTO.CategoriaId))
            {
                throw new ArgumentException("La categoría especificada no existe.");
            }

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductoDTO>(producto);
        }

        public async Task UpdateProductoAsync(int id, ProductoDTO productoDTO)
        {
            var productoExistente = await _context.Productos.FindAsync(id);
            if (productoExistente == null)
            {
                throw new ArgumentException("El producto especificado no existe.");
            }
            _mapper.Map(productoDTO, productoExistente);
            _context.Entry(productoExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}