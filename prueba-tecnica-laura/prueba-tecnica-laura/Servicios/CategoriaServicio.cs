using Microsoft.EntityFrameworkCore;
using prueba_tecnica_laura.Data;
using prueba_tecnica_laura.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_laura.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly ApplicationDbContext _context;

        public CategoriaServicio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                if (_context.Productos.Any(p => p.CategoriaId == id))
                {
                    throw new InvalidOperationException("No se puede eliminar la categoría porque tiene productos asociados a ella.");
                }

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}