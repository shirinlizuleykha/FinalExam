﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo.Core.Models.RepositoryAbstarcts;

public interface IGenericRepository<T> where T : BaseEntity, new()
{

     Task<T> AddIdentityAsync(T entity);

      void DeleteEntity(T entity);

    T GetEntity(Func<T ,bool>? func = null);
    List<T> GetAllEntities(Func<T, bool>? func = null);
    int commit();
    Task<int> CommitAsync();

}
