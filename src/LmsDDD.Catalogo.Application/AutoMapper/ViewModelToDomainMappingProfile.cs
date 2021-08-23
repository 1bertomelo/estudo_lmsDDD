using AutoMapper;
using LmsDDD.Catalogo.Application.ViewModels;
using LmsDDD.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CursoViewModel, Curso>()
                .ConstructUsing(c =>
                    new Curso(c.Nome, c.Descricao, c.Ativo,
                        c.Valor, c.DataCadastro, c.Imagem,c.CategoriaId,
                          new CargaHoraria(c.Hora, c.Minuto), c.MediaAprovacao));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria( c.Codigo, c.Nome));

            CreateMap<AvaliacaoViewModel, Avaliacao>()
                .ConstructUsing(a =>
                  new Avaliacao(a.Nome, a.Ativo, a.DataCadastro, a.ValorTotal)
            );

            CreateMap<QuestaoViewmodel, Questao>()
                .ConstructUsing(q =>
                new Questao(q.Numero,q.Enunciado,q.Ativo, q.DataCadastro, q.AvaliacaoId)                
             );

            CreateMap<OpcaoViewModel, Opcao>()
                .ConstructUsing(o =>
                new Opcao(o.Numero, o.Descricao, o.Ativo, o.Correta, o.DataCadastro, o.QuestaoId)
              );
        }
    }
}
