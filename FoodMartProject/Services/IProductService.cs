using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Services
{
	public interface IProductService : IGenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>
	{
		Task<List<ResultProductDto>> GetAllProductWithCategoryAsync();
		Task<List<ResultSellingDto>> GetMostSellingProductsAsync();
	}
}
