
using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;





///<p>Reference Data entities</p>
// @generated
namespace com.unisys.rms.domain.reference
{

	
	///<p>A country</p>
	// @wasgenerated
	public partial class Country : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		// @generated
		private String region;



		//@wasgenerated
		private string deleted;



		///<p>Country code</p>
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


	

		///<p>Country name</p>
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


	

		///<p>Localized Country name</p>
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


	

		///<p>Region code (to which country belongs)</p>
		// @generated
		public String Region
		{

			get
			{
				return region;
			}

			set
			{
				SetField(ref region, value, () => Region);
			}

		}


	

		///<p>True value indicates entity has been marked for deletion</p>
		// @generated
		public bool Deleted
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(deleted);
			}

			set
			{
				SetBoolField(ref deleted, value, () => Deleted);
			}

		}



	
	}
	

}



