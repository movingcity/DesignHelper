
using com.unisys.rms.domain;





///<p>Allocation template related entities</p>
// @generated
namespace com.unisys.rms.domain.template
{

	
	///<p>Defines the allocation template for a specific flight profile</p>
	// @wasgenerated
	public abstract partial class FlightMember : RMSEntity
	{


		// @generated
		private int daysOfWeek;



		///<p>Days of week for which template entry is valid.</p><p>Bit mask of the format SMTWTFS</p>
		// @generated
		public int DaysOfWeek
		{

			get
			{
				return daysOfWeek;
			}

			set
			{
				SetField(ref daysOfWeek, value, () => DaysOfWeek);
			}

		}



	
	}
	

}



