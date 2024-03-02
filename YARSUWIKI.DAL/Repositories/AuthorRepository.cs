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

    public async Task<bool> Create(Author entity)
    {
        await _db.Author.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Author> Get(int id)
    {
        return await _db.Author.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Author>> Select()
    {
        return _db.Author.ToListAsync();
    }

    public bool Delete(Author entity)
    {
        _db.Author.Remove(entity);
        _db.SaveChangesAsync();
        return true;
    }

    public async Task<Author> GetByName(string name)
    {
        return await _db.Author.FirstOrDefaultAsync(x => x.Name == name);
    }
}