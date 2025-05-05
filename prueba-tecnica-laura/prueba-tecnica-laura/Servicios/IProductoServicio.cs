using prueba_tecnica_laura.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prueba_tecnica_laura.Servicios
{
    public interface IProductoServicio
    {
        Task<IEnumerable<ProductoDTO>> GetAllProductosAsync();
        Task<ProductoDTO> GetProductoByIdAsync(int id);
        Task<ProductoDTO> CreateProductoAsync(ProductoDTO producto);
        Task UpdateProductoAsync(int id, ProductoDTO producto);
        Task DeleteProductoAsync(int id);
    }
}