
using com.unisys.rms.domain;
using System;
using com.unisys.rms.domain.resource;
using ResourcesClient.Entity.Util;





///<p>System entities</p>
// @generated
namespace com.unisys.rms.domain.system
{

	
	///<p>A parameter defined in the system. Can be for the System or for a specific user</p>
	// @wasgenerated
	public partial class Parameter : RMSEntity
	{


		//@wasgenerated
		private string module;



		//@wasgenerated
		private string type;



		// @generated
		private String parameter;



		//@wasgenerated
		private string hasImpact;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		// @generated
		private String value;



		//@wasgenerated
		private string dataType;



		//@wasgenerated
		private string isUpdateable;



		// @generated
		private String defaultValue;



		///<p>The module to which the parameter applies.</p>
		// @generated
		public ParameterModule Module
		{

			get
			{
				return EnumHelper.EnumFromValue<ParameterModule>(module);
			}

			set
			{
				SetEnumField(ref module, value, () => Module);
			}

		}


	

		///<p>The type of parameter - Application or User specific.</p><p>Note: For internal use only. This field distinguishes the system parameters which are default values for user from actual system parameters.</p><p>When a user is created, the User type system parameters are copied to the user parameters list with these default values.</p>
		// @generated
		public ParameterType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<ParameterType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	

		///<p>The data type of this parameter</p>
		// @generated
		public ParameterDataType DataType
		{

			get
			{
				return EnumHelper.EnumFromValue<ParameterDataType>(dataType);
			}

			set
			{
				SetEnumField(ref dataType, value, () => DataType);
			}

		}


	

		///<p>Is the parameter allowed to be updated by user.</p><p>Note: For internal use only. This can be specified for a user specific parameter to indicate if that parameter can be updated by that user.</p><p>Typically, administrative parameters like 'Password Expiry Period' will not be allowed to be updated by a user on their parameters.</p>
		// @generated
		public bool IsUpdateable
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(isUpdateable);
			}

			set
			{
				SetBoolField(ref isUpdateable, value, () => IsUpdateable);
			}

		}


	

		///<p>Whether Application Parameter Impacts Current Resource Allocations.</p><p>Note: User type parameters will NEVER impact Resource allocations.</p>
		// @generated
		public bool HasImpact
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(hasImpact);
			}

			set
			{
				SetBoolField(ref hasImpact, value, () => HasImpact);
			}

		}


	

		///<p>The description of the parameter</p>
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


	

		///<p>The localized description of the parameter</p>
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


	

		///<p>The value of this parameter</p>
		// @generated
		public String Value
		{

			get
			{
				return value;
			}

			set
			{
				SetField(ref this.value, value, () => Value);
			}

		}


	

		///<p>The default value of this parameter.</p><p>When a parameter is created, the value and default value will be the same.</p><p>Subsequent changes to the value will keep the default value constant.</p><p>This value cannot be updated for a parameter and is for internal use only.</p>
		// @generated
		public String DefaultValue
		{

			get
			{
				return defaultValue;
			}

			set
			{
				SetField(ref defaultValue, value, () => DefaultValue);
			}

		}


	

		///<p>The name of the parameter which is being set</p>
		// @generated
		public String ParameterName
		{

			get
			{
				return parameter;
			}

			set
			{
				SetField(ref parameter, value, () => ParameterName);
			}

		}



	
	}
	

}



