using TailorStore.Application.Common.Interfaces;
using System;

namespace TailorStore.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
