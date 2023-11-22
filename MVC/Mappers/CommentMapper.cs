using AutoMapper;
using MVC.Models;
using WebAPI.Models;

namespace MVC.Mappers
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        { 
            CreateMap<CommentViewModel, Comment>().ReverseMap();
        }
    }
}
