using prueba_tecnica_laura.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prueba_tecnica_laura.Servicios
{
    public interface ICategoriaServicio
    {
        Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(int id);
        Task<Categoria> CreateCategoriaAsync(Categoria categoria);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(int id);
    }
}