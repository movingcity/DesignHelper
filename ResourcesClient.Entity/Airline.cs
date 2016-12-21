
using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;





///<p>Reference Data entities</p>
// @generated
namespace com.unisys.rms.domain.reference
{

	
	///<p>An Airline</p>
	// @wasgenerated
	public partial class Airline : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String icaoCode;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		// @generated
		private HandlingAgent paxHandler;



		// @generated
		private HandlingAgent maintHandler;



		// @generated
		private HandlingAgent groundHandler;



		// @generated
		private String alliance;



		// @generated
		private Country country;



		//@wasgenerated
		private string deleted;



		///<p>2 letter IATA code for this airline</p>
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


	

		///<p>3 letter ICAO code for this airline</p>
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


	

		///<p>Airline name/description</p>
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


	

		///<p>Localized description of Airline</p>
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


	

		///<p>The passenger handler for this airline</p>
		// @generated
		public HandlingAgent PaxHandler
		{

			get
			{
				return paxHandler;
			}

			set
			{
				SetField(ref paxHandler, value, () => PaxHandler);
			}

		}


	

		///<p>The maintenance handler for this airline</p>
		// @generated
		public HandlingAgent MaintHandler
		{

			get
			{
				return maintHandler;
			}

			set
			{
				SetField(ref maintHandler, value, () => MaintHandler);
			}

		}


	

		///<p>The ground handler for this airline</p>
		// @generated
		public HandlingAgent GroundHandler
		{

			get
			{
				return groundHandler;
			}

			set
			{
				SetField(ref groundHandler, value, () => GroundHandler);
			}

		}


	

		///<p>Alliance/Group airline belongs to</p>
		// @generated
		public String Alliance
		{

			get
			{
				return alliance;
			}

			set
			{
				SetField(ref alliance, value, () => Alliance);
			}

		}


	

		///<p>The country to which airline belongs to</p>
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



