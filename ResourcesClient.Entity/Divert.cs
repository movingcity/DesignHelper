
using com.unisys.rms.domain.reference;
using System;





///<p>Flight related entities</p>
// @generated
namespace com.unisys.rms.domain.flight
{

	
	///<p>Divert information for a flight</p>
	// @generated
	public class Divert
	{


		// @generated
		private Airport airport;



		// @generated
		private String direction;



		// @generated
		private String reason;



		///<p>Divert information for a flight</p>
		// @generated
		public Airport Airport
		{

			get
			{
				return airport;
			}

			set
			{
				airport = value;
			}

		}


	

		///<p>Divert direction. Valid values are TO and FROM</p>
		// @generated
		public String Direction
		{

			get
			{
				return direction;
			}

			set
			{
				direction = value;
			}

		}


	

		///<p>Descriptive reason as to why the flight has been diverted</p>
		// @generated
		public String Reason
		{

			get
			{
				return reason;
			}

			set
			{
				reason = value;
			}

		}



	
	}
	

}



