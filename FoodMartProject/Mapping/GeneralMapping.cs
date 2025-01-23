using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.DiscountDtos;
using FoodMartProject.Dtos.FeatureDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			CreateMap<Product, ResultProductDto>()/*.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))*/.ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, GetByIdProductDto>().ReverseMap();

			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
			CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

			CreateMap<Selling, ResultSellingDto>().ReverseMap();
			CreateMap<Selling, CreateSellingDto>().ReverseMap();
			CreateMap<Selling, UpdateSellingDto>().ReverseMap();
			CreateMap<Selling, GetByIdSellingDto>().ReverseMap();

			CreateMap<Discount, ResultDiscountDto>().ReverseMap();
			CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
			CreateMap<Discount, CreateDiscountDto>().ReverseMap();
			CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();
		}
	}
}
