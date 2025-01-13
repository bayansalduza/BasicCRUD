using BasicCRUD.Infrastructure.Repository;

namespace BasicCRUD.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<T> AddAsync(T entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetPaginatedAsync(int page, int pageSize)
        {
            return await _repository.GetPaginatedAsync(page, pageSize);
        }

    }
}
