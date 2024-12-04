using AutoMapper;
using MongoDBTest.DTOs;
using MongoDBTest.Models;

namespace MongoDBTest.Profiles
{
    public class MongoDBProfiles : Profile
    {
        public MongoDBProfiles()
        {
            // Source -> Target
            CreateMap<Product, ProductReadDTO>();
            CreateMap<ProductCreateDTO, Product>();
        }
    }
}
