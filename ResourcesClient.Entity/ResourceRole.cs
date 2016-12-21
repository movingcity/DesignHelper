
using com.unisys.rms.domain;
using com.unisys.rms.domain.resource;
using ResourcesClient.Entity.Util;





///<p>User related entities</p>
// @generated
namespace com.unisys.rms.domain.user
{

	
	///<p>Resources that are allowed for a user role</p>
	// @wasgenerated
	public partial class ResourceRole : RMSEntity
	{


		// @generated
		private Resource resource;



		//@wasgenerated
		private string access;



		///<p>The resource</p>
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


	

		///<p>What access is allowed for the resource</p>
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



