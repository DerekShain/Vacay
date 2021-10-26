using System.Collections.Generic;
using System.Data;
using Vacay.Interfaces;
using Vacay.Models;

namespace Vacay.Repositories
{
  internal class VacationsTripRepository : DbContext, IRepository<VacationTrip>
  {
    public VacationsTripRepository(IDbConnection db) : base(db)
    {
    }

    public VacationTrip Create(VacationTrip data)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public VacationTrip Edit(int id, VacationTrip data)
    {
      throw new System.NotImplementedException();
    }


    public VacationTrip Get(int id)
    {
      throw new System.NotImplementedException();
    }

    public List<VacationTrip> Get()
    {
      throw new System.NotImplementedException();
    }
  }
}