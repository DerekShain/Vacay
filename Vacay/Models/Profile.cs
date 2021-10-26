namespace Vacay.Models
{
  public class Profile : IVacation<string>
  {
    public string Name { get; set; }
    public string Picture { get; set; }
  }
}