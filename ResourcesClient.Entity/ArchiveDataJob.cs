
using System.Collections.ObjectModel;
using com.unisys.rms.domain.reference;





///<p>Entities related to application batch jobs</p>
// @generated
namespace com.unisys.rms.domain.system.batch
{

	
	///<p>Represents a scheduler job that deletes archived data</p>
	// @wasgenerated
	public partial class ArchiveDataJob : SchedulerJob
	{


		///<p>List of airlines whose archive data is to be deleted. Default should be ALL (empty list).</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.reference.Airline
		private ObservableCollection<Airline> airlines;



	}
	

}



