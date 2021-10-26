using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Vacay.Interfaces;
using Vacay.Models;

namespace Vacay.Repositories
{
  internal class TripsRepository : DbContext, IRepository<Trip>
  {
    public TripsRepository(IDbConnection db) : base(db)
    {
    }

    public Trip Create(Trip data)
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

    internal List<Trip> GetByVacationId(int vacationId)
    {
      string sql = @"
      SELECT *
      JOIN trips t 
      WHERE t.creatorId = @vacationId
      ";
      return _db.Query<Trip>(sql, new { vacationId }).ToList();
    }

    public void Delete(int id)
    {
      var sql = @"
      DELETE
      FROM trips
      WHERE id = @tripId LIMIT 1
      ";
      var affected = _db.Execute(sql, new { id });
      if (affected > 1)
      {
        throw new System.Exception("error");
      }
      if (affected == 0)
      {
        throw new System.Exception("error");
      }
    }

    public Trip Edit(int id, Trip data)
    {
      data.Id = id;
      string sql = @"
      UPDATE trips
      SET
      price = @Price,
      destination = @Destination
      WHERE id = @Id
      ";
      var affected = _db.Execute(sql, data);
      if (affected > 1)
      {
        throw new System.Exception("error");
      }
      if (affected == 0)
      {
        throw new System.Exception("error");
      }
      return data;
    }

    public List<Trip> Get()
    {
      string sql = @"
      SELECT *
      FROM trips
      ";
      return _db.Query<Trip>(sql).ToList();
    }

    public Trip Get(int id)
    {
      var sql = @"
      SELECT *
      FROM trips
      WHERE id = @id
      ";
      return _db.Query<Trip>(sql, new { id }).FirstOrDefault();
    }
  }
}