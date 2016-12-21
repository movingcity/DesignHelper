
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;





///<p>Entities related to attributes used in Criteria entities (simple expressions). This is static reference data</p>
// @generated
namespace com.unisys.rms.domain.criteria.attribute
{

	
	///<p>Available types of Attributes which have associated allowed operators</p>
	// @wasgenerated
	public partial class AttributeType : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		///<p>Available operators for this type</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.criteria.attribute.Operator
		private ObservableCollection<Operator> operators;



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



