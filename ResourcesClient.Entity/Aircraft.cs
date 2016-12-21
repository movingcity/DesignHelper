
using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;





///<p>Reference Data entities</p>
// @generated
namespace com.unisys.rms.domain.reference
{

	
	///<p>An Aircraft instance, uniquely identified by its registration number</p>
	// @wasgenerated
	public partial class Aircraft : RMSEntity
	{


		// @generated
		private String registration;



		// @generated
		private AircraftType type;



		// @generated
		private Airline airline;



		// @generated
		private int? maxPax;



		//@wasgenerated
		private string deleted;



		///<p>Unique aircraft registration number</p>
		// @generated
		public String Registration
		{

			get
			{
				return registration;
			}

			set
			{
				SetField(ref registration, value, () => Registration);
			}

		}


	

		///<p>Aircraft type</p>
		// @generated
		public AircraftType Type
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


	

		///<p>The airline to which the aircraft belongs to</p>
		// @generated
		public Airline Airline
		{

			get
			{
				return airline;
			}

			set
			{
				SetField(ref airline, value, () => Airline);
			}

		}


	

		///<p>Maximum passenger volume</p>
		// @generated
		public int? MaxPax
		{

			get
			{
				return maxPax;
			}

			set
			{
				SetField(ref maxPax, value, () => MaxPax);
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



