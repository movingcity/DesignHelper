
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.user;





///<p>Resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource
{

	
	///<p>List of ResourceGroup entities that are selected for a specified user.<br></br>One user will only have one and only one UserResourceGroup entity (this relationship to be enforced by application).</p><p>Note: This entity is separated from User entity as it is updated independently of the same.</p>
	// @wasgenerated
	public partial class UserResourceGroups : RMSEntity
	{


		// @generated
		private User user;



		///<p>List of Resource Group entities that are selected for the specified user.</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.ResourceGroup
		private ObservableCollection<ResourceGroup> groups;



		///<p>The the user whose resource group selection this entity corresponds to. Will be unique.</p>
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



	
	}
	

}



