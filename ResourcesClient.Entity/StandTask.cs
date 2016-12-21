
using System.Collections.ObjectModel;
using com.unisys.rms.domain.flight;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>A Flight Task that is allocated to Stand resources</p>
	// @wasgenerated
	public partial class StandTask : FlightTask
	{


		//@wasgenerated
		private string type;



		// @generated
		private StandTask prevTask;



		// @generated
		private StandTask nextTask;



		///<p>The flights associated with the Stand Task</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.flight.Flight
		private ObservableCollection<Flight> flights;



		///<p>Type of Stand Task - can be Arrival, Departure, Both, Tow or Long Staying.</p>
		// @generated
		public StandTaskType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<StandTaskType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	

		///<p>The previous Stand Task associated with this task (if any)</p>
		// @generated
		public StandTask PrevTask
		{

			get
			{
				return prevTask;
			}

			set
			{
				SetField(ref prevTask, value, () => PrevTask);
			}

		}


	

		///<p>The next Stand Task associated with this task (if any)</p>
		// @generated
		public StandTask NextTask
		{

			get
			{
				return nextTask;
			}

			set
			{
				SetField(ref nextTask, value, () => NextTask);
			}

		}



	
	}
	

}



