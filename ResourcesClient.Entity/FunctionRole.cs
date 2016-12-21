
using com.unisys.rms.domain;
using ResourcesClient.Entity.Util;





///<p>User related entities</p>
// @generated
namespace com.unisys.rms.domain.user
{

	
	///<p>Application function that can be assigned to a user role</p>
	// @wasgenerated
	public partial class FunctionRole : RMSEntity
	{


		// @generated
		private Function function;



		//@wasgenerated
		private string access;



		///<p>The RMS function</p>
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


	

		///<p>What access is allowed for the function</p>
		// @generated
		public AccessRight Access
		{

			get
			{
				return EnumHelper.EnumFromValue<AccessRight>(access);
			}

			set
			{
				SetEnumField(ref access, value, () => Access);
			}

		}



	
	}
	

}



