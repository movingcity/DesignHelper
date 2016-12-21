
using com.unisys.rms.domain;
using System;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.system;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>User related entities</p>
// @generated
namespace com.unisys.rms.domain.user
{

	
	///<p>RMS application user</p>
	// @wasgenerated
	public partial class User : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String name;



		// @generated
		private UserRole role;



		// @generated
		private String password;



		//@wasgenerated
		private string enabled;



		//@wasgenerated
		private string deleted;



		///<p>User code</p>
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


	

		///<p>User name/description</p>
		// @generated
		public String Name
		{

			get
			{
				return name;
			}

			set
			{
				SetField(ref name, value, () => Name);
			}

		}


	

		///<p>The roles that this user belongs to</p>
		// @generated
		public UserRole Role
		{

			get
			{
				return role;
			}

			set
			{
				SetField(ref role, value, () => Role);
			}

		}


	

		///<p>User password</p>
		// @generated
		public String Password
		{

			get
			{
				return password;
			}

			set
			{
				SetField(ref password, value, () => Password);
			}

		}


	

		///<p>Account status is enabled</p>
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


	

		///<p>True value indicates entity has been marked for deletion</p>
		// @generated
		public bool Deleted
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(deleted);
			}

			set
			{
				SetBoolField(ref deleted, value, () => Deleted);
			}

		}



	
	}
	

}



