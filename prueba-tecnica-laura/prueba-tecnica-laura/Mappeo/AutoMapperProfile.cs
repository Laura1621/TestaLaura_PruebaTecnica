using AutoMapper;
using prueba_tecnica_laura.Modelos;
using prueba_tecnica_laura.Dtos;

namespace prueba_tecnica_laura.Mappeo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}