using System;
using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{
  public class VacationsService
  {
    private readonly VacationsRepository _vacationsRepository;
    private readonly ProfilesService _profilesService;
    // private readonly VacationsTripsService _vacationsTripsService;
    public VacationsService(VacationsRepository vacationsRepository, ProfilesService profilesService)
    {
      _vacationsRepository = vacationsRepository;
      _profilesService = profilesService;
      // _vacationsTripsService = vacationsTripsService;
    }

    public object GetAll()
    {
      return _vacationsRepository.Get();
    }

    public object GetById(int vacationId)
    {
      Vacation vacation = _vacationsRepository.Get(vacationId);
      if (vacation == null)
      {
        throw new Exception("Can't Find");
      }
      return vacation;
    }

    public Vacation Edit(int vacationId, Vacation vacationData)
    {
      throw new NotImplementedException();
    }

    public void Delete(int vacationId, object id)
    {
      throw new NotImplementedException();
    }
  }
}