using YARSUWIKI.DOMAIN.Entity;

namespace YARSUWIKI.DAL.Interfaces;

public interface IAuthorRepository : IBaseReository<Author>
{
    Task<Author> GetByName(string name);
}