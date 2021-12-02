using System;

namespace Cruises.Application.Common.Interfaces
{
  public interface IDateTime
  {
    DateTime NowUtc { get; }
  }
}
