using AutoMapper;
using LmsDDD.Catalogo.Application.ViewModels;
using LmsDDD.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Curso, CursoViewModel>()
                .ForMember(d => d.Hora, o => o.MapFrom(s => s.CargaHoraria.Hora))
                .ForMember(d => d.Minuto, o => o.MapFrom(s => s.CargaHoraria.Minuto));
                
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
