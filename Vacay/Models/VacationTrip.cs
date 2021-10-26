namespace Vacay.Models
{
  public class VacationTrip : IVacation<int>
  {
    public int VacationId { get; set; }
    public int TripId { get; set; }
    public Trip Trip { get; set; }
    public Vacation Vacation { get; set; }
  }
}