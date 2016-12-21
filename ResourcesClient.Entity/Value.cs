
using System;





///<p>Entities related to grouping of data to be used in the criteria.</p>
// @generated
namespace com.unisys.rms.domain.criteria.group
{

	
	///<p>A value that is contained in the group</p>
	// @wasgenerated
	public partial class Value : Item
	{


		// @generated
		private String value;



		///<p>The actual value that is contained in the group</p>
		// @generated
		public String Val
		{

			get
			{
				return value;
			}

			set
			{
				SetField(ref this.value, value, () => Val);
			}

		}


	
	
		// @generated
		public override bool Contains(String value)
		{
			//TODO: Auto-generated method stub
			throw new System.NotImplementedException();
		}
	


	}
	

}



