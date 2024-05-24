using Indigo.Core.Models;
using Indigo.Core.Models.RepositoryAbstarcts;
using Indigo.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo.Data.RepositoryConcretes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
   private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<T> AddIdentityAsync(T entity)
    {
       await _context.Set<T>().AddAsync(entity);   
        return entity;
    }

    public void DeleteEntity(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
     
    public T GetEntity(Func<T, bool>? func = null)
    {
        return func == null?

        _context.Set<T>().FirstOrDefault():
            _context.Set<T>().FirstOrDefault(func);
    }

    public List<T> GetAllEntities(Func<T, bool>? func = null)
    {
        return func == null? 
        _context.Set<T>().ToList():
            _context.Set<T>().Where(func).ToList();




    }

    public int commit()
    {
       return _context.SaveChanges();
    }

    public async Task<int> CommitAsync()
    {
       return await _context.SaveChangesAsync();
    }
}
