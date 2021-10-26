using System.Data;
using System.Linq;
using Dapper;
using Vacay.Models;

namespace Vacay.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _dataBase;
    public ProfilesRepository(IDbConnection database)
    {
      _dataBase = database;
    }
    internal Profile Get(string profileId)
    {
      var sql = @"
    SELECT *
    FROM accounts
    ";
      return _dataBase.Query<Profile>(sql, new { profileId }).FirstOrDefault();
    }
  }
}