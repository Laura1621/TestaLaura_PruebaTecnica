using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica_laura.Dtos
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio!")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio tiene que ser mayor a cero.")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock nunca puede  ser negativo.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria!")]
        public int CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }
    }
}