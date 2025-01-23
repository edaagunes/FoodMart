using AutoMapper;
using FoodMartProject.Settings;
using MongoDB.Driver;

namespace FoodMartProject.Services
{
	public class GenericService<TEntity, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto>
		: BaseMongoService<TEntity>, IGenericService<TEntity, TCreateDto, TUpdateDto, TGetByIdDto, TResultDto>
		where TEntity : class
	{
		private readonly IMapper _mapper;

		public GenericService(IMapper mapper, IDatabaseSettings databaseSettings, string collectionName)
			: base(databaseSettings, collectionName)
		{
			_mapper = mapper;
		}

		public async Task<List<TResultDto>> GetAllAsync()
		{
			var entities = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<TResultDto>>(entities);
		}

		public async Task CreateAsync(TCreateDto createDto)
		{
			var entity = _mapper.Map<TEntity>(createDto);
			await _collection.InsertOneAsync(entity);
		}

		public async Task UpdateAsync(TUpdateDto updateDto)
		{
			var entity = _mapper.Map<TEntity>(updateDto);

			// TUpdateDto'daki ID alanını bulma (ör. ProductId gibi özelleştirilmiş adlandırmalar)
			var idProperty = typeof(TUpdateDto).GetProperties()
											   .FirstOrDefault(p => p.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase));

			if (idProperty != null)
			{
				var idValue = idProperty.GetValue(updateDto)?.ToString();
				if (!string.IsNullOrEmpty(idValue))
				{
					// MongoDB'de _id alanını kullanarak güncelleme
					var filter = Builders<TEntity>.Filter.Eq("_id", idValue);
					await _collection.ReplaceOneAsync(filter, entity);
				}
				else
				{
					throw new ArgumentException("ID değeri boş olamaz.");
				}
			}
			else
			{
				throw new ArgumentException("ID alanı bulunamadı.");
			}
		}


		public async Task DeleteAsync(string id)
		{
			await _collection.DeleteOneAsync(x => x.Equals(id));
		}

		public async Task<TGetByIdDto> GetByIdAsync(string id)
		{
			var entity = await _collection.Find(x => x.Equals(id)).FirstOrDefaultAsync();
			return _mapper.Map<TGetByIdDto>(entity);
		}
	}
}