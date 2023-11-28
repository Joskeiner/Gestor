using AutoMapper;
using Gestor.APP.Models.ViewModels;
using Gestor.ENTITY.Models;

namespace Gestor.APP.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Categoria
            CreateMap<Categoria, VMCategoria>()
                .ForMember(d => d.EsActivo,
                                    p => p.MapFrom(o => o.EsActivo == true ? 1 : 0));
            CreateMap<VMCategoria, Categoria>()
                .ForMember(d => d.EsActivo,
                                    p => p.MapFrom(o => o.EsActivo == 1 ? true : false));

            #endregion

        }
    }
}
