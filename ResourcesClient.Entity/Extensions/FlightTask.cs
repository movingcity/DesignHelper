using System.Collections.ObjectModel;
using com.unisys.rms.domain.flight;

///<p>Task related entities</p>
namespace com.unisys.rms.domain.task
{
    ///<p>Task that is associated with one or more flights. These tasks are generated based on flight schedule.</p>
    public abstract partial class FlightTask : Task
    {
        ///<p>Returns the Flights associated with this Flight Task</p>
        public abstract ObservableCollection<Flight> Flights
        {
            get;
            set;
        }
    }
}



