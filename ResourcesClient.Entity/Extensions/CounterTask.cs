using System;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.flight;

///<p>Task related entities</p>
namespace com.unisys.rms.domain.task
{
    ///<p>A Flight Task that is allocated to Checkin Counter resources</p>
    public partial class CounterTask : FlightTask
    {
        [NonSerialized]
        private ObservableCollection<Flight> flights = null;

        public override ObservableCollection<Flight> Flights
        {
            get
            {
                // counter task only has one flight
                if (flights == null)
                {
                    flights = new ObservableCollection<Flight>();
                    flights.Add(flight);
                }
                return flights;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}



