using YARSUWIKI.DOMAIN.Entity;

namespace YARSUWIKI.DAL.Interfaces;

public interface IBaseReository<T>
{
    
    bool Create(T entity);

    T Get(int id);

    Task<List<Author>> Select();

    bool Delete(T entity);

}