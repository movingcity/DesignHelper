
using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;





///<p>User related entities</p>
// @generated
namespace com.unisys.rms.domain.user
{

	
	///<p>User who is currently logged into RMS</p>
	// @wasgenerated
	public partial class UserSession : RMSEntity
	{


		// @generated
		private User user;



		// @generated
		private String ip;



		// @generated
		private long lastTimeStamp;



		//@wasgenerated
		private string active;



		//@wasgenerated
		private string trace;



		// @generated
		private String machineName;



		// @generated
		private DateTime lastLogin;



		///<p>The user who created the session when the logged into the application</p>
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


	

		///<p>User workstation IP address</p>
		// @generated
		public String Ip
		{

			get
			{
				return ip;
			}

			set
			{
				SetField(ref ip, value, () => Ip);
			}

		}


	

		///<p>The workstation/machine name from where user has logged on.</p>
		// @generated
		public String MachineName
		{

			get
			{
				return machineName;
			}

			set
			{
				SetField(ref machineName, value, () => MachineName);
			}

		}


	

		///<p>User last server activity timestamp</p>
		// @generated
		public long LastTimeStamp
		{

			get
			{
				return lastTimeStamp;
			}

			set
			{
				SetField(ref lastTimeStamp, value, () => LastTimeStamp);
			}

		}


	

		///<p>The date time of the login by the user for this session</p>
		// @generated
		public DateTime LastLogin
		{

			get
			{
				return lastLogin;
			}

			set
			{
				SetField(ref lastLogin, value, () => LastLogin);
			}

		}


	

		///<p>Is this session active? Session is inactive when the user logs out</p>
		// @generated
		public bool Active
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(active);
			}

			set
			{
				SetBoolField(ref active, value, () => Active);
			}

		}


	

		///<p>Is trace enabled on this user session? Valid only for active sessions</p>
		// @generated
		public bool Trace
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(trace);
			}

			set
			{
				SetBoolField(ref trace, value, () => Trace);
			}

		}



	
	}
	

}



