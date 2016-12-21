
using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;





///<p>Reference Data entities</p>
// @generated
namespace com.unisys.rms.domain.reference
{

	
	///<p>Handling Agent for the Flight</p>
	// @wasgenerated
	public partial class HandlingAgent : RMSEntity
	{


		// @generated
		private int code;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		//@wasgenerated
		private string isPax;



		//@wasgenerated
		private string isMaint;



		//@wasgenerated
		private string isGround;



		//@wasgenerated
		private string deleted;



		///<p>Organization code of handling agent</p>
		// @generated
		public int Code
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


	

		///<p>Description of handling agent</p>
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


	

		///<p>Localized description of handling agent</p>
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


	

		///<p>Whether this is a passenger handling agent</p>
		// @generated
		public bool IsPax
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(isPax);
			}

			set
			{
				SetBoolField(ref isPax, value, () => IsPax);
			}

		}


	

		///<p>Whether this is a maintenance handling agent</p>
		// @generated
		public bool IsMaint
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(isMaint);
			}

			set
			{
				SetBoolField(ref isMaint, value, () => IsMaint);
			}

		}


	

		///<p>Whether this is a ground handling agent</p>
		// @generated
		public bool IsGround
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(isGround);
			}

			set
			{
				SetBoolField(ref isGround, value, () => IsGround);
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



