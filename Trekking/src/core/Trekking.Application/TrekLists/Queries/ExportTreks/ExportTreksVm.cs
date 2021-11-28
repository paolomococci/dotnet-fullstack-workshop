namespace Trekking.Application.TrekLists.Queries.ExportTreks
{
    public class ExportTreksVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
