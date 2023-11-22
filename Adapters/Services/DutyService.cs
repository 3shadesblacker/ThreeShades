using AutoMapper;
using DBContext;
using WebAPI.Models;
using WebAPI.Services;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Adapters.Services
{
    public class DutyService : IDutyService
    {
        #region Constructor
        private readonly ThreeShadesDBContext _context;
        private readonly IMapper _mapper;

        public DutyService(ThreeShadesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        public Duty Get(int id)
        {
            var model = _context.Duties.AsQueryable().FirstOrDefault(d => d.Key == id);
            return _mapper.Map<Duty>(model);
        }

        public List<Duty> List(int page = 1, int length = 10, DutyState state = DutyState.None)
        {
            try
            {
                var toSkip = (page - 1) * length;
                var models = state switch
                {
                    DutyState.Done => _context.Duties.AsQueryable().Where(d => d.State.Id == (int)DutyState.Done)
                                                     .Skip(toSkip)
                                                     .Take(length)
                                                     .ToList(),

                    DutyState.Canceled => _context.Duties.AsQueryable().Where(d => d.State.Id == (int)DutyState.Canceled)
                                                         .Skip(toSkip)
                                                         .Take(length)
                                                         .ToList(),

                    _ => _context.Duties.AsQueryable().Where(d => d.State.Id == (int)DutyState.None)
                                        .Skip(toSkip)
                                        .Take(page)
                                        .ToList(),
                };
                var duties = _mapper.Map<List<Duty>>(models);
                foreach (var duty in duties)
                {
                    duty.Comments = _mapper.Map<List<Comment>>(_context.Comments.AsQueryable().Where(c => c.DutyKey == duty.Key).ToList());
                }
                return duties;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        public IEnumerable<int> Stats()
        {
            return new List<int>
            {
                _context.Duties.AsQueryable().Count(d => d.State.Id == (int)DutyState.None),
                _context.Duties.AsQueryable().Count(d => d.State.Id == (int)DutyState.Done),
                _context.Duties.AsQueryable().Count(d => d.State.Id == (int)DutyState.Canceled),
            };
        }
    }
}
