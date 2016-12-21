
using com.unisys.rms.domain;
using System;
using com.unisys.rms.domain.system;





///<p>Reference Data entities</p>
// @generated
namespace com.unisys.rms.domain.reference
{

	
	///<p>The defined categories to which Conflicts can belong to</p>
	// @wasgenerated
	public partial class ConflictCategory : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		// @generated
		private Color color;



		///<p>The unique conflict category code</p>
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


	

		///<p>The description of the conflict category</p>
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


	

		///<p>The localized description for the conflict category</p>
		// @generated
		public String LocalDesc
		{

			get
			{
				return localDesc;
			}

			set
			{
				SetField(ref localDesc, value, () => LocalDesc);
			}

		}


	

		///<p>The color to use for conflict display</p>
		// @generated
		public Color Color
		{

			get
			{
				return color;
			}

			set
			{
				SetField(ref color, value, () => Color);
			}

		}



	
	}
	

}



