using System;
using Biking.Application.Common.Interfaces;

namespace Biking.Shared.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
