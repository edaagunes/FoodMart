using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.DiscountDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Services
{
	public interface IDiscountService : IGenericService<Discount, CreateDiscountDto, UpdateDiscountDto, GetByIdDiscountDto, ResultDiscountDto>
	{
	}
}
