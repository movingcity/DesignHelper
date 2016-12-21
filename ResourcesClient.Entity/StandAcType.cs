
using com.unisys.rms.domain;
using com.unisys.rms.domain.resource;
using com.unisys.rms.domain.reference;





///<p>Stand resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource.stand
{

	
	///<p>Represents an aircraft type that is allowed for a specific stand.<br></br>One stand can have multiple aircraft types allowed to park. One aircraft type can be parked on multiple stands.</p><p>Note: This entity is separated from Stand entity for performance reasons.</p>
	// @wasgenerated
	public partial class StandAcType : RMSEntity
	{


		// @generated
		private Stand stand;



		// @generated
		private AircraftType acType;



		///<p>The stand where this aircraft type can park.</p>
		// @generated
		public Stand Stand
		{

			get
			{
				return stand;
			}

			set
			{
				SetField(ref stand, value, () => Stand);
			}

		}


	

		///<p>Allowed aircraft type for this Stand</p>
		// @generated
		public AircraftType AcType
		{

			get
			{
				return acType;
			}

			set
			{
				SetField(ref acType, value, () => AcType);
			}

		}



	
	}
	

}



