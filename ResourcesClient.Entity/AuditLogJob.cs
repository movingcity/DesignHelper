
using System.Collections.ObjectModel;
using com.unisys.rms.domain.user;





///<p>Entities related to application batch jobs</p>
// @generated
namespace com.unisys.rms.domain.system.batch
{

	
	///<p>Represents a scheduler job that deletes audit data</p>
	// @wasgenerated
	public partial class AuditLogJob : SchedulerJob
	{


		///<p>List of audit functions whose audit data is to be deleted. Default should be ALL (empty list).</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.user.Function
		private ObservableCollection<Function> functions;



	}
	

}



