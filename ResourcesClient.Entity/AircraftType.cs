
using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;





///<p>Reference Data entities</p>
// @generated
namespace com.unisys.rms.domain.reference
{

	
	///<p>Type of aircraft</p>
	// @wasgenerated
	public partial class AircraftType : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		// @generated
		private String icaoCode;



		// @generated
		private String category;



		// @generated
		private int? length;



		// @generated
		private int? wingspan;



		// @generated
		private int? height;



		// @generated
		private int? maxPax;



		// @generated
		private int? minArrTime;



		// @generated
		private int? minDepTime;



		// @generated
		private int? minTurnAroundTime;



		//@wasgenerated
		private string deleted;



		///<p>IATA aircraft type code</p>
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


	

		///<p>Aircraft type name/description</p>
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


	

		///<p>Localized description of Aircraft type</p>
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


	

		///<p>ICAO aircraft type code</p>
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


	

		///<p>IATA standard 1 letter aircraft category code (refers to size category like A/B/C/D/E)</p>
		// @generated
		public String Category
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


	

		///<p>Full length of aircraft (m)</p>
		// @generated
		public int? Length
		{

			get
			{
				return length;
			}

			set
			{
				SetField(ref length, value, () => Length);
			}

		}


	

		///<p>The wing-span of the aircraft (m)</p>
		// @generated
		public int? Wingspan
		{

			get
			{
				return wingspan;
			}

			set
			{
				SetField(ref wingspan, value, () => Wingspan);
			}

		}


	

		///<p>Aircraft height (m)</p>
		// @generated
		public int? Height
		{

			get
			{
				return height;
			}

			set
			{
				SetField(ref height, value, () => Height);
			}

		}


	

		///<p>Maximum allowed passengers</p>
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


	

		///<p>Minimum time for Arrival Only tasks of this aircraft (min)</p>
		// @generated
		public int? MinArrTime
		{

			get
			{
				return minArrTime;
			}

			set
			{
				SetField(ref minArrTime, value, () => MinArrTime);
			}

		}


	

		///<p>Minimum time for Departure Only tasks of this aircraft (min)</p>
		// @generated
		public int? MinDepTime
		{

			get
			{
				return minDepTime;
			}

			set
			{
				SetField(ref minDepTime, value, () => MinDepTime);
			}

		}


	

		///<p>Minimum time for Turnaround tasks of this aircraft (min)</p>
		// @generated
		public int? MinTurnAroundTime
		{

			get
			{
				return minTurnAroundTime;
			}

			set
			{
				SetField(ref minTurnAroundTime, value, () => MinTurnAroundTime);
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



