using I_did_those.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.

namespace I_did_those.Models
{
    public class Duty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool Done { get; set; }

        [DefaultValue(false)]
        public bool Canceled { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime Created { get; }

        public DateTime Deadline { get; set; }

        public string? Comments { get; set; }

        private bool Save()
        {
            try
            {
                using (var context = new IDidThoseDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<IDidThoseDbContext>()))
                {
                    var model = context.Duties.FirstOrDefault(m => m.Id == Id);
                    if (model != null)
                    {
                        model.Title = Title;
                        model.Description = Description;
                        model.Deadline = Deadline;
                        model.Comments = Comments;
                        context.Duties.Update(model);
                    }
                    else
                    {
                        model = new Duty
                        {
                            Title = Title,
                            Description = Description,
                            Deadline = Deadline,
                            Comments = Comments
                        };
                        context.Duties.Add(model);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e){
                Console.WriteLine(e);
                return false;
            }
        }

        private bool Finish()
        {
            try
            {
                using (var context = new IDidThoseDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<IDidThoseDbContext>()))
                {
                    var model = context.Duties.FirstOrDefault(m => m.Id == Id);
                    if (model != null)
                    {
                        model.Done = Done;
                        context.Duties.Update(model);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        private bool Cancel()
        {
            try
            {
                using (var context = new IDidThoseDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<IDidThoseDbContext>()))
                {
                    var model = context.Duties.FirstOrDefault(m => m.Id == Id);
                    if (model != null)
                    {
                        model.Canceled = Canceled;
                        context.Duties.Update(model);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}