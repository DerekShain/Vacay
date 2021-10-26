using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacay.Models;
using Vacay.Services;

namespace Vacay.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VacationsController : ControllerBase
  {
    private readonly VacationsService _vacationsService;
    private readonly TripsService _tripsService;

    public VacationsController()
    {
    }

    public VacationsController(VacationsService vacationsService, TripsService tripsService)
    {
      _vacationsService = vacationsService;
      _tripsService = tripsService;
    }

    [HttpGet]
    public ActionResult<List<Vacation>> GetVacation()
    {
      try
      {
        var vacations = _vacationsService.GetAll();
        return Ok(vacations);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vacationId}")]
    public ActionResult<Vacation> GetVacationById(int vacationId)
    {
      try
      {
        var vacation = _vacationsService.GetById(vacationId);
        return Ok(vacation);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{vacationId}/trips")]
    public ActionResult<List<Trip>> GetVacationTrip(int vacationId)
    {
      try
      {
        var trips = _tripsService.GetVacationTrip(vacationId);
        return Ok(trips);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{vacationId}")]
    [Authorize]
    public async Task<ActionResult<Vacation>> Edit(int vacationId, [FromBody] Vacation vacationData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vacationData.CreatorId = userInfo.Id;
        Vacation vacation = _vacationsService.Edit(vacationId, vacationData);
        return Ok(vacation);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{vacationId}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int vacationId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vacationsService.Delete(vacationId, userInfo.Id);
        return Ok("Deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}