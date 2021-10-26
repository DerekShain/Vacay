using System;
using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _profilesRepository;
    public ProfilesService(ProfilesRepository profilesRepository)
    {
      _profilesRepository = profilesRepository;
    }
    internal Profile Get(string profileId)
    {
      Profile profile = _profilesRepository.Get(profileId);
      if (profile == null)
      {
        throw new Exception("Somethings Wrong");
      }
      return profile;
    }
  }
}