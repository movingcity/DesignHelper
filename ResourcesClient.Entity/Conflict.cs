
using com.unisys.rms.domain;
using com.unisys.rms.domain.criteria;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>Represents a conflict in the allocation of a Task to a Resource. Conflicts are generated by evaluating Mandatory Rules. One conflict will be generated by one Rule.</p><p>For Gate module, conflicts can also be generated by GateExceptionRule.</p><p>Conflicts are contained in Tasks and do not have any independent existence.</p>
	// @wasgenerated
	public partial class Conflict : RMSEntity
	{


		// @generated
		private Rule rule;



		// @generated
		private Task task;



		// @generated
		private GateExceptionRule gateRule;



		///<p>The Task to which this conflict belongs</p>
		// @generated
		public Task Task
		{

			get
			{
				return task;
			}

			set
			{
				SetField(ref task, value, () => Task);
			}

		}


	

		///<p>The rule that generated this conflict. Only mandatory rules are allowed.</p><p>Mandatory for all modules other than Gate.</p>
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


	

		///<p>The gate exception rule that generated this conflict. Either gateRule or rule is mandatory for the conflict.</p><p>This field is valid only for Gate module.</p>
		// @generated
		public GateExceptionRule GateRule
		{

			get
			{
				return gateRule;
			}

			set
			{
				SetField(ref gateRule, value, () => GateRule);
			}

		}



	
	}
	

}



