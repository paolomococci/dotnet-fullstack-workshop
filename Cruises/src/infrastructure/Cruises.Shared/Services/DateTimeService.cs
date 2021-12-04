using System;
using Cruises.Application.Common.Interfaces;

namespace Cruises.Shared.Services
{
  public class DateTimeService
    : IDateTime
  {
    public DateTime NowUtc => DateTime.UtcNow;
  }
}
