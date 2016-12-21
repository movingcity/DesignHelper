
using System;





///<p>Flight related entities</p>
// @generated
namespace com.unisys.rms.domain.flight
{

	
	///<p>Return data for the flight record</p>
	// @generated
	public class ReturnData
	{


		// @generated
		private String type;



		// @generated
		private String reason;



		///<p>G = Ground return, A = Air return</p>
		// @generated
		public String Type
		{

			get
			{
				return type;
			}

			set
			{
				type = value;
			}

		}


	

		///<p>Descriptive reason why flight has returned</p>
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



