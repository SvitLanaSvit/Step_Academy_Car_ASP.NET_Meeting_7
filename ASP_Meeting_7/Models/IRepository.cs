﻿namespace ASP_Meeting_7.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Add(T entity);

        T? Get(int id);

        T Edit(T entity);

        bool Delete(int id);
    }
}
