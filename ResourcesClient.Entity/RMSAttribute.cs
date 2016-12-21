
using com.unisys.rms.domain;
using System;





///<p>Entities related to attributes used in Criteria entities (simple expressions). This is static reference data</p>
// @generated
namespace com.unisys.rms.domain.criteria.attribute
{

	
	///<p>Attribute used to create criteria (simple expressions)</p>
	// @wasgenerated
	public partial class RMSAttribute : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		// @generated
		private AttributeType type;



		// @generated
		private Category category;



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


	

		///<p>The type of this attribute</p>
		// @generated
		public AttributeType Type
		{

			get
			{
				return type;
			}

			set
			{
				SetField(ref type, value, () => Type);
			}

		}


	

		///<p>The category of this attribute</p>
		// @generated
		public Category Category
		{

			get
			{
				return category;
			}

			set
			{
				SetField(ref category, value, () => Category);
			}

		}



	
	}
	

}



