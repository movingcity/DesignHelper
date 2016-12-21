
using com.unisys.rms.domain;
using System;





///<p>Entities related to grouping of data to be used in the criteria.</p>
// @generated
namespace com.unisys.rms.domain.criteria.group
{

	
	///<p>An item that is contained within a Rule/Query group</p>
	// @wasgenerated
	public abstract partial class Item : RMSEntity
	{

	
		///<p>Returns true if the group contains the passed value</p>
		///<returns></returns><param name="value"></param>
		// @generated
		public abstract bool Contains(String value);
	


	}
	

}



