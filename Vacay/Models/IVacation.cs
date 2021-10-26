using System;

namespace Vacay.Models
{
  public abstract class IVacation<V>
  {
    public V Id { get; set; }
    public float Price { get; set; }
    public string Destination { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public Profile Profile { get; set; }
  }
}