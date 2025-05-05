using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica_laura.Dtos
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es totalmente obligatorio!!")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }
    }
}