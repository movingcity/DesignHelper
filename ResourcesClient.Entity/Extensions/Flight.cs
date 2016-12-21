using System.Collections.ObjectModel;
using com.unisys.rms.domain.task;

///<p>Flight related entities</p>
namespace com.unisys.rms.domain.flight
{
    ///<p>The flight record.</p>
    public partial class Flight : RMSEntity
    {
        public ObservableCollection<Route> Routes
        {
            get
            {
                return routes;
            }
            set
            {
                SetField(ref routes, value, () => Routes);
            }
        }

        public ObservableCollection<StandTask> StandTask
        {
            get
            {
                return standTask;
            }
            set
            {
                SetField(ref standTask, value, () => StandTask);
            }
        }

        public ObservableCollection<GateTask> GateTask
        {
            get
            {
                return gateTask;
            }
            set
            {
                SetField(ref gateTask, value, () => GateTask);
            }
        }

        public ObservableCollection<CounterTask> CounterTask
        {
            get
            {
                return counterTask;
            }
            set
            {
                SetField(ref counterTask, value, () => CounterTask);
            }
        }

        public ObservableCollection<CarouselTask> CarouselTask
        {
            get
            {
                return carouselTask;
            }
            set
            {
                SetField(ref carouselTask, value, () => CarouselTask);
            }
        }

        public ObservableCollection<Flight> ChildFlights
        {
            get
            {
                return childFlights;
            }
            set
            {
                SetField(ref childFlights, value, () => ChildFlights);
            }
        }
    }
}



