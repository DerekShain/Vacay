using System.Data;

namespace Vacay.Repositories
{
  internal class DbContext
  {
    protected readonly IDbConnection _db;
    public DbContext(IDbConnection db)
    {
      _db = db;
    }
  }
}