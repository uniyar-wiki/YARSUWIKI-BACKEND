using YARSUWIKI.DOMAIN.Entity;

namespace YARSUWIKI.DAL.Interfaces;

public interface IBaseReository<T>
{
    
    Task<bool> Create(T entity);

    Task<Author> Get(int id);

    Task<List<Author>> Select();

    bool Delete(T entity);

}