using Library.Models;
using System.Collections.Generic;
namespace Library.Interface;

public interface IRepository<T>
where T : IEntity
{
    void Add(T obj);
    void Remove(T obj);
    bool Update(T obj);
    T? FindById(Guid id);
    List<T> GetAll();

}