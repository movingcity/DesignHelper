using System;
using System.Collections.ObjectModel;
using System.Linq;
using com.unisys.rms.domain.flight;

///<p>Task related entities</p>
namespace com.unisys.rms.domain.task
{
    ///<p>A Flight Task that is allocated to Stand resources</p>
    public partial class StandTask : FlightTask
    {
        public override ObservableCollection<Flight> Flights
        {
            get
            {
                return flights;
            }
            set
            {
                SetField(ref flights, value, () => Flights);
                // TODO: in case flight items in the list are changed,
                // then also we need to reset flightInitialized!!
                // reset cached variables for Flights
                flightInitialized = false;
            }
        }

        #region Non domain model methods for optimization at client

        [NonSerialized]
        private bool flightInitialized = false;

        // helper method that initializes arr/dep flights
        private void InitArrDepFlight()
        {
            if (Flights != null)
            {
                foreach (Flight flight in Flights)
                {
                    if (flight == null)
                    {
                        // should not happen
                        continue;
                    }
                    else if (flight.MovementIndicator == MovementType.Arrival)
                    {
                        arrivalFlight = flight;
                        arrivalAirport = GetArrDepAirport(flight);
                    }
                    else if (flight.MovementIndicator == MovementType.Departure)
                    {
                        departureFlight = flight;
                        departureAirport = GetArrDepAirport(flight);
                    }
                }
            }
        }

        // helper method that determines Arr/Dep Airport
        private string GetArrDepAirport(Flight flight)
        {
            if (flight.Routes == null)
            {
                return string.Empty;
            }
            //Get the single airport.  
            Route result = flight.Routes.Where(route => route.RouteNumber == 1).Single();
            if (result == null || result.Airport == null)
            {
                return string.Empty;
            }
            return result.Airport.Code;
        }

        [NonSerialized]
        private Flight arrivalFlight;
        /// <summary>
        /// Returns Arrival Flight for this Stand Task.
        /// Returns null if none exists
        /// </summary>
        public Flight ArrivalFlight
        {
            get
            {
                if (!flightInitialized)
                {
                    InitArrDepFlight();
                    flightInitialized = true;
                }
                return arrivalFlight;
            }
        }

        [NonSerialized]
        private Flight departureFlight;
        /// <summary>
        /// Returns Departure Flight for this Stand Task.
        /// Returns null if none exists
        /// </summary>
        public Flight DepartureFlight
        {
            get
            {
                if (!flightInitialized)
                {
                    InitArrDepFlight();
                    flightInitialized = true;
                }
                return departureFlight;
            }
        }

        [NonSerialized]
        private string arrivalAirport;
        /// <summary>
        /// Returns Arrival Airport for this Stand Task.
        /// Returns null if none exists.
        /// </summary>
        public string ArrivalAirport
        {
            get
            {
                if (!flightInitialized)
                {
                    InitArrDepFlight();
                    flightInitialized = true;
                }
                return arrivalAirport;
            }
        }

        [NonSerialized]
        private string departureAirport;
        /// <summary>
        /// Returns Arrival Airport for this Stand Task.
        /// Returns null if none exists.
        /// </summary>
        public string DepartureAirport
        {
            get
            {
                if (!flightInitialized)
                {
                    InitArrDepFlight();
                    flightInitialized = true;
                }
                return departureAirport;
            }
        }

        #endregion
    }
}



