using System;
using Voyage.Application.Common.Interfaces;

namespace Voyage.Shared.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
