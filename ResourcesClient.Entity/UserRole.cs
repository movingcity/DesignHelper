
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using System;
using com.unisys.rms.domain.criteria;
using com.unisys.rms.domain.system;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>User related entities</p>
// @generated
namespace com.unisys.rms.domain.user
{

	
	///<p>Roles that the user can belong to</p>
	// @wasgenerated
	public partial class UserRole : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		///<p>List of allowed Function roles</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.user.FunctionRole
		private ObservableCollection<FunctionRole> functions;



		///<p>List of allowed Resource roles</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.user.ResourceRole
		private ObservableCollection<ResourceRole> resources;



		// @generated
		private Clause allowFlight;



		//@wasgenerated
		private string enabled;



		///<p>The unique code for this role</p>
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


	

		///<p>Full description for this role</p>
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


	

		///<p>Is flight allowed to user role? A flight will be allowed to a user role if the expression defined here returns True.</p>
		// @generated
		public Clause AllowFlight
		{

			get
			{
				return allowFlight;
			}

			set
			{
				SetField(ref allowFlight, value, () => AllowFlight);
			}

		}


	

		///<p>Is the role enabled? If a role is disabled, all users (even if enabled at user level) will not be allowed access)</p>
		// @generated
		public bool Enabled
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(enabled);
			}

			set
			{
				SetBoolField(ref enabled, value, () => Enabled);
			}

		}



	
	}
	

}



