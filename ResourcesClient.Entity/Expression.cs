
using com.unisys.rms.domain;





///<p>Criteria related entities</p>
// @generated
namespace com.unisys.rms.domain.criteria
{

	
	///<p>An expression to be used in a clause/criteria. This is a common interface for simple criteria and complex clauses.</p>
	// @generated
	public abstract class Expression : RMSEntity
	{

	
		///<p>Evaluate the expression against the passed entities. Returns true if the passed entities meet the relational expression represented by this entity. </p>
		///<returns></returns><param name="entities"><p>The entities against which expression is to be evaluated. Multiple values and can be empty.</p></param>
		// @wasgenerated
		public abstract bool Evaluate(params object[] entities);
	


	}
	

}



