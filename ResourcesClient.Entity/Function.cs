
using com.unisys.rms.domain;
using System;
using com.unisys.rms.domain.system;
using ResourcesClient.Entity.Util;





///<p>User related entities</p>
// @generated
namespace com.unisys.rms.domain.user
{

	
	///<p>Application function.</p><p>User invokable functions can be assigned to a user function role.</p><p>These functions also represent an event that can be audited by the application.</p>
	// @wasgenerated
	public partial class Function : RMSEntity
	{


		// @generated
		private String name;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		//@wasgenerated
		private string userInvoked;



		//@wasgenerated
		private string auditEnabled;



		//@wasgenerated
		private string auditDataCapture;



		///<p>Name of the RMS function</p>
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


	

		///<p>Description of the RMS function</p>
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


	

		///<p>Localized description of the function</p>
		// @generated
		public String LocalDesc
		{

			get
			{
				return localDesc;
			}

			set
			{
				SetField(ref localDesc, value, () => LocalDesc);
			}

		}


	

		///<p>Is this RMS function invoked by the user.</p><p>False value indicates that this function is for auditing reasons only and not for access control.</p><p>Only user invoked functions are used in Function roles.</p>
		// @generated
		public bool UserInvoked
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(userInvoked);
			}

			set
			{
				SetBoolField(ref userInvoked, value, () => UserInvoked);
			}

		}


	

		///<p>Is audit enabled for this function?</p>
		// @generated
		public bool AuditEnabled
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(auditEnabled);
			}

			set
			{
				SetBoolField(ref auditEnabled, value, () => AuditEnabled);
			}

		}


	

		///<p>The type of audit data capture for this function.</p>
		// @generated
		public DataCaptureType AuditDataCapture
		{

			get
			{
				return EnumHelper.EnumFromValue<DataCaptureType>(auditDataCapture);
			}

			set
			{
				SetEnumField(ref auditDataCapture, value, () => AuditDataCapture);
			}

		}



	
	}
	

}



