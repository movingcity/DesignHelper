
using com.unisys.rms.domain.task;
using ResourcesClient.Entity.Util;





///<p>Resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource
{

	
	///<p>A gate which is used to embark/disembark passengers for an aircraft.</p><p> If connected directly to aircraft using passenger loading bridge, this is termed contact gate. If leading to an area to bus the passengers to/from a remote stand, this is termed as bus gate.</p><p>One gate may serve multiple stands.</p>
	// @wasgenerated
	public partial class Gate : Resource
	{


		//@wasgenerated
		private string type;



		// @generated
		private int? maxPax;



		// @generated
		private int? concurrent;



		//@wasgenerated
		private string domIntlIndicator;



		///<p>The type of the Gate</p>
		// @generated
		public GateType? Type
		{

			get
			{
				return EnumHelper.EnumFromValue<GateType?>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	

		///<p>Maximum allowed passenger volume</p>
		// @generated
		public int? MaxPax
		{

			get
			{
				return maxPax;
			}

			set
			{
				SetField(ref maxPax, value, () => MaxPax);
			}

		}


	

		///<p>Number of concurrent flights allowed</p>
		// @generated
		public int? Concurrent
		{

			get
			{
				return concurrent;
			}

			set
			{
				SetField(ref concurrent, value, () => Concurrent);
			}

		}


	

		///<p>Gate category - Domestic/International/Both</p>
		// @generated
		public IndicatorType DomIntlIndicator
		{

			get
			{
				return EnumHelper.EnumFromValue<IndicatorType>(domIntlIndicator);
			}

			set
			{
				SetEnumField(ref domIntlIndicator, value, () => DomIntlIndicator);
			}

		}



	
	}
	

}



