
using com.unisys.rms.domain;
using System;
using com.unisys.rms.domain.resource;
using ResourcesClient.Entity.Util;





///<p>Reference Data entities</p>
// @generated
namespace com.unisys.rms.domain.reference
{

	
	///<p>An Airport</p>
	// @wasgenerated
	public partial class Airport : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		// @generated
		private String icaoCode;



		//@wasgenerated
		private string location;



		// @generated
		private Country country;



		//@wasgenerated
		private string deleted;



		///<p>IATA 3 letter airport code</p>
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


	

		///<p>Name/description for the airport</p>
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


	

		///<p>Localized description of the Airport</p>
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


	

		///<p>ICAO code for the airport</p>
		// @generated
		public String IcaoCode
		{

			get
			{
				return icaoCode;
			}

			set
			{
				SetField(ref icaoCode, value, () => IcaoCode);
			}

		}


	

		///<p>Airport location with respect to base airport (North, South, East, West)</p>
		// @generated
		public LocationType? Location
		{

			get
			{
				return EnumHelper.EnumFromValue<LocationType?>(location);
			}

			set
			{
				SetEnumField(ref location, value, () => Location);
			}

		}


	

		///<p>The country where airport belongs</p>
		// @generated
		public Country Country
		{

			get
			{
				return country;
			}

			set
			{
				SetField(ref country, value, () => Country);
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



