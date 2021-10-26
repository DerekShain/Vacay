using System;
using System.Collections.Generic;
using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{
  public class TripsService
  {
    private readonly TripsRepository _tripsRepository;
    public TripsService(TripsRepository tripsRepository)
    {
      _tripsRepository = tripsRepository;
    }
    public List<Trip> GetVacationTrip(int vacationId)
    {
      return _tripsRepository.GetByVacationId(vacationId);
    }
    public Trip Post(Trip tripData)
    {
      return _tripsRepository.Create(tripData);
    }
    public Trip Edit(int tripId, Trip tripData)
    {
      Trip trip = GetById(tripId);
      if (trip.CreatorId != trip.CreatorId)
      {
        throw new System.Exception("Not Allowed");
      }
      trip.Price = tripData.Price;
      trip.Destination = tripData.Destination ?? trip.Destination;
      return _tripsRepository.Edit(tripId, tripData);
    }

    private Trip GetById(int tripId)
    {
      Trip trip = _tripsRepository.Get(tripId);
      if (trip == null)
      {
        throw new Exception("Cant Find");
      }
      return trip;
    }
    public void Delete(int tripId, string userId)
    {
      Trip trip = GetById(tripId);
      if (trip.CreatorId != userId)
      {
        throw new Exception("not allowed");
      }
      _tripsRepository.Delete(tripId);
    }
  }
}