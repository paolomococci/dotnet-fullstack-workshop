using System;

namespace Biking.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime NowUtc { get; }
    }
}
