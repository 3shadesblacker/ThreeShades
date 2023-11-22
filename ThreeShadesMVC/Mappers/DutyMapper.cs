using ThreeShades.MVC.ViewModels;
using ThreeShades.MVC.Models;

namespace ThreeShades.MVC.Mappers
{
    public class DutyMapper
    {
        public static Duty ToModel(DutyView vm)
        {
            var model = new Duty
            {
                Id  = vm.Id,
                Done = vm.Done,
                Canceled = vm.Canceled,
                Title = vm.Title,
                Description = vm.Description,
                Deadline = vm.Deadline,
                Comments = vm.Comments
            };
            return model;
        }
        
        public static DutyView ToView(Duty model)
        {
            var view = new DutyView(
                id: model.Id,
                done: model.Done,
                canceled: model.Canceled,
                title: model.Title ?? string.Empty,
                description: model.Description ?? string.Empty,
                deadline: model.Deadline,
                comments: model.Comments ?? string.Empty
                );
            return view;
        }
    }
}