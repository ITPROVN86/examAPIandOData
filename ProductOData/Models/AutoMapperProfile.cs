using AutoMapper;
using BusinessObjects;
using ShopDTO;

namespace ProductOData.Models
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName, o => o.MapFrom(src => src.Category.CategoryName));
            CreateMap<Category, CategoryDTO>();
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
