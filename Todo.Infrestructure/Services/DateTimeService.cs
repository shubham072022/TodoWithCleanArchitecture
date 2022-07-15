using Todo.Application.Common.Interfaces;

namespace Todo.Infrestructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
