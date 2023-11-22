using AutoMapper;
using MVC.Models;
using WebAPI.Models;

namespace MVC.Mappers
{
    public class DutyMapper : Profile
    {
        public DutyMapper()
        {
            CreateMap<DutyViewModel, Duty>().ReverseMap();
        }
    }
}
