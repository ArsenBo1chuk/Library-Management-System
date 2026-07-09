using System;
using System.Collections.Generic;
using Library.Interface;
namespace Library.Repositories;

public class Repositories<T> : IRepository<T>
where T : IEntity
{
    private List<T> collection = new();
    public void Add(T obj)
    {
        collection.Add(obj);
    } 

    public void Remove(T obj)
    {
        collection.Remove(obj);
    }

    public bool Update(T obj)
    {
        foreach(var item in collection)
        {
            if(item.Id == obj.Id)
            {
                collection[collection.IndexOf(item)] = obj;
                return true;
            }
        }
        return false;
    }

    public T? FindById(Guid id)
    {
        foreach(var item in collection)
        {
            if(item.Id == id)
            {
                return item;
            }
        }
        return default;
    }

    public List<T> GetAll()
    {
        return new List<T>(collection);
    }
} 