
using com.unisys.rms.domain;
using com.unisys.rms.domain.reference;
using System;





///<p>Flight related entities</p>
// @generated
namespace com.unisys.rms.domain.flight
{

	
	///<p>Route details for a flight</p>
	// @wasgenerated
	public partial class Route : RMSEntity
	{


		// @generated
		private int routeNumber;



		// @generated
		private Airport airport;



		// @generated
		private DateTime? schArrDateTime;



		// @generated
		private DateTime? schDepDateTime;



		///<p>Unique sequence number of this route for the flight step</p>
		// @generated
		public int RouteNumber
		{

			get
			{
				return routeNumber;
			}

			set
			{
				SetField(ref routeNumber, value, () => RouteNumber);
			}

		}


	

		///<p>Airport station on this route</p>
		// @generated
		public Airport Airport
		{

			get
			{
				return airport;
			}

			set
			{
				SetField(ref airport, value, () => Airport);
			}

		}


	

		///<p>Scheduled date/time of arrival at this stop</p>
		// @generated
		public DateTime? SchArrDateTime
		{

			get
			{
				return schArrDateTime;
			}

			set
			{
				SetField(ref schArrDateTime, value, () => SchArrDateTime);
			}

		}


	

		///<p>Scheduled date/time of departure at this stop</p>
		// @generated
		public DateTime? SchDepDateTime
		{

			get
			{
				return schDepDateTime;
			}

			set
			{
				SetField(ref schDepDateTime, value, () => SchDepDateTime);
			}

		}



	
	}
	

}



