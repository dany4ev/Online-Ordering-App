using AutoMapper;
using OrderingApp.Models;

namespace OrderingApp.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<User, UserVM>().ReverseMap();
                config.CreateMap<Product, ProductVM>().ReverseMap();
                config.CreateMap<Category, CategoryVM>().ReverseMap();
                config.CreateMap<Order, OrderVM>().ReverseMap();
            });
        }
    }
}