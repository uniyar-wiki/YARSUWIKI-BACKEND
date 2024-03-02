using YARSUWIKI.DOMAIN.Entity;

namespace YARSUWIKI.DAL.Interfaces;

public interface IAuthorRepository : IBaseReository<Author>
{
    Author GetByName(string name);
}