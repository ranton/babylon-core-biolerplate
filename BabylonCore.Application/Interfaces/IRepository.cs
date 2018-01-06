using System;
using System.Collections.Generic;
using System.Text;
using BabylonCore.Domain.Common;

namespace BabylonCore.Application.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(Guid id);
        List<T> GetByFilter(params KeyValuePair<string, string>[] filters);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
