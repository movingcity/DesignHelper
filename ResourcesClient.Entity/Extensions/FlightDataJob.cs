using System.Collections.ObjectModel;
using com.unisys.rms.domain.reference;

///<p>Entities related to application batch jobs</p>
namespace com.unisys.rms.domain.system.batch
{
    ///<p>Represents a scheduler job that moves the constantly building volume of flight data between different data areas within RMS on an incremental basis as manageable chunks</p>
    public partial class FlightDataJob : SchedulerJob
    {
        public ObservableCollection<Airline> Airlines
        {
            get
            {
                return airlines;
            }
            set
            {
                SetField(ref airlines, value, () => Airlines);
            }
        }
    }
}



