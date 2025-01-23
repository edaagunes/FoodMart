namespace FoodMartProject.Services
{
	public interface IGenericService<TEntity, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto>
		where TEntity : class
	{
		Task<List<TResultDto>> GetAllAsync();
		Task CreateAsync(TCreateDto createDto);
		Task UpdateAsync(TUpdateDto updateDto);
		Task DeleteAsync(string id);
		Task<TGetByIdDto> GetByIdAsync(string id);
	}
}

