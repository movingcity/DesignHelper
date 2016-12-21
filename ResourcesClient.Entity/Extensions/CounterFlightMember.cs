using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;

///<p>Allocation template related entities</p>
namespace com.unisys.rms.domain.template
{
    ///<p>Template flight members for Counter module</p>
    public partial class CounterFlightMember : FlightMember
    {
        public ObservableCollection<Counter> Counters
        {
            get
            {
                return counters;
            }
            set
            {
                SetField(ref counters, value, () => Counters);
            }
        }
    }
}



