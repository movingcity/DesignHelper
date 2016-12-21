


using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using System;
using com.unisys.rms.domain.resource;
using com.unisys.rms.domain.user;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>An abstract Task that can be allocated to resources</p>
	// @wasgenerated
	public abstract partial class Task : RMSEntity
	{


		///<p>Conflicts that may be associated with allocation of this task to a resource</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.task.Conflict
		private ObservableCollection<Conflict> conflicts;



		///<p>Preferences (Cost or Benefit) that may be associated with allocation of this task to a resource</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.task.Preference
		private ObservableCollection<Preference> preferences;



		// @generated
		private DateTime schStart;



		// @generated
		private DateTime schEnd;



		//@wasgenerated
		private string confirmed;



		// @generated
		private Resource resource;



		// @generated
		private User lockUser;



		///<p>Task planned start date/time</p>
		// @generated
		public DateTime SchStart
		{

			get
			{
				return schStart;
			}

			set
			{
				SetField(ref schStart, value, () => SchStart);
			}

		}


	

		///<p>Task planned end date/time</p>
		// @generated
		public DateTime SchEnd
		{

			get
			{
				return schEnd;
			}

			set
			{
				SetField(ref schEnd, value, () => SchEnd);
			}

		}


	

		///<p>Is the allocation confirmed?</p>
		// @generated
		public bool Confirmed
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(confirmed);
			}

			set
			{
				SetBoolField(ref confirmed, value, () => Confirmed);
			}

		}


	

		///<p>The resource to which this task is allocated. Can be blank for tasks which are not allocated currently</p>
		// @generated
		public Resource Resource
		{

			get
			{
				return resource;
			}

			set
			{
				SetField(ref resource, value, () => Resource);
			}

		}


	

		///<p>If this task has been locked by a user. If present, indicates the user who has locked this task</p>
		// @generated
		public User LockUser
		{

			get
			{
				return lockUser;
			}

			set
			{
				SetField(ref lockUser, value, () => LockUser);
			}

		}



	
	}
	

}



