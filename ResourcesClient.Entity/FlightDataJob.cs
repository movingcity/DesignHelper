
using System.Collections.ObjectModel;
using com.unisys.rms.domain.reference;
using ResourcesClient.Entity.Util;





///<p>Entities related to application batch jobs</p>
// @generated
namespace com.unisys.rms.domain.system.batch
{

	
	///<p>Represents a scheduler job that moves the constantly building volume of flight data between different data areas within RMS on an incremental basis as manageable chunks</p>
	// @wasgenerated
	public partial class FlightDataJob : SchedulerJob
	{


		//@wasgenerated
		private string source;



		///<p>List of airlines whose flight data is to be moved. Default should be ALL (empty list).</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.reference.Airline
		private ObservableCollection<Airline> airlines;



		///<p>Source area of flight data: Can be Future or Current. <br></br>Destination area for the flight data is assumed as Current when the Source is Future or assumed as Archive when the Source is Current.</p>
		// @generated
		public FlightDataSource Source
		{

			get
			{
				return EnumHelper.EnumFromValue<FlightDataSource>(source);
			}

			set
			{
				SetEnumField(ref source, value, () => Source);
			}

		}



	
	}
	

}



