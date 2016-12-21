
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Criteria related entities</p>
// @generated
namespace com.unisys.rms.domain.criteria
{

	
	///<p>A clause that applies a boolean operator to a set of criteria entities</p>
	// @wasgenerated
	public partial class Clause : Expression
	{


		///<p>The expressions in the clause</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.criteria.Expression
		private ObservableCollection<Expression> expressions;



		//@wasgenerated
		private string boolOperator;



		// @generated
		private Query query;



		// @generated
		private Rule rule;



		///<p>The boolean operator to be used to combine the expressions</p>
		// @generated
		public ClauseOperator BoolOperator
		{

			get
			{
				return EnumHelper.EnumFromValue<ClauseOperator>(boolOperator);
			}

			set
			{
				SetEnumField(ref boolOperator, value, () => BoolOperator);
			}

		}


	

		///<p>Query that this clause belongs to (if any)</p>
		// @generated
		public Query Query
		{

			get
			{
				return query;
			}

			set
			{
				SetField(ref query, value, () => Query);
			}

		}


	

		///<p>Rule that this clause belongs to (if any)</p>
		// @generated
		public Rule Rule
		{

			get
			{
				return rule;
			}

			set
			{
				SetField(ref rule, value, () => Rule);
			}

		}


	
	
		//@wasgenerated
		public override bool Evaluate(params object[] entities)
		{
			//TODO: Auto-generated method stub
			throw new System.NotImplementedException();
		}
	


	}
	

}



