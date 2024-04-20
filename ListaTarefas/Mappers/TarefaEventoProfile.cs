using AutoMapper;
using ListaTarefas.Entities;
using ListaTarefas.Models;

namespace ListaTarefas.Mappers
{
    public class TarefaEventoProfile : Profile
    {
        public TarefaEventoProfile()
        {

            //Mapper para a model de view
            CreateMap<TarefaEvento, TarefaEventoViewModel>();

            //Mapper para a model de input
            CreateMap<TarefaEventoInputModel, TarefaEvento>();
        }
    }
}
