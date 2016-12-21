
using System;
using com.unisys.rms.domain.flight;
using com.unisys.rms.domain;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>Task that is associated with one or more flights. These tasks are generated based on flight schedule.</p>
	// @wasgenerated
	public abstract partial class FlightTask : Task
	{


		// @generated
		private DateTime? actStart;



		// @generated
		private DateTime? actEnd;



		//@wasgenerated
		private string acRegoChange;



		// @generated
		private DateTime workStart;



		// @generated
		private DateTime workEnd;



		///<p>Task actual start date/time. Updated with actual events received for flight (Checkin open, Chock on, First bag, Boarding open)</p>
		// @generated
		public DateTime? ActStart
		{

			get
			{
				return actStart;
			}

			set
			{
				SetField(ref actStart, value, () => ActStart);
			}

		}


	

		///<p>Task actual end date/time. Updated with actual events received for flight (Checkin close, Chock off, Last bag, Boarding close)</p>
		// @generated
		public DateTime? ActEnd
		{

			get
			{
				return actEnd;
			}

			set
			{
				SetField(ref actEnd, value, () => ActEnd);
			}

		}


	

		///<p>Indicates if the task flight has had a change of aircraft registration number. This flag is cleared after subsequent reallocation</p>
		// @generated
		public bool AcRegoChange
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(acRegoChange);
			}

			set
			{
				SetBoolField(ref acRegoChange, value, () => AcRegoChange);
			}

		}


	

		///<p>Current working start time for the flight task. Always updated with latest value</p>
		// @generated
		public DateTime WorkStart
		{

			get
			{
				return workStart;
			}

			set
			{
				SetField(ref workStart, value, () => WorkStart);
			}

		}


	

		///<p>Current working end time for the flight task.  Always updated with latest value</p>
		// @generated
		public DateTime WorkEnd
		{

			get
			{
				return workEnd;
			}

			set
			{
				SetField(ref workEnd, value, () => WorkEnd);
			}

		}



	
	}
	

}



