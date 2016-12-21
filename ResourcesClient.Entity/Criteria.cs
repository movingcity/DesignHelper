
using com.unisys.rms.domain.criteria.attribute;
using System;





///<p>Criteria related entities</p>
// @generated
namespace com.unisys.rms.domain.criteria
{

	
	///<p>A simple boolean criteria which evaluates attributes to values based on operators.</p><p>TBD - this entity needs to be rationalized as per the attributes structure being finalized</p>
	// @wasgenerated
	public partial class Criteria : Expression
	{


		// @generated
		private RMSAttribute attribute;



		// @generated
		private Operator critOperator;



		// @generated
		private String value;



		///<p>The attribute for which criteria is checked</p>
		// @generated
		public RMSAttribute Attribute
		{

			get
			{
				return attribute;
			}

			set
			{
				SetField(ref attribute, value, () => Attribute);
			}

		}


	

		///<p>The operator that criteria is checked against</p>
		// @generated
		public Operator CritOperator
		{

			get
			{
				return critOperator;
			}

			set
			{
				SetField(ref critOperator, value, () => CritOperator);
			}

		}


	

		///<p>The value to be operated against</p>
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


	
	
		//@wasgenerated
		public override bool Evaluate(params object[] entities)
		{
			//TODO: Auto-generated method stub
			throw new System.NotImplementedException();
		}
	


	}
	

}



