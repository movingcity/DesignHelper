
using com.unisys.rms.domain;
using com.unisys.rms.domain.reference;
using com.unisys.rms.domain.task;
using ResourcesClient.Entity.Util;





///<p>Task generation entities</p>
// @generated
namespace com.unisys.rms.domain.task.generate
{

	
	///<p>An item that is used to generate tasks</p>
	// @wasgenerated
	public partial class GenerateTaskItem : RMSEntity
	{


		// @generated
		private int count;



		// @generated
		private int start;



		// @generated
		private int end;



		// @generated
		private FlightClass flightClass;



		//@wasgenerated
		private string type;



		///<p>The count of tasks to generate for this item</p>
		// @generated
		public int Count
		{

			get
			{
				return count;
			}

			set
			{
				SetField(ref count, value, () => Count);
			}

		}


	

		///<p>The start time for the generated task(s).</p><p>Absolute list - Time will be specified in minutes from 0000 hours for the day in question.<br>Flight relative list - Time will be specified in minutes relative to flight operation time.</p>
		// @generated
		public int Start
		{

			get
			{
				return start;
			}

			set
			{
				SetField(ref start, value, () => Start);
			}

		}


	

		///<p>The end time for the generated task(s).</p><p>Absolute list - Time will be specified in minutes from 0000 hours for the day in question.<br>Flight relative list - Time will be specified in minutes relative to flight operation time.</p>
		// @generated
		public int End
		{

			get
			{
				return end;
			}

			set
			{
				SetField(ref end, value, () => End);
			}

		}


	

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


	

		///<p>The Domestic/International type of the generated task. Valid (and mandatory) only for Gate, Carousel and Counter modules.</p>
		// @generated
		public IndicatorType? Type
		{

			get
			{
				return EnumHelper.EnumFromValue<IndicatorType?>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}



	
	}
	

}



