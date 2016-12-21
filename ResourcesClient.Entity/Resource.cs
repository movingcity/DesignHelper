
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using System;
using com.unisys.rms.domain.reference;
using com.unisys.rms.domain.system;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource
{

	
	///<p>Abstract Airport Resource that can be allocated to a task</p>
	// @wasgenerated
	public abstract partial class Resource : RMSEntity
	{


		// @generated
		private String code;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		// @generated
		private int position;



		// @generated
		private Terminal terminal;



		// @generated
		private int? allocGap;



		// @generated
		private int? conflictGap;



		// @generated
		private Color backColor;



		///<p>list of resources that are physically near selected resource</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.Resource
		private ObservableCollection<Resource> nearbyList;



		// @generated
		private String aodbGroup;



		//@wasgenerated
		private string deleted;



		///<p>The resource code</p>
		// @generated
		public String Code
		{

			get
			{
				return code;
			}

			set
			{
				SetField(ref code, value, () => Code);
			}

		}


	

		///<p>The resource description</p>
		// @generated
		public String Description
		{

			get
			{
				return description;
			}

			set
			{
				SetField(ref description, value, () => Description);
			}

		}


	

		///<p>Localized description of resource</p>
		// @generated
		public String LocalDesc
		{

			get
			{
				return localDesc;
			}

			set
			{
				SetField(ref localDesc, value, () => LocalDesc);
			}

		}


	

		///<p>The position of the resource in the Gantt</p>
		// @generated
		public int Position
		{

			get
			{
				return position;
			}

			set
			{
				SetField(ref position, value, () => Position);
			}

		}


	

		///<p>The terminal to which the resource belongs to (if any)</p>
		// @generated
		public Terminal Terminal
		{

			get
			{
				return terminal;
			}

			set
			{
				SetField(ref terminal, value, () => Terminal);
			}

		}


	

		///<p>Auto allocation time gap required</p>
		// @generated
		public int? AllocGap
		{

			get
			{
				return allocGap;
			}

			set
			{
				SetField(ref allocGap, value, () => AllocGap);
			}

		}


	

		///<p>Time gap required to prevent overlap conflict</p>
		// @generated
		public int? ConflictGap
		{

			get
			{
				return conflictGap;
			}

			set
			{
				SetField(ref conflictGap, value, () => ConflictGap);
			}

		}


	

		///<p>The background color to display for this Resource in the Gantt chart</p>
		// @generated
		public Color BackColor
		{

			get
			{
				return backColor;
			}

			set
			{
				SetField(ref backColor, value, () => BackColor);
			}

		}


	

		///<p>resource grouping identifier sent from AODB</p>
		// @generated
		public String AodbGroup
		{

			get
			{
				return aodbGroup;
			}

			set
			{
				SetField(ref aodbGroup, value, () => AodbGroup);
			}

		}


	

		///<p>True value indicates entity has been marked for deletion</p>
		// @generated
		public bool Deleted
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(deleted);
			}

			set
			{
				SetBoolField(ref deleted, value, () => Deleted);
			}

		}



	
	}
	

}



