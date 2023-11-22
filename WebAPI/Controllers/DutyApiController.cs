using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DutyApiController : ControllerBase
    {
        #region Constructor
        private readonly IDutyRepository _repository;
        private readonly IDutyService _service;

        public DutyApiController(IDutyRepository repository, IDutyService service)
        {
            _repository = repository;
            _service = service;
        }
        #endregion

        [HttpGet]
        public IEnumerable<int> Stats()
        {
            try
            {
                IEnumerable<int> stats = _service.Stats();
                return stats;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<Duty> List(int page = 1, int size = 10, DutyState state = DutyState.None)
        {
            try
            {
                var list = _service.List(page, size, state);
                return list;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public Duty Get(int id)
        {
            try
            {
                Duty duty = _service.Get(id);
                return duty;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Create(Duty duty)
        {
            try
            {
                int id = _repository.Create(duty);
                return new JsonResult(StatusCode(200), new { Id = id });
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(400), new { Exception = ex });
            }
        }

        [HttpPut]
        public JsonResult Update(Duty duty)
        {
            if (_repository.Update(duty))
                return new JsonResult(StatusCode(200));
            return new JsonResult(StatusCode(400));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            if (_repository.Delete(id))
                return new JsonResult(StatusCode(200));
            return new JsonResult(StatusCode(400));
        }

        [HttpPut]
        public JsonResult Cancel(int id)
        {
            if (_repository.Cancel(id))
                return new JsonResult(StatusCode(200));
            return new JsonResult(StatusCode(400));
        }
    }
}