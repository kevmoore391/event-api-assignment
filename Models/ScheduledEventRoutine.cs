using FluentScheduler;
using EventApiAssignment.Models;
namespace EventApiAssignment.Services
{
    public class ScheduledEventRoutine : Registry
    {
        public ScheduledEventRoutine()
        {
            Schedule<EventRoutineJob>()
                .NonReentrant() // Only one instance of the job can run at a time
                .ToRunOnceAt(DateTime.Now.AddSeconds(3))    // Delay startup for a while
                .AndEvery(60).Seconds();     // Interval
        }
        

    }
}
