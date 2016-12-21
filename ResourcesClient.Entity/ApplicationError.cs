
using com.unisys.rms.domain;
using com.unisys.rms.domain.user;
using System;
using com.unisys.rms.domain.flight;
using ResourcesClient.Entity.Util;





///<p>System entities</p>
// @generated
namespace com.unisys.rms.domain.system
{

	
	///<p>Represents an instance of a critical application error.</p>
	// @wasgenerated
	public partial class ApplicationError : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private long timeStamp;



		// @generated
		private User user;



		// @generated
		private UserSession session;



		// @generated
		private String errorText;



		// @generated
		private String contextText;



		// @generated
		private String flightNumber;



		// @generated
		private DateTime? sto;



		//@wasgenerated
		private string movementIndicator;



		///<p>Module which is logging critical error</p>
		// @generated
		public ModuleName Module
		{

			get
			{
				return EnumHelper.EnumFromValue<ModuleName>(module);
			}

			set
			{
				SetEnumField(ref module, value, () => Module);
			}

		}


	

		///<p>Error occurrence time</p>
		// @generated
		public long TimeStamp
		{

			get
			{
				return timeStamp;
			}

			set
			{
				SetField(ref timeStamp, value, () => TimeStamp);
			}

		}


	

		///<p>The user associated with the error entry</p>
		// @generated
		public User User
		{

			get
			{
				return user;
			}

			set
			{
				SetField(ref user, value, () => User);
			}

		}


	

		///<p>The user session who created the error entry. Can be absent for internal modules which are not logged in.</p>
		// @generated
		public UserSession Session
		{

			get
			{
				return session;
			}

			set
			{
				SetField(ref session, value, () => Session);
			}

		}


	

		///<p>Application error detail text</p>
		// @generated
		public String ErrorText
		{

			get
			{
				return errorText;
			}

			set
			{
				SetField(ref errorText, value, () => ErrorText);
			}

		}


	

		///<p>Contextual error information (stack trace, etc)</p>
		// @generated
		public String ContextText
		{

			get
			{
				return contextText;
			}

			set
			{
				SetField(ref contextText, value, () => ContextText);
			}

		}


	

		///<p>Flight Information for the error entry (if present) - flight number</p>
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


	

		///<p>Flight Information for the error entry (if present) - scheduled date/time of operation</p>
		// @generated
		public DateTime? Sto
		{

			get
			{
				return sto;
			}

			set
			{
				SetField(ref sto, value, () => Sto);
			}

		}


	

		///<p>Flight Information for the error entry (if present) - Arrival/Departure Indicator</p>
		// @generated
		public MovementType? MovementIndicator
		{

			get
			{
				return EnumHelper.EnumFromValue<MovementType?>(movementIndicator);
			}

			set
			{
				SetEnumField(ref movementIndicator, value, () => MovementIndicator);
			}

		}



	
	}
	

}



