using Cruises.Domain.Enums;

namespace Cruises.Domain.Entities
{
  public class CruisePackage
  {
    public int Id { get; set; }
    public int ListId { get; set; }
    public string Name { get; set; }
    public string Hope { get; set; }
    public string MapLocation { get; set; }
    public float Price { get; set; }
    public int Duration { get; set; }
    public bool Confirmation { get; set; }
    public Currency Currency { get; set; }
    public CruiseList CruiseList { get; set; }
  }
}
