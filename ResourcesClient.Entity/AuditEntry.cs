
using com.unisys.rms.domain;
using com.unisys.rms.domain.user;
using System;
using com.unisys.rms.domain.flight;
using com.unisys.rms.domain.task;
using ResourcesClient.Entity.Util;





///<p>System entities</p>
// @generated
namespace com.unisys.rms.domain.system
{

	
	///<p>An audit event logged by the application</p>
	// @wasgenerated
	public partial class AuditEntry : RMSEntity
	{


		// @generated
		private DateTime dateTime;



		// @generated
		private User user;



		// @generated
		private UserSession session;



		// @generated
		private String preEventValue;



		// @generated
		private String postEventValue;



		// @generated
		private Function function;



		//@wasgenerated
		private string module;



		// @generated
		private String entryType;



		// @generated
		private String dataField;



		// @generated
		private String flightNumber;



		// @generated
		private DateTime? sto;



		//@wasgenerated
		private string movementIndicator;



		///<p>The audit function logged</p>
		// @generated
		public Function Function
		{

			get
			{
				return function;
			}

			set
			{
				SetField(ref function, value, () => Function);
			}

		}


	

		///<p>The module name which logged this entry</p>
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


	

		///<p>The date &amp; time when this entry was logged (granularity microseconds)</p>
		// @generated
		public DateTime DateTime
		{

			get
			{
				return dateTime;
			}

			set
			{
				SetField(ref dateTime, value, () => DateTime);
			}

		}


	

		///<p>The type of audit entry. Can be ADD/UPDATE/DELETE or other application defined value</p>
		// @generated
		public String EntryType
		{

			get
			{
				return entryType;
			}

			set
			{
				SetField(ref entryType, value, () => EntryType);
			}

		}


	

		///<p>The user who created the audit entry</p>
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


	

		///<p>The user session who created the audit entry. Can be absent for internal modules which are not logged in.</p>
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


	

		///<p>The data field changed (if present for this audit event)</p>
		// @generated
		public String DataField
		{

			get
			{
				return dataField;
			}

			set
			{
				SetField(ref dataField, value, () => DataField);
			}

		}


	

		///<p>String concatenated value of entities before the event</p>
		// @generated
		public String PreEventValue
		{

			get
			{
				return preEventValue;
			}

			set
			{
				SetField(ref preEventValue, value, () => PreEventValue);
			}

		}


	

		///<p>String concatenated value of entities after the event</p>
		// @generated
		public String PostEventValue
		{

			get
			{
				return postEventValue;
			}

			set
			{
				SetField(ref postEventValue, value, () => PostEventValue);
			}

		}


	

		///<p>Flight Information for the audit entry (if present) - flight number</p>
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


	

		///<p>Flight Information for the audit entry (if present) - scheduled date/time of operation</p>
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


	

		///<p>Flight Information for the audit entry (if present) - Arrival/Departure Indicator</p>
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



