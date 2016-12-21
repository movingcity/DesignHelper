
using com.unisys.rms.domain;
using System;
using com.unisys.rms.domain.user;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>Records a historical snapshot of confirm/unconfirm actions performed on a Task</p>
	// @wasgenerated
	public partial class ConfirmationHistory : RMSEntity
	{


		// @generated
		private Task task;



		// @generated
		private DateTime dateTime;



		// @generated
		private User user;



		// @generated
		private String registration;



		// @generated
		private String aircraftType;



		//@wasgenerated
		private string type;



		// @generated
		private String resources;



		///<p>The task whose confirmation history this record belongs to</p>
		// @generated
		public Task Task
		{

			get
			{
				return task;
			}

			set
			{
				SetField(ref task, value, () => Task);
			}

		}


	

		///<p>Date and time when confirm/unconfirm was performed</p>
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


	

		///<p>The the user who performed the action</p>
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


	

		///<p>Registration of the flight associated with task at the time of confirmation</p>
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


	

		///<p>IATA aircraft type of the flight associated with task at the time of confirmation</p>
		// @generated
		public String AircraftType
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


	

		///<p>The type of record - confirm, unconfirm, send unconfirm message</p>
		// @generated
		public ConfirmType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<ConfirmType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	

		///<p>Comma separated list of resource codes which were associated with ALL the tasks belonging to the flight associated with this task when confirmed.<br>These codes are restricted to the module to which the task belongs to.<br>List is in time sequence of task occurrence (resource code of earliest task should be first in the list).<br>This list will be BLANK for unconfirm action.</p>
		// @generated
		public String Resources
		{

			get
			{
				return resources;
			}

			set
			{
				SetField(ref resources, value, () => Resources);
			}

		}



	
	}
	

}



