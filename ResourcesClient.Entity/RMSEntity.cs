
using System.ComponentModel;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>RMS Domain model</p>
// @generated
namespace com.unisys.rms.domain
{

	
	///<p>Abstract entity from which all RMS domain entity objects inherit.</p><p>Provides common persistent entity attributes.</p>
	// @wasgenerated
	public abstract class RMSEntity : INotifyPropertyChanging, INotifyPropertyChanged
	{


		// @generated
		[NonSerialized]
		private bool ignorePropertyChangeEvents;



		// @generated
		[NonSerialized]
		private bool isDeleted;



		// @generated
		private long id;



		// @generated
		private long version;



		///<p>Unique identifier for this entity</p><p>READONLY. DO NOT MODIFY FIELD - FOR INTERNAL USE ONLY.</p>
		// @generated
		public long Id
		{

			get
			{
				return id;
			}

			set
			{
				id = value;
			}

		}


	

		///<p>Version of this entity. Used for optimistic locking.</p><p>READONLY. DO NOT MODIFY FIELD - FOR INTERNAL USE ONLY.</p>
		// @generated
		public long Version
		{

			get
			{
				return version;
			}

			set
			{
				version = value;
			}

		}


	

		///<p>Whether the view model should ignore property-change events.</p>
		// @generated
		public virtual bool IgnorePropertyChangeEvents
		{

			get
			{
				return ignorePropertyChangeEvents;
			}

			set
			{
				ignorePropertyChangeEvents = value;
			}

		}


	

		///<p>For INTERNAL FRAMEWORK USE ONLY.<br></br>Indicates that this entity has been marked for deletion by the framework and should not be used by the client.</p><p>When this property is (or becomes true), application should take steps to remove this entity from the relevant view.</p>
		// @generated
		public bool IsDeleted
		{

			get
			{
				return isDeleted;
			}

			set
			{
				SetField(ref isDeleted, value, () => IsDeleted);
			}

		}


	

		// @generated
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;


	

		// @generated
		[field:NonSerialized]
		public event PropertyChangingEventHandler PropertyChanging;


	
	
#region Code added after generation

        #region Propery Notification Changes

		///<summary>
		/// Raises the PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The name of the changed property.</param>
		public virtual void RaisePropertyChangedEvent(string propertyName)
		{
			// Exit if changes ignored
            if (IgnorePropertyChangeEvents) return;

            // Exit if no subscribers
            if (PropertyChanged == null) return;

            // Raise event
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged(this, e);
		}
	

	
		///<summary>
		/// Raises the PropertyChanging event.
		/// </summary>
		/// <param name="propertyName">The name of the changing property.</param>
		public virtual void RaisePropertyChangingEvent(string propertyName)
		{
			// Exit if changes ignored
            if (IgnorePropertyChangeEvents) return;

            // Exit if no subscribers
            if (PropertyChanging == null) return;

            // Raise event
            var e = new PropertyChangingEventArgs(propertyName);
            PropertyChanging(this, e);
		}
	

	
		//interal setter method - supports different types for field and property (required for Enum and Bool)
		private bool SetFieldInternal<T, U>(ref T field, T value, Expression<Func<U>> selectorExpression)
		{
			if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");

            MemberExpression body = selectorExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The body must be a member expression");

            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            RaisePropertyChangingEvent(body.Member.Name);
            field = value;
            RaisePropertyChangedEvent(body.Member.Name);
            return true;
		}
	

	
		///<summary>
		/// Helper method to raise property changed event for a property
		/// setter.
		/// </summary>
		/// <typeparam name="T">Type of property</typeparam>
		/// <param name="field">The backing field to be set</param>
		/// <param name="value">The value to be set to</param>
		/// <param name="selectorExpression">() => [property name]</param>
		/// <returns></returns>
		protected bool SetField<T>(ref T field, T value, Expression<Func<T>> selectorExpression)
		{
			return SetFieldInternal(ref field, value, selectorExpression);
		}
	

	
		///<summary>
		/// Helper method to raise property changed event for a Enum property
		/// setter.
		/// </summary>
		/// <typeparam name="T">Type of property</typeparam>
		/// <param name="field">The backing field to be set</param>
		/// <param name="value">The value to be set to</param>
		/// <param name="selectorExpression">() => [property name]</param>
		/// <returns></returns>
		protected bool SetEnumField<T>(ref string field, T value, Expression<Func<T>> selectorExpression)
		{
			string stringValue = EnumHelper.ValueFromEnum(value);
            return SetFieldInternal(ref field, stringValue, selectorExpression);
		}
	

	
		///<summary>
		/// Helper method to raise property changed event for a Boolean property
		/// setter.
		/// </summary>
		/// <typeparam name="T">Type of property</typeparam>
		/// <param name="field">The backing field to be set</param>
		/// <param name="value">The value to be set to</param>
		/// <param name="selectorExpression">() => [property name]</param>
		/// <returns></returns>
		protected bool SetBoolField<T>(ref string field, T value, Expression<Func<T>> selectorExpression)
		{
			string stringValue = BoolHelper.ValueFromBool(value);
            return SetFieldInternal(ref field, stringValue, selectorExpression);
		}
	

	
#endregion

        #region Equals

		public override bool Equals(object o)
		{
			if (o == null)
            {
                return false;
            }
            // check concerte instances match
            if (this.GetType() != o.GetType())
            {
                return false;
            }
            RMSEntity other = o as RMSEntity;
            // if id is zero, then indicates entity not persisted
            // perform object reference match for equality
            if (this.Id == 0)
            {
                return this == other;
            }
            // true if id matches
            return this.Id == other.Id;
		}
	

	
		public override int GetHashCode()
		{
			int result = 17;
            result = 37 * result + (int)(id ^ (uint)(((ulong)id) >> 32));
            result = 37 * result + GetType().FullName.GetHashCode();
            return result;
		}
	#endregion


        #endregion


	}
	

}



