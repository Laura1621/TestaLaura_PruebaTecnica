using FluentValidation;
using prueba_tecnica_laura.Dtos;

namespace prueba_tecnica_laura.Validaciones
{
    public class ProductoValidacion : AbstractValidator<ProductoDTO>
    {
        public ProductoValidacion()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre del producto es obligatorio!")
                .Length(1, 100).WithMessage("El nombre del producto debe tener entre 1 y 100 caracteres!");
            RuleFor(x => x.Precio).GreaterThan(0).WithMessage("El precio del producto tiene que ser mayor que cero.");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
            RuleFor(x => x.CategoriaId).NotEmpty().WithMessage("La categoría es obligatoria.");
        }
    }
}