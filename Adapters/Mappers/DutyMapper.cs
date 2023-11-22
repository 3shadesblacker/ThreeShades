using AutoMapper;
using DataModels;
using WebAPI.Models;

namespace Adapters.Mappers
{
    public class DutyMapper : Profile
    {
        public DutyMapper()
        {
            CreateMap<Duty, DutyModel>().ReverseMap();
            CreateMap<DutyState, DutyStateModel>().ConvertUsing<DutyStateMapper>();
            CreateMap<DutyStateModel, DutyState>().ConvertUsing<DutyStateMapper>();
        }
    }
}
