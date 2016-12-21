
using com.unisys.rms.domain.reference;
using com.unisys.rms.domain.flight;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>A Flight Task that is allocated to Baggage Carousel resources for arrival flights</p>
	// @wasgenerated
	public partial class CarouselTask : FlightTask
	{


		//@wasgenerated
		private string domIntlIndicator;



		// @generated
		private FlightClass flightClass;



		// @generated
		private Flight flight;



		///<p>The indicator for this task - Domestic or International</p>
		// @generated
		public IndicatorType DomIntlIndicator
		{

			get
			{
				return EnumHelper.EnumFromValue<IndicatorType>(domIntlIndicator);
			}

			set
			{
				SetEnumField(ref domIntlIndicator, value, () => DomIntlIndicator);
			}

		}


	

		///<p>The flight class for this task. If absent, indicates ALL classes</p>
		// @generated
		public FlightClass FlightClass
		{

			get
			{
				return flightClass;
			}

			set
			{
				SetField(ref flightClass, value, () => FlightClass);
			}

		}


	

		///<p>The flight associated with the Carousel Task</p>
		// @generated
		public Flight Flight
		{

			get
			{
				return flight;
			}

			set
			{
				SetField(ref flight, value, () => Flight);
			}

		}



	
	}
	

}



