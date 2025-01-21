using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.DiscountDtos;
using FoodMartProject.Dtos.FeatureDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Mapping
{
	public class GeneralMapping:Profile
	{
		public GeneralMapping()
		{
			CreateMap<Product,ResultProductDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();
			CreateMap<Feature,ResultFeatureDto>().ReverseMap();
			CreateMap<Category,ResultCategoryDto>().ReverseMap();
			CreateMap<Selling,ResultSellingDto>().ReverseMap();
			CreateMap<Discount,ResultDiscountDto>().ReverseMap();
		}
	}
}
