using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbAppContext context;
    //private ;

    public UnitOfWork(DbAppContext _context)
    {
        context = _context;
    }

    /* public  
    {
        get{
            if(== null){
                = new (context);
            }
            return ;
        }
    } */

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}