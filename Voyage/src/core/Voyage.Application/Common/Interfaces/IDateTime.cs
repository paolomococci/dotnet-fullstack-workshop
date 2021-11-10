using System;

namespace Voyage.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime NowUtc { get; }
    }
}
