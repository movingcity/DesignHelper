
using com.unisys.rms.domain.resource;
using System;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>Task which is not associated with a flight. Can be of type:</p><ul><li><p>Complete downtime for a resource</p></li><li><p>Partial downtime for a resource</p></li></ul><p></p>
	// @wasgenerated
	public partial class NonFlightTask : Task
	{


		//@wasgenerated
		private string module;



		//@wasgenerated
		private string type;



		// @generated
		private String remarks;



		///<p>The module to which the NonFlightTask belongs</p>
		// @generated
		public ResourceType Module
		{

			get
			{
				return EnumHelper.EnumFromValue<ResourceType>(module);
			}

			set
			{
				SetEnumField(ref module, value, () => Module);
			}

		}


	

		///<p>The type of the Non Flight Task - Complete or Partial</p>
		// @generated
		public NonFlightTaskType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<NonFlightTaskType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	

		///<p>Remarks/Comments for the Non Flight Task</p>
		// @generated
		public String Remarks
		{

			get
			{
				return remarks;
			}

			set
			{
				SetField(ref remarks, value, () => Remarks);
			}

		}



	
	}
	

}



