namespace Cruises.Application.CruiseLists.Queries.ExportCruises
{
  public class ExportCruisesVm
  {
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] Content { get; set; }
  }
}
