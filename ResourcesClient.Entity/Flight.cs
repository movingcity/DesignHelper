
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.task;
using com.unisys.rms.domain.reference;
using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Flight related entities</p>
// @generated
namespace com.unisys.rms.domain.flight
{

	
	///<p>The flight record.</p>
	// @wasgenerated
	public partial class Flight : RMSEntity
	{


		// @generated
		private long? aodbId;



		// @generated
		private Airline airline;



		// @generated
		private String flightNumber;



		//@wasgenerated
		private string movementIndicator;



		// @generated
		private DateTime sto;



		// @generated
		private DateTime? eto;



		// @generated
		private DateTime? ato;



		// @generated
		private AircraftType aircraftType;



		// @generated
		private Aircraft registration;



		// @generated
		private FlightServiceType serviceType;



		//@wasgenerated
		private string flightIndicator;



		///<p>Flight routing details</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.flight.Route
		private ObservableCollection<Route> routes;



		// @generated
		private Flight turnaroundFlight;



		// @generated
		private Terminal terminal;



		// @generated
		private int? maxPax;



		// @generated
		private Flight masterFlight;



		// @generated
		private HandlingAgent paxHandlingAgent;



		// @generated
		private HandlingAgent fieldHandlingAgent;



		// @generated
		private HandlingAgent maintHandlingAgent;



		// @generated
		private String remarks;



		// @generated
		private int? vipFlag;



		// @generated
		private DateTime? lastCallTime;



		// @generated
		private int? paxCount;



		// @generated
		private DateTime? cancel;



		// @generated
		private Divert divert;



		// @generated
		private ReturnData returnData;



		// @generated
		private String standComment;



		// @generated
		private String counterComment;



		// @generated
		private String carouselComment;



		///<p>Stand tasks associated with flight</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.task.StandTask
		private ObservableCollection<StandTask> standTask;



		///<p>Gate tasks associated with flight</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.task.GateTask
		private ObservableCollection<GateTask> gateTask;



		///<p>Checkin Counter tasks associated with flight</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.task.CounterTask
		private ObservableCollection<CounterTask> counterTask;



		///<p>Carousel Tasks associated with flight</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.task.CarouselTask
		private ObservableCollection<CarouselTask> carouselTask;



		// @generated
		private DateTime? chockOn;



		// @generated
		private DateTime? chockOff;



		// @generated
		private DateTime? ckinOpen;



		// @generated
		private DateTime? ckinClose;



		// @generated
		private DateTime? firstBag;



		// @generated
		private DateTime? lastBag;



		// @generated
		private DateTime? bdgOpen;



		// @generated
		private DateTime? bdgClose;



		// @generated
		private DateTime? airbAttach;



		// @generated
		private DateTime? airbDetach;



		///<p>For a code share master flight, contains the child code-share flights</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.flight.Flight
		private ObservableCollection<Flight> childFlights;



		// @generated
		private DateTime? finals;



		// @generated
		private DateTime? acDoorOpen;



		// @generated
		private DateTime? acDoorClose;



		// @generated
		private int? bagCount;



		// @generated
		private int? fClassPax;



		// @generated
		private int? cClassPax;



		// @generated
		private int? yClassPax;



		// @generated
		private String runwayCode;



		// @generated
		private String airCorridor;



		// @generated
		private Airport prevNextAirport;



		// @generated
		private DateTime prevNextSto;



		///<p>AODB flight identifier</p>
		// @generated
		public long? AodbId
		{

			get
			{
				return aodbId;
			}

			set
			{
				SetField(ref aodbId, value, () => AodbId);
			}

		}


	

		///<p>Airline Operator</p>
		// @generated
		public Airline Airline
		{

			get
			{
				return airline;
			}

			set
			{
				SetField(ref airline, value, () => Airline);
			}

		}


	

		///<p>The flight number</p>
		// @generated
		public String FlightNumber
		{

			get
			{
				return flightNumber;
			}

			set
			{
				SetField(ref flightNumber, value, () => FlightNumber);
			}

		}


	

		///<p>Arrival/Departure Indicator</p>
		// @generated
		public MovementType MovementIndicator
		{

			get
			{
				return EnumHelper.EnumFromValue<MovementType>(movementIndicator);
			}

			set
			{
				SetEnumField(ref movementIndicator, value, () => MovementIndicator);
			}

		}


	

		///<p>Scheduled date/time of operation</p>
		// @generated
		public DateTime Sto
		{

			get
			{
				return sto;
			}

			set
			{
				SetField(ref sto, value, () => Sto);
			}

		}


	

		///<p>Estimated date/time of operation</p>
		// @generated
		public DateTime? Eto
		{

			get
			{
				return eto;
			}

			set
			{
				SetField(ref eto, value, () => Eto);
			}

		}


	

		///<p>Actual date/time of operation</p>
		// @generated
		public DateTime? Ato
		{

			get
			{
				return ato;
			}

			set
			{
				SetField(ref ato, value, () => Ato);
			}

		}


	

		///<p>The aircraft type</p>
		// @generated
		public AircraftType AircraftType
		{

			get
			{
				return aircraftType;
			}

			set
			{
				SetField(ref aircraftType, value, () => AircraftType);
			}

		}


	

		///<p>Aircraft Registration number</p>
		// @generated
		public Aircraft Registration
		{

			get
			{
				return registration;
			}

			set
			{
				SetField(ref registration, value, () => Registration);
			}

		}


	

		///<p>Flight Service Type</p>
		// @generated
		public FlightServiceType ServiceType
		{

			get
			{
				return serviceType;
			}

			set
			{
				SetField(ref serviceType, value, () => ServiceType);
			}

		}


	

		///<p>Flight Domestic/International/Mixed/Schengen/Regional indicator</p>
		// @generated
		public FlightIndicatorType FlightIndicator
		{

			get
			{
				return EnumHelper.EnumFromValue<FlightIndicatorType>(flightIndicator);
			}

			set
			{
				SetEnumField(ref flightIndicator, value, () => FlightIndicator);
			}

		}


	

		///<p>The turn-around flight (if exists) for an Arrival</p>
		// @generated
		public Flight TurnaroundFlight
		{

			get
			{
				return turnaroundFlight;
			}

			set
			{
				SetField(ref turnaroundFlight, value, () => TurnaroundFlight);
			}

		}


	

		///<p>The terminal where the flight operates</p>
		// @generated
		public Terminal Terminal
		{

			get
			{
				return terminal;
			}

			set
			{
				SetField(ref terminal, value, () => Terminal);
			}

		}


	

		///<p>Maximum passengers the flight can carry</p>
		// @generated
		public int? MaxPax
		{

			get
			{
				return maxPax;
			}

			set
			{
				SetField(ref maxPax, value, () => MaxPax);
			}

		}


	

		///<p>For code-share, the master flight</p>
		// @generated
		public Flight MasterFlight
		{

			get
			{
				return masterFlight;
			}

			set
			{
				SetField(ref masterFlight, value, () => MasterFlight);
			}

		}


	

		///<p>Passenger Handling Agent</p>
		// @generated
		public HandlingAgent PaxHandlingAgent
		{

			get
			{
				return paxHandlingAgent;
			}

			set
			{
				SetField(ref paxHandlingAgent, value, () => PaxHandlingAgent);
			}

		}


	

		///<p>Ground Handling Agent</p>
		// @generated
		public HandlingAgent FieldHandlingAgent
		{

			get
			{
				return fieldHandlingAgent;
			}

			set
			{
				SetField(ref fieldHandlingAgent, value, () => FieldHandlingAgent);
			}

		}


	

		///<p>Maintenance Handling Agent</p>
		// @generated
		public HandlingAgent MaintHandlingAgent
		{

			get
			{
				return maintHandlingAgent;
			}

			set
			{
				SetField(ref maintHandlingAgent, value, () => MaintHandlingAgent);
			}

		}


	

		///<p>Flight remarks</p>
		// @generated
		public String Remarks
		{

			get
			{
				return remarks;
			}

			set
			{
				SetField(ref remarks, value, () => Remarks);
			}

		}


	

		///<p>VIP indicator for the flight</p>
		// @generated
		public int? VipFlag
		{

			get
			{
				return vipFlag;
			}

			set
			{
				SetField(ref vipFlag, value, () => VipFlag);
			}

		}


	

		///<p>Time for last call for departure flight</p>
		// @generated
		public DateTime? LastCallTime
		{

			get
			{
				return lastCallTime;
			}

			set
			{
				SetField(ref lastCallTime, value, () => LastCallTime);
			}

		}


	

		///<p>Total number of passengers in flight</p>
		// @generated
		public int? PaxCount
		{

			get
			{
				return paxCount;
			}

			set
			{
				SetField(ref paxCount, value, () => PaxCount);
			}

		}


	

		///<p>Flight cancel date time</p>
		// @generated
		public DateTime? Cancel
		{

			get
			{
				return cancel;
			}

			set
			{
				SetField(ref cancel, value, () => Cancel);
			}

		}


	

		///<p>Divert data for the flight record</p>
		// @generated
		public Divert Divert
		{

			get
			{
				return divert;
			}

			set
			{
				SetField(ref divert, value, () => Divert);
			}

		}


	

		///<p>Return data for the flight</p>
		// @generated
		public ReturnData ReturnData
		{

			get
			{
				return returnData;
			}

			set
			{
				SetField(ref returnData, value, () => ReturnData);
			}

		}


	

		///<p>Flight comment from Stand module</p>
		// @generated
		public String StandComment
		{

			get
			{
				return standComment;
			}

			set
			{
				SetField(ref standComment, value, () => StandComment);
			}

		}


	

		///<p>Flight comment from Checkin Counter module</p>
		// @generated
		public String CounterComment
		{

			get
			{
				return counterComment;
			}

			set
			{
				SetField(ref counterComment, value, () => CounterComment);
			}

		}


	

		///<p>Flight comment from Carousel module</p>
		// @generated
		public String CarouselComment
		{

			get
			{
				return carouselComment;
			}

			set
			{
				SetField(ref carouselComment, value, () => CarouselComment);
			}

		}


	

		///<p>Chock on time for arrival flight</p>
		// @generated
		public DateTime? ChockOn
		{

			get
			{
				return chockOn;
			}

			set
			{
				SetField(ref chockOn, value, () => ChockOn);
			}

		}


	

		///<p>Chock off time for departure flight</p>
		// @generated
		public DateTime? ChockOff
		{

			get
			{
				return chockOff;
			}

			set
			{
				SetField(ref chockOff, value, () => ChockOff);
			}

		}


	

		///<p>Checkin counter open for departure flight</p>
		// @generated
		public DateTime? CkinOpen
		{

			get
			{
				return ckinOpen;
			}

			set
			{
				SetField(ref ckinOpen, value, () => CkinOpen);
			}

		}


	

		///<p>Checkin counter close time for departure flight</p>
		// @generated
		public DateTime? CkinClose
		{

			get
			{
				return ckinClose;
			}

			set
			{
				SetField(ref ckinClose, value, () => CkinClose);
			}

		}


	

		///<p>First bag for arrival flight</p>
		// @generated
		public DateTime? FirstBag
		{

			get
			{
				return firstBag;
			}

			set
			{
				SetField(ref firstBag, value, () => FirstBag);
			}

		}


	

		///<p>Last bag for arrival flight</p>
		// @generated
		public DateTime? LastBag
		{

			get
			{
				return lastBag;
			}

			set
			{
				SetField(ref lastBag, value, () => LastBag);
			}

		}


	

		///<p>Boarding open time for departure flight</p>
		// @generated
		public DateTime? BdgOpen
		{

			get
			{
				return bdgOpen;
			}

			set
			{
				SetField(ref bdgOpen, value, () => BdgOpen);
			}

		}


	

		///<p>Boarding close time for departure time</p>
		// @generated
		public DateTime? BdgClose
		{

			get
			{
				return bdgClose;
			}

			set
			{
				SetField(ref bdgClose, value, () => BdgClose);
			}

		}


	

		///<p>Airbridge attach time</p>
		// @generated
		public DateTime? AirbAttach
		{

			get
			{
				return airbAttach;
			}

			set
			{
				SetField(ref airbAttach, value, () => AirbAttach);
			}

		}


	

		///<p>Airbridge detach time</p>
		// @generated
		public DateTime? AirbDetach
		{

			get
			{
				return airbDetach;
			}

			set
			{
				SetField(ref airbDetach, value, () => AirbDetach);
			}

		}


	

		///<p>Finals date time (for arrivals only)</p>
		// @generated
		public DateTime? Finals
		{

			get
			{
				return finals;
			}

			set
			{
				SetField(ref finals, value, () => Finals);
			}

		}


	

		///<p>Aircraft door open time</p>
		// @generated
		public DateTime? AcDoorOpen
		{

			get
			{
				return acDoorOpen;
			}

			set
			{
				SetField(ref acDoorOpen, value, () => AcDoorOpen);
			}

		}


	

		///<p>Aircraft door close time</p>
		// @generated
		public DateTime? AcDoorClose
		{

			get
			{
				return acDoorClose;
			}

			set
			{
				SetField(ref acDoorClose, value, () => AcDoorClose);
			}

		}


	

		///<p>Bags count</p>
		// @generated
		public int? BagCount
		{

			get
			{
				return bagCount;
			}

			set
			{
				SetField(ref bagCount, value, () => BagCount);
			}

		}


	

		///<p>First class pax count</p>
		// @generated
		public int? FClassPax
		{

			get
			{
				return fClassPax;
			}

			set
			{
				SetField(ref fClassPax, value, () => FClassPax);
			}

		}


	

		///<p>Business class pax count</p>
		// @generated
		public int? CClassPax
		{

			get
			{
				return cClassPax;
			}

			set
			{
				SetField(ref cClassPax, value, () => CClassPax);
			}

		}


	

		///<p>Economy class pax count</p>
		// @generated
		public int? YClassPax
		{

			get
			{
				return yClassPax;
			}

			set
			{
				SetField(ref yClassPax, value, () => YClassPax);
			}

		}


	

		///<p>Runway code</p>
		// @generated
		public String RunwayCode
		{

			get
			{
				return runwayCode;
			}

			set
			{
				SetField(ref runwayCode, value, () => RunwayCode);
			}

		}


	

		///<p>Air corridor</p>
		// @generated
		public String AirCorridor
		{

			get
			{
				return airCorridor;
			}

			set
			{
				SetField(ref airCorridor, value, () => AirCorridor);
			}

		}


	

		///<p>Previous/Next station details - Previous airport for arrivals and Next airport for departures</p>
		// @generated
		public Airport PrevNextAirport
		{

			get
			{
				return prevNextAirport;
			}

			set
			{
				SetField(ref prevNextAirport, value, () => PrevNextAirport);
			}

		}


	

		///<p>Previous/Next station details - Previous airport scheduled time for arrivals and Next airport scheduled time for departures</p>
		// @generated
		public DateTime PrevNextSto
		{

			get
			{
				return prevNextSto;
			}

			set
			{
				SetField(ref prevNextSto, value, () => PrevNextSto);
			}

		}



	
	}
	

}



