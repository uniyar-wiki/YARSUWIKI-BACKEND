using Microsoft.EntityFrameworkCore;
using YARSUWIKI.DAL.Interfaces;
using YARSUWIKI.DOMAIN.Entity;

namespace YARSUWIKI.DAL.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _db;

    public AuthorRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool Create(Author entity)
    {
        throw new NotImplementedException();
    }

    public Author Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Author>> Select()
    {
        return _db.Author.ToListAsync();
    }

    public bool Delete(Author entity)
    {
        throw new NotImplementedException();
    }

    public Author GetByName(string name)
    {
        throw new NotImplementedException();
    }
}