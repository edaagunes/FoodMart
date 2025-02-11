﻿using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Services
{
	public interface ISellingService : IGenericService<Selling, CreateSellingDto, UpdateSellingDto, GetByIdSellingDto, ResultSellingDto>
	{
		Task<List<ResultSellingDto>> GetAllSellingWithProductNameAsync();
		Task<List<ResultSellingDto>> GetMostSellingProductsAsync();
	}
}
