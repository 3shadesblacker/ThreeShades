using AutoMapper;
using DataModels;
using WebAPI.Models;

namespace Adapters.Mappers
{
    public class DutyStateMapper : ITypeConverter<DutyState, DutyStateModel>, ITypeConverter<DutyStateModel, DutyState>
    {
        public DutyStateModel Convert(DutyState source, DutyStateModel destination, ResolutionContext context)
        {
            var model = new DutyStateModel
            {
                Id = (byte)source
            };
            return model;
        }

        public DutyState Convert(DutyStateModel source, DutyState destination, ResolutionContext context)
        {
            return (DutyState)source.Id;
        }
    }
}
