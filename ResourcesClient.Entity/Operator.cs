
using com.unisys.rms.domain;
using System;





///<p>Entities related to attributes used in Criteria entities (simple expressions). This is static reference data</p>
// @generated
namespace com.unisys.rms.domain.criteria.attribute
{

	
	///<p>The operators available for attributes</p>
	// @wasgenerated
	public partial class Operator : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		///<p>Unique code</p>
		// @generated
		public String Code
		{

			get
			{
				return code;
			}

			set
			{
				SetField(ref code, value, () => Code);
			}

		}


	

		///<p>Description to display</p>
		// @generated
		public String Description
		{

			get
			{
				return description;
			}

			set
			{
				SetField(ref description, value, () => Description);
			}

		}



	
	}
	

}



