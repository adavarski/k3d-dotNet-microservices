using AutoMapper;
using CommandsService.Models;
using Grpc.Net.Client;
using PaltformService;

namespace CommandsService.SyncDataServices.Grpc
{
    public class PlatformDataClient : IPlatformDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PlatformDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<Platform> ReturnAllPlatforms()
        {
            var endPoint = _configuration["GrpcPlatform"];

            Console.WriteLine($"---> Calling GRPC Service {endPoint}");

            GrpcChannel channel = GrpcChannel.ForAddress(endPoint);

            var client = new GrpcPlatform.GrpcPlatformClient(channel);

            var request = new GetAllRequest();

            try
            {
                var reply = client.GetAllPlatforms(request);

                var mappedReply = _mapper.Map<IEnumerable<Platform>>(reply.Platform);

                return mappedReply;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> An error ocurred getting the Platforms by GRPC {ex.Message}");

                throw;
            }
        }
    }
}
