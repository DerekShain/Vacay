using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Vacay.Interfaces;
using Vacay.Models;

namespace Vacay.Repositories
{
  internal class VacationsRepository : DbContext, IRepository<Vacation>
  {
    public VacationsRepository(IDbConnection db) : base(db)
    {
    }

    public Vacation Create(Vacation data)
    {
      string sql = @"
      INSERT INTO vacations(
        price,
        destination,
        creatorId
      )
      VALUES(
        @Price,
        @Destination,
        @CreatorId
      );
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Vacation Edit(int id, Vacation data)
    {
      throw new System.NotImplementedException();
    }

    public Vacation Get(int id)
    {
      string sql = @"
      SELECT *
      FROM vacations
      WHERE id = @id
      ";
      return _db.Query<Vacation>(sql, new { id }).FirstOrDefault();
    }

    public List<Vacation> Get()
    {
      string sql = @"
      SELECT *
      FROM vacations
      ";
      return _db.Query<Vacation>(sql).ToList();
    }
  }
}