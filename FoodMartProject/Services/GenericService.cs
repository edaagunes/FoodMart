using AutoMapper;
using FoodMartProject.Settings;
using MongoDB.Bson;
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
			// TUpdateDto'daki ID alanını bulma
			var idProperty = typeof(TUpdateDto).GetProperties()
											   .FirstOrDefault(p => p.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase));

			if (idProperty != null)
			{
				var idValue = idProperty.GetValue(updateDto)?.ToString();
				if (!string.IsNullOrEmpty(idValue))
				{
					// ObjectId'ye dönüştürme
					var objectId = ObjectId.Parse(idValue);

					// MongoDB'de _id alanı üzerinden güncelleme
					var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
					var entity = _mapper.Map<TEntity>(updateDto);
					await _collection.ReplaceOneAsync(filter, entity);
				}
			}
			else
			{
				throw new ArgumentException("Id alanı bulunamadı.", nameof(updateDto));
			}
		}
		public async Task DeleteAsync(string id)
		{
			if (ObjectId.TryParse(id, out var objectId))
			{
				var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
				await _collection.DeleteOneAsync(filter);
			}
			else
			{
				throw new ArgumentException("Geçersiz ObjectId formatı.", nameof(id));
			}
		}
		public async Task<TGetByIdDto> GetByIdAsync(string id)
		{
			if (ObjectId.TryParse(id, out var objectId))
			{
				// ObjectId ile filtreleme
				var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
				var entity = await _collection.Find(filter).FirstOrDefaultAsync();
				return _mapper.Map<TGetByIdDto>(entity);
			}
			else
			{
				throw new ArgumentException("Geçersiz ObjectId formatı.", nameof(id));
			}
		}

	}
}