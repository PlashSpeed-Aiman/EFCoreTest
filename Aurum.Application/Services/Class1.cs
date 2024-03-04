using Aurum.Data.Context;
using Aurum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aurum.Application.Services;

public class PondanService
{
    public readonly ApplicationDbContext _dbContext;
    
    public PondanService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Pondan>> GetPondans(int page,int pagesize)
    {
        var res = _dbContext.Pondans.Skip((page * pagesize)).Take(pagesize);
        var query = res.Where(p => p.Name == "");
        return await query.ToListAsync() ?? Enumerable.Empty<Pondan>();

    }
    
    public async Task<Pondan> GetPondan(Guid id)
    {
        return await _dbContext.Pondans.FirstOrDefaultAsync(p => p.Id == id);
    }
    
    
    
    
}