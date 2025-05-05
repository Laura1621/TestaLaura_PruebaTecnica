using FluentValidation;
using prueba_tecnica_laura.Dtos;

namespace prueba_tecnica_laura.Validaciones
{
    public class CategoriaValidacion : AbstractValidator<CategoriaDTO>
    {
        public CategoriaValidacion()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
                .Length(1, 100).WithMessage("El nombre de la categoría debe tener entre 1 y 100 caracteres.");
        }
    }
}