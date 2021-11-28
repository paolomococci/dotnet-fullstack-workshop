using System;
using Trekking.Application.Common.Interfaces;

namespace Trekking.Shared.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
