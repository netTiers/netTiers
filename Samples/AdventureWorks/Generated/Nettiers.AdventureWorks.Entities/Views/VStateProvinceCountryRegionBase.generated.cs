﻿/*
	File generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file VStateProvinceCountryRegion.cs instead.
*/
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace Nettiers.AdventureWorks.Entities
{
	///<summary>
	/// Joins StateProvince table with CountryRegion table.
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VStateProvinceCountryRegionBase")]
	public abstract partial class VStateProvinceCountryRegionBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{

		#region Variable Declarations

		/// <summary>
		/// StateProvinceID :
		/// </summary>
		private System.Int32		  _stateProvinceId = (int)0;

		/// <summary>
		/// StateProvinceCode :
		/// </summary>
		private System.String		  _stateProvinceCode = string.Empty;

		/// <summary>
		/// IsOnlyStateProvinceFlag :
		/// </summary>
		private System.Boolean		  _isOnlyStateProvinceFlag = false;

		/// <summary>
		/// StateProvinceName :
		/// </summary>
		private System.String		  _stateProvinceName = string.Empty;

		/// <summary>
		/// TerritoryID :
		/// </summary>
		private System.Int32		  _territoryId = (int)0;

		/// <summary>
		/// CountryRegionCode :
		/// </summary>
		private System.String		  _countryRegionCode = string.Empty;

		/// <summary>
		/// CountryRegionName :
		/// </summary>
		private System.String		  _countryRegionName = string.Empty;

		/// <summary>
		/// Object that contains data to associate with this object
		/// </summary>
		private object _tag;

		/// <summary>
		/// Suppresses Entity Events from Firing,
		/// useful when loading the entities from the database.
		/// </summary>
	    [NonSerialized]
		private bool suppressEntityEvents = false;

		#endregion Variable Declarations

		#region Constructors
		///<summary>
		/// Creates a new <see cref="VStateProvinceCountryRegionBase"/> instance.
		///</summary>
		public VStateProvinceCountryRegionBase()
		{
		}

		///<summary>
		/// Creates a new <see cref="VStateProvinceCountryRegionBase"/> instance.
		///</summary>
		///<param name="_stateProvinceId"></param>
		///<param name="_stateProvinceCode"></param>
		///<param name="_isOnlyStateProvinceFlag"></param>
		///<param name="_stateProvinceName"></param>
		///<param name="_territoryId"></param>
		///<param name="_countryRegionCode"></param>
		///<param name="_countryRegionName"></param>
		public VStateProvinceCountryRegionBase(System.Int32 _stateProvinceId, System.String _stateProvinceCode, System.Boolean _isOnlyStateProvinceFlag, System.String _stateProvinceName, System.Int32 _territoryId, System.String _countryRegionCode, System.String _countryRegionName)
		{
			this._stateProvinceId = _stateProvinceId;
			this._stateProvinceCode = _stateProvinceCode;
			this._isOnlyStateProvinceFlag = _isOnlyStateProvinceFlag;
			this._stateProvinceName = _stateProvinceName;
			this._territoryId = _territoryId;
			this._countryRegionCode = _countryRegionCode;
			this._countryRegionName = _countryRegionName;
		}

		///<summary>
		/// A simple factory method to create a new <see cref="VStateProvinceCountryRegion"/> instance.
		///</summary>
		///<param name="_stateProvinceId"></param>
		///<param name="_stateProvinceCode"></param>
		///<param name="_isOnlyStateProvinceFlag"></param>
		///<param name="_stateProvinceName"></param>
		///<param name="_territoryId"></param>
		///<param name="_countryRegionCode"></param>
		///<param name="_countryRegionName"></param>
		public static VStateProvinceCountryRegion CreateVStateProvinceCountryRegion(System.Int32 _stateProvinceId, System.String _stateProvinceCode, System.Boolean _isOnlyStateProvinceFlag, System.String _stateProvinceName, System.Int32 _territoryId, System.String _countryRegionCode, System.String _countryRegionName)
		{
			VStateProvinceCountryRegion newVStateProvinceCountryRegion = new VStateProvinceCountryRegion();
			newVStateProvinceCountryRegion.StateProvinceId = _stateProvinceId;
			newVStateProvinceCountryRegion.StateProvinceCode = _stateProvinceCode;
			newVStateProvinceCountryRegion.IsOnlyStateProvinceFlag = _isOnlyStateProvinceFlag;
			newVStateProvinceCountryRegion.StateProvinceName = _stateProvinceName;
			newVStateProvinceCountryRegion.TerritoryId = _territoryId;
			newVStateProvinceCountryRegion.CountryRegionCode = _countryRegionCode;
			newVStateProvinceCountryRegion.CountryRegionName = _countryRegionName;
			return newVStateProvinceCountryRegion;
		}

		#endregion Constructors

		#region Properties
		/// <summary>
		/// 	Gets or Sets the StateProvinceID property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 StateProvinceId
		{
			get
			{
				return this._stateProvinceId;
			}
			set
			{
				if (_stateProvinceId == value)
					return;

				this._stateProvinceId = value;
				this._isDirty = true;

				OnPropertyChanged("StateProvinceId");
			}
		}

		/// <summary>
		/// 	Gets or Sets the StateProvinceCode property.
		///
		/// </summary>
		/// <value>This type is nchar</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String StateProvinceCode
		{
			get
			{
				return this._stateProvinceCode;
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "StateProvinceCode does not allow null values.");
				if (_stateProvinceCode == value)
					return;

				this._stateProvinceCode = value;
				this._isDirty = true;

				OnPropertyChanged("StateProvinceCode");
			}
		}

		/// <summary>
		/// 	Gets or Sets the IsOnlyStateProvinceFlag property.
		///
		/// </summary>
		/// <value>This type is bit</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Boolean IsOnlyStateProvinceFlag
		{
			get
			{
				return this._isOnlyStateProvinceFlag;
			}
			set
			{
				if (_isOnlyStateProvinceFlag == value)
					return;

				this._isOnlyStateProvinceFlag = value;
				this._isDirty = true;

				OnPropertyChanged("IsOnlyStateProvinceFlag");
			}
		}

		/// <summary>
		/// 	Gets or Sets the StateProvinceName property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String StateProvinceName
		{
			get
			{
				return this._stateProvinceName;
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "StateProvinceName does not allow null values.");
				if (_stateProvinceName == value)
					return;

				this._stateProvinceName = value;
				this._isDirty = true;

				OnPropertyChanged("StateProvinceName");
			}
		}

		/// <summary>
		/// 	Gets or Sets the TerritoryID property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 TerritoryId
		{
			get
			{
				return this._territoryId;
			}
			set
			{
				if (_territoryId == value)
					return;

				this._territoryId = value;
				this._isDirty = true;

				OnPropertyChanged("TerritoryId");
			}
		}

		/// <summary>
		/// 	Gets or Sets the CountryRegionCode property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CountryRegionCode
		{
			get
			{
				return this._countryRegionCode;
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "CountryRegionCode does not allow null values.");
				if (_countryRegionCode == value)
					return;

				this._countryRegionCode = value;
				this._isDirty = true;

				OnPropertyChanged("CountryRegionCode");
			}
		}

		/// <summary>
		/// 	Gets or Sets the CountryRegionName property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CountryRegionName
		{
			get
			{
				return this._countryRegionName;
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "CountryRegionName does not allow null values.");
				if (_countryRegionName == value)
					return;

				this._countryRegionName = value;
				this._isDirty = true;

				OnPropertyChanged("CountryRegionName");
			}
		}


		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		[System.ComponentModel.Bindable(false)]
		[LocalizableAttribute(false)]
		[DescriptionAttribute("Object containing data to be associated with this object")]
		public virtual object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				if (this._tag == value)
					return;

				this._tag = value;
			}
		}

		/// <summary>
		/// Determines whether this entity is to suppress events while set to true.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool SuppressEntityEvents
		{
			get
			{
				return suppressEntityEvents;
			}
			set
			{
				suppressEntityEvents = value;
			}
		}

		private bool _isDeleted = false;
		/// <summary>
		/// Gets a value indicating if object has been <see cref="MarkToDelete"/>. ReadOnly.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDeleted
		{
			get { return this._isDeleted; }
		}


		private bool _isDirty = false;
		/// <summary>
		///	Gets a value indicating  if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDirty
		{
			get { return this._isDirty; }
		}


		private bool _isNew = true;
		/// <summary>
		///	Gets a value indicating if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsNew
		{
			get { return this._isNew; }
			set { this._isNew = value; }
		}

		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public string ViewName
		{
			get { return "vStateProvinceCountryRegion"; }
		}


		#endregion

		#region Methods

		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		public virtual void AcceptChanges()
		{
			this._isDeleted = false;
			this._isDirty = false;
			this._isNew = false;
			OnPropertyChanged(string.Empty);
		}


		///<summary>
		///  Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public virtual void CancelChanges()
		{
			throw new NotSupportedException("Method currently not Supported.");
		}

		///<summary>
		///   Marks entity to be deleted.
		///</summary>
		public virtual void MarkToDelete()
		{
			this._isDeleted = true;
		}

		#region ICloneable Members
		///<summary>
		///  Returns a Typed VStateProvinceCountryRegionBase Entity
		///</summary>
		public virtual VStateProvinceCountryRegionBase Copy()
		{
			//shallow copy entity
			VStateProvinceCountryRegion copy = new VStateProvinceCountryRegion();
				copy.StateProvinceId = this.StateProvinceId;
				copy.StateProvinceCode = this.StateProvinceCode;
				copy.IsOnlyStateProvinceFlag = this.IsOnlyStateProvinceFlag;
				copy.StateProvinceName = this.StateProvinceName;
				copy.TerritoryId = this.TerritoryId;
				copy.CountryRegionCode = this.CountryRegionCode;
				copy.CountryRegionName = this.CountryRegionName;
			copy.AcceptChanges();
			return (VStateProvinceCountryRegion)copy;
		}

		///<summary>
		/// ICloneable.Clone() Member, returns the Deep Copy of this entity.
		///</summary>
		public object Clone(){
			return this.Copy();
		}

		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		#endregion


		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="VStateProvinceCountryRegionBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VStateProvinceCountryRegionBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}


		///<summary>
		/// Determines whether the specified <see cref="VStateProvinceCountryRegionBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VStateProvinceCountryRegionBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VStateProvinceCountryRegionBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VStateProvinceCountryRegionBase Object1, VStateProvinceCountryRegionBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.StateProvinceId != Object2.StateProvinceId)
				equal = false;
			if (Object1.StateProvinceCode != Object2.StateProvinceCode)
				equal = false;
			if (Object1.IsOnlyStateProvinceFlag != Object2.IsOnlyStateProvinceFlag)
				equal = false;
			if (Object1.StateProvinceName != Object2.StateProvinceName)
				equal = false;
			if (Object1.TerritoryId != Object2.TerritoryId)
				equal = false;
			if (Object1.CountryRegionCode != Object2.CountryRegionCode)
				equal = false;
			if (Object1.CountryRegionName != Object2.CountryRegionName)
				equal = false;
			return equal;
		}

		#endregion

		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region INotifyPropertyChanged Members

		/// <summary>
      /// Event to indicate that a property has changed.
      /// </summary>
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="propertyName">The name of the property that has changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="e">PropertyChangedEventArgs</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (!SuppressEntityEvents)
			{
				if (null != PropertyChanged)
				{
					PropertyChanged(this, e);
				}
			}
		}

		#endregion

		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static object GetPropertyValueByName(VStateProvinceCountryRegion entity, string propertyName)
		{
			switch (propertyName)
			{
				case "StateProvinceId":
					return entity.StateProvinceId;
				case "StateProvinceCode":
					return entity.StateProvinceCode;
				case "IsOnlyStateProvinceFlag":
					return entity.IsOnlyStateProvinceFlag;
				case "StateProvinceName":
					return entity.StateProvinceName;
				case "TerritoryId":
					return entity.TerritoryId;
				case "CountryRegionCode":
					return entity.CountryRegionCode;
				case "CountryRegionName":
					return entity.CountryRegionName;
			}
			return null;
		}

		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public object GetPropertyValueByName(string propertyName)
		{
			return GetPropertyValueByName(this as VStateProvinceCountryRegion, propertyName);
		}

		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{8}{7}- StateProvinceId: {0}{7}- StateProvinceCode: {1}{7}- IsOnlyStateProvinceFlag: {2}{7}- StateProvinceName: {3}{7}- TerritoryId: {4}{7}- CountryRegionCode: {5}{7}- CountryRegionName: {6}{7}",
				this.StateProvinceId,
				this.StateProvinceCode,
				this.IsOnlyStateProvinceFlag,
				this.StateProvinceName,
				this.TerritoryId,
				this.CountryRegionCode,
				this.CountryRegionName,
				System.Environment.NewLine,
				this.GetType());
		}

	}//End Class


	/// <summary>
	/// Enumerate the VStateProvinceCountryRegion columns.
	/// </summary>
	[Serializable]
	public enum VStateProvinceCountryRegionColumn
	{
		/// <summary>
		/// StateProvinceID :
		/// </summary>
		[EnumTextValue("StateProvinceID")]
		[ColumnEnum("StateProvinceID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		StateProvinceId,
		/// <summary>
		/// StateProvinceCode :
		/// </summary>
		[EnumTextValue("StateProvinceCode")]
		[ColumnEnum("StateProvinceCode", typeof(System.String), System.Data.DbType.StringFixedLength, false, false, false, 3)]
		StateProvinceCode,
		/// <summary>
		/// IsOnlyStateProvinceFlag :
		/// </summary>
		[EnumTextValue("IsOnlyStateProvinceFlag")]
		[ColumnEnum("IsOnlyStateProvinceFlag", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, false)]
		IsOnlyStateProvinceFlag,
		/// <summary>
		/// StateProvinceName :
		/// </summary>
		[EnumTextValue("StateProvinceName")]
		[ColumnEnum("StateProvinceName", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		StateProvinceName,
		/// <summary>
		/// TerritoryID :
		/// </summary>
		[EnumTextValue("TerritoryID")]
		[ColumnEnum("TerritoryID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		TerritoryId,
		/// <summary>
		/// CountryRegionCode :
		/// </summary>
		[EnumTextValue("CountryRegionCode")]
		[ColumnEnum("CountryRegionCode", typeof(System.String), System.Data.DbType.String, false, false, false, 3)]
		CountryRegionCode,
		/// <summary>
		/// CountryRegionName :
		/// </summary>
		[EnumTextValue("CountryRegionName")]
		[ColumnEnum("CountryRegionName", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		CountryRegionName
	}//End enum

} // end namespace
