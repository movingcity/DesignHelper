
using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;





///<p>Entities related to application batch jobs</p>
// @generated
namespace com.unisys.rms.domain.system.batch
{

	
	///<p>Represents an abstract job for the batch scheduler</p>
	// @wasgenerated
	public partial class SchedulerJob : RMSEntity
	{


		// @generated
		private String name;



		// @generated
		private DateTime dataStart;



		// @generated
		private DateTime dataEnd;



		//@wasgenerated
		private string enabled;



		// @generated
		private String schedule;



		// @generated
		private DateTime lastRunStart;



		// @generated
		private DateTime lastRunEnd;



		//@wasgenerated
		private string lastRunStatus;



		// @generated
		private DateTime nextRun;



		//@wasgenerated
		private string jobStatus;



		///<p>The unique name of the job</p>
		// @generated
		public String Name
		{

			get
			{
				return name;
			}

			set
			{
				SetField(ref name, value, () => Name);
			}

		}


	

		///<p>The start date time of data range which will be considered by this job</p>
		// @generated
		public DateTime DataStart
		{

			get
			{
				return dataStart;
			}

			set
			{
				SetField(ref dataStart, value, () => DataStart);
			}

		}


	

		///<p>The end date time of data range which will be considered by this job</p>
		// @generated
		public DateTime DataEnd
		{

			get
			{
				return dataEnd;
			}

			set
			{
				SetField(ref dataEnd, value, () => DataEnd);
			}

		}


	

		///<p>Is job enabled?</p>
		// @generated
		public bool Enabled
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(enabled);
			}

			set
			{
				SetBoolField(ref enabled, value, () => Enabled);
			}

		}


	

		///<p>Scheduling parameters for this job, specified as a CRON style string.</p>
		// @generated
		public String Schedule
		{

			get
			{
				return schedule;
			}

			set
			{
				SetField(ref schedule, value, () => Schedule);
			}

		}


	

		///<p>The start date time of the last run of this job</p>
		// @generated
		public DateTime LastRunStart
		{

			get
			{
				return lastRunStart;
			}

			set
			{
				SetField(ref lastRunStart, value, () => LastRunStart);
			}

		}


	

		///<p>The end date time of the last run of this job</p>
		// @generated
		public DateTime LastRunEnd
		{

			get
			{
				return lastRunEnd;
			}

			set
			{
				SetField(ref lastRunEnd, value, () => LastRunEnd);
			}

		}


	

		///<p>The success status of the last run of the job.<br></br>True value indicates the run was successful.</p>
		// @generated
		public bool LastRunStatus
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(lastRunStatus);
			}

			set
			{
				SetBoolField(ref lastRunStatus, value, () => LastRunStatus);
			}

		}


	

		///<p>The date time of the next scheduled run of this job</p>
		// @generated
		public DateTime NextRun
		{

			get
			{
				return nextRun;
			}

			set
			{
				SetField(ref nextRun, value, () => NextRun);
			}

		}


	

		///<p>The current status of the job</p>
		// @generated
		public JobStatus JobStatus
		{

			get
			{
				return EnumHelper.EnumFromValue<JobStatus>(jobStatus);
			}

			set
			{
				SetEnumField(ref jobStatus, value, () => JobStatus);
			}

		}



	
	}
	

}



