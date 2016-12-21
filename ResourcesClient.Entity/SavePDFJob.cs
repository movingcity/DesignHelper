
using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;
using System.Collections.Generic;
using System;





///<p>Entities related to application batch jobs</p>
// @generated
namespace com.unisys.rms.domain.system.batch
{

	
	///<p>Represents a scheduler job that save the results of various resource allocations within RMS as PDF files.</p>
	// @wasgenerated
	public partial class SavePDFJob : SchedulerJob
	{


		///<p>Resource types to be included in save as PDF.</p>
		// @wasgenerated
		private List<String> resourceType;



		///<p>Gantt Areas to be included in save as PDF.</p>
		// @wasgenerated
		private List<String> areasIncluded;



	}
	

}



