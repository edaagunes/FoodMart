using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.FeatureDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Services
{
	public interface IFeatureService : IGenericService<Feature, CreateFeatureDto, UpdateFeatureDto, GetByIdFeatureDto, ResultFeatureDto>
	{
	}
}
