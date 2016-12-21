
using com.unisys.rms.domain.flight;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>A Flight Task that is allocated to Gate resources</p>
	// @wasgenerated
	public partial class GateTask : FlightTask
	{


		//@wasgenerated
		private string domIntlIndicator;



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


	

		///<p>The flight associated with the Gate Task</p>
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



