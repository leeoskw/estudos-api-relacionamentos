﻿namespace estudos_api_relacionamentos.Data.Repositories
{
    public interface IRepositoryGenerico<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
