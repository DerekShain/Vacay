using Microsoft.AspNetCore.Mvc;
using Vacay.Models;
using Vacay.Services;

namespace Vacay.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _profilesService;
    private readonly TripsService _tripsService;
    private readonly VacationsService _vacationsService;

    public ProfilesController(VacationsService vacationsService, TripsService tripsService, ProfilesService profilesService)
    {
      _vacationsService = vacationsService;
      _tripsService = tripsService;
      _profilesService = profilesService;
    }
    [HttpGet("{profileId}")]
    public ActionResult<Profile> Get(string profileId)
    {
      try
      {
        Profile profile = _profilesService.Get(profileId);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}