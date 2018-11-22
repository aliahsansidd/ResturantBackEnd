﻿using Recipe.Common.Helper;
using Recipe.Core.Attribute;
using Recipe.Core.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe.Core.Base.Interface
{
    public interface IRepository
    {
    }
    public interface IRepository<TEntity, TKey> : IRepository
    {
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAsync(IList<TKey> ids);
        Task<TEntity> GetEntityOnly(TKey id);
        Task<int> GetCount();
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(JsonApiRequest request);

        [AuditOperation(OperationType.Create)]
        Task<TEntity> Create(TEntity entity);

        [AuditOperation(OperationType.Update)]
        Task<TEntity> Update(TEntity entity);

        [AuditOperation(OperationType.Delete)]
        Task DeleteAsync(TKey id);
    }
}
