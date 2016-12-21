
using System.Collections.ObjectModel;
using com.unisys.rms.domain.reference;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource
{

	
	///<p>An aircraft parking position in the airport. </p><p>If served by a passenger boarding bridge, this is termed as a contact stand. If not connected to the terminal and requires bussing of passengers to-from, this is termed as remote stand. This can also be a parking position in the maintenance area.</p>
	// @wasgenerated
	public partial class Stand : Resource
	{


		// @generated
		private Gate intDefaultGate;



		// @generated
		private Gate domDefaultGate;



		// @generated
		private int? width;



		// @generated
		private int? length;



		// @generated
		private int? height;



		//@wasgenerated
		private string type;



		//@wasgenerated
		private string location;



		//@wasgenerated
		private string hasGPU;



		///<p>The default international gate for this Stand</p>
		// @generated
		public Gate IntDefaultGate
		{

			get
			{
				return intDefaultGate;
			}

			set
			{
				SetField(ref intDefaultGate, value, () => IntDefaultGate);
			}

		}


	

		///<p>The default domestic gate for this Stand</p>
		// @generated
		public Gate DomDefaultGate
		{

			get
			{
				return domDefaultGate;
			}

			set
			{
				SetField(ref domDefaultGate, value, () => DomDefaultGate);
			}

		}


	

		///<p>The allowed width for this stand</p>
		// @generated
		public int? Width
		{

			get
			{
				return width;
			}

			set
			{
				SetField(ref width, value, () => Width);
			}

		}


	

		///<p>The allowed length for this stand</p>
		// @generated
		public int? Length
		{

			get
			{
				return length;
			}

			set
			{
				SetField(ref length, value, () => Length);
			}

		}


	

		///<p>The allowed height for this stand</p>
		// @generated
		public int? Height
		{

			get
			{
				return height;
			}

			set
			{
				SetField(ref height, value, () => Height);
			}

		}


	

		///<p>The type of stand</p>
		// @generated
		public StandType? Type
		{

			get
			{
				return EnumHelper.EnumFromValue<StandType?>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	

		///<p>The location of the stand in the airport</p>
		// @generated
		public LocationType? Location
		{

			get
			{
				return EnumHelper.EnumFromValue<LocationType?>(location);
			}

			set
			{
				SetEnumField(ref location, value, () => Location);
			}

		}


	

		///<p>Whether Stand supports Fixed Electric Power Unit</p>
		// @generated
		public bool? HasGPU
		{

			get
			{
				return BoolHelper.BoolFromValue<bool?>(hasGPU);
			}

			set
			{
				SetBoolField(ref hasGPU, value, () => HasGPU);
			}

		}



	
	}
	

}



