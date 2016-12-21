
using System;
using com.unisys.rms.domain.resource;
using com.unisys.rms.domain.reference;





///<p>Allocation template related entities</p>
// @generated
namespace com.unisys.rms.domain.template
{

	
	///<p>Template flight members for Stand module</p>
	// @wasgenerated
	public partial class StandFlightMember : FlightMember
	{


		// @generated
		private String arrFlightNumber;



		// @generated
		private String depFlightNumber;



		// @generated
		private Stand stand;



		///<p>Arrival Flight number for template flight record. One of Arrival or Departure Flight number should at least be present</p>
		// @generated
		public String ArrFlightNumber
		{

			get
			{
				return arrFlightNumber;
			}

			set
			{
				SetField(ref arrFlightNumber, value, () => ArrFlightNumber);
			}

		}


	

		///<p>Departure Flight number for template flight record. One of Arrival or Departure Flight number should at least be present</p>
		// @generated
		public String DepFlightNumber
		{

			get
			{
				return depFlightNumber;
			}

			set
			{
				SetField(ref depFlightNumber, value, () => DepFlightNumber);
			}

		}


	

		///<p>The stand for which the template will be applied</p>
		// @generated
		public Stand Stand
		{

			get
			{
				return stand;
			}

			set
			{
				SetField(ref stand, value, () => Stand);
			}

		}



	
	}
	

}



