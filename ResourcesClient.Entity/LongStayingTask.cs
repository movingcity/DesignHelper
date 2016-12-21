
using com.unisys.rms.domain.reference;
using System;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>A type of Stand Task that has no flights associated with it and is manually created to signify a long staying aircraft.</p><p>This is also called as 'Virtual Stand Task'</p><p>The flights attribute of this task HAS TO BE EMPTY.</p>
	// @wasgenerated
	public partial class LongStayingTask : StandTask
	{


		// @generated
		private Airline airline;



		// @generated
		private AircraftType aircraftType;



		// @generated
		private Terminal terminal;



		// @generated
		private String registrationNumber;



		// @generated
		private String flightNumber;



		// @generated
		private String comment;



		///<p>The airline for the long staying task</p>
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


	

		///<p>The aircraft type for the long staying task</p>
		// @generated
		public AircraftType AircraftType
		{

			get
			{
				return aircraftType;
			}

			set
			{
				SetField(ref aircraftType, value, () => AircraftType);
			}

		}


	

		///<p>Long staying task terminal</p>
		// @generated
		public Terminal Terminal
		{

			get
			{
				return terminal;
			}

			set
			{
				SetField(ref terminal, value, () => Terminal);
			}

		}


	

		///<p>The registration number for the long staying task</p>
		// @generated
		public String RegistrationNumber
		{

			get
			{
				return registrationNumber;
			}

			set
			{
				SetField(ref registrationNumber, value, () => RegistrationNumber);
			}

		}


	

		///<p>The flight number for the long staying task</p>
		// @generated
		public String FlightNumber
		{

			get
			{
				return flightNumber;
			}

			set
			{
				SetField(ref flightNumber, value, () => FlightNumber);
			}

		}


	

		///<p>Comments for the long staying task</p>
		// @generated
		public String Comment
		{

			get
			{
				return comment;
			}

			set
			{
				SetField(ref comment, value, () => Comment);
			}

		}



	
	}
	

}



