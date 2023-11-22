using AutoMapper;
using DataModels;
using WebAPI.Models;

namespace Adapters.Mappers
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<CommentModel, Comment>().ReverseMap();
        }
    }
}
