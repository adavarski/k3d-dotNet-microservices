using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platformItems = _repository.GetAllPlatforms();

            var platforms = _mapper.Map<IEnumerable<PlatformReadDto>>(platformItems);

            return Ok(platforms);
        }

        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("---> Inbound Post # Command Service");

            return Ok("Inbound test of from platforms controller");
        }
    }
}
