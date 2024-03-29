﻿/*
	File generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file VIndividualDemographics.cs instead.
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
	/// Displays the content from each element in the xml column Demographics for each customer in the Sales.Individual table.
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VIndividualDemographicsBase")]
	public abstract partial class VIndividualDemographicsBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{

		#region Variable Declarations

		/// <summary>
		/// CustomerID :
		/// </summary>
		private System.Int32		  _customerId = (int)0;

		/// <summary>
		/// TotalPurchaseYTD :
		/// </summary>
		private System.Decimal?		  _totalPurchaseYtd = null;

		/// <summary>
		/// DateFirstPurchase :
		/// </summary>
		private System.DateTime?		  _dateFirstPurchase = null;

		/// <summary>
		/// BirthDate :
		/// </summary>
		private System.DateTime?		  _birthDate = null;

		/// <summary>
		/// MaritalStatus :
		/// </summary>
		private System.String		  _maritalStatus = null;

		/// <summary>
		/// YearlyIncome :
		/// </summary>
		private System.String		  _yearlyIncome = null;

		/// <summary>
		/// Gender :
		/// </summary>
		private System.String		  _gender = null;

		/// <summary>
		/// TotalChildren :
		/// </summary>
		private System.Int32?		  _totalChildren = null;

		/// <summary>
		/// NumberChildrenAtHome :
		/// </summary>
		private System.Int32?		  _numberChildrenAtHome = null;

		/// <summary>
		/// Education :
		/// </summary>
		private System.String		  _education = null;

		/// <summary>
		/// Occupation :
		/// </summary>
		private System.String		  _occupation = null;

		/// <summary>
		/// HomeOwnerFlag :
		/// </summary>
		private System.Boolean?		  _homeOwnerFlag = null;

		/// <summary>
		/// NumberCarsOwned :
		/// </summary>
		private System.Int32?		  _numberCarsOwned = null;

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
		/// Creates a new <see cref="VIndividualDemographicsBase"/> instance.
		///</summary>
		public VIndividualDemographicsBase()
		{
		}

		///<summary>
		/// Creates a new <see cref="VIndividualDemographicsBase"/> instance.
		///</summary>
		///<param name="_customerId"></param>
		///<param name="_totalPurchaseYtd"></param>
		///<param name="_dateFirstPurchase"></param>
		///<param name="_birthDate"></param>
		///<param name="_maritalStatus"></param>
		///<param name="_yearlyIncome"></param>
		///<param name="_gender"></param>
		///<param name="_totalChildren"></param>
		///<param name="_numberChildrenAtHome"></param>
		///<param name="_education"></param>
		///<param name="_occupation"></param>
		///<param name="_homeOwnerFlag"></param>
		///<param name="_numberCarsOwned"></param>
		public VIndividualDemographicsBase(System.Int32 _customerId, System.Decimal? _totalPurchaseYtd, System.DateTime? _dateFirstPurchase, System.DateTime? _birthDate, System.String _maritalStatus, System.String _yearlyIncome, System.String _gender, System.Int32? _totalChildren, System.Int32? _numberChildrenAtHome, System.String _education, System.String _occupation, System.Boolean? _homeOwnerFlag, System.Int32? _numberCarsOwned)
		{
			this._customerId = _customerId;
			this._totalPurchaseYtd = _totalPurchaseYtd;
			this._dateFirstPurchase = _dateFirstPurchase;
			this._birthDate = _birthDate;
			this._maritalStatus = _maritalStatus;
			this._yearlyIncome = _yearlyIncome;
			this._gender = _gender;
			this._totalChildren = _totalChildren;
			this._numberChildrenAtHome = _numberChildrenAtHome;
			this._education = _education;
			this._occupation = _occupation;
			this._homeOwnerFlag = _homeOwnerFlag;
			this._numberCarsOwned = _numberCarsOwned;
		}

		///<summary>
		/// A simple factory method to create a new <see cref="VIndividualDemographics"/> instance.
		///</summary>
		///<param name="_customerId"></param>
		///<param name="_totalPurchaseYtd"></param>
		///<param name="_dateFirstPurchase"></param>
		///<param name="_birthDate"></param>
		///<param name="_maritalStatus"></param>
		///<param name="_yearlyIncome"></param>
		///<param name="_gender"></param>
		///<param name="_totalChildren"></param>
		///<param name="_numberChildrenAtHome"></param>
		///<param name="_education"></param>
		///<param name="_occupation"></param>
		///<param name="_homeOwnerFlag"></param>
		///<param name="_numberCarsOwned"></param>
		public static VIndividualDemographics CreateVIndividualDemographics(System.Int32 _customerId, System.Decimal? _totalPurchaseYtd, System.DateTime? _dateFirstPurchase, System.DateTime? _birthDate, System.String _maritalStatus, System.String _yearlyIncome, System.String _gender, System.Int32? _totalChildren, System.Int32? _numberChildrenAtHome, System.String _education, System.String _occupation, System.Boolean? _homeOwnerFlag, System.Int32? _numberCarsOwned)
		{
			VIndividualDemographics newVIndividualDemographics = new VIndividualDemographics();
			newVIndividualDemographics.CustomerId = _customerId;
			newVIndividualDemographics.TotalPurchaseYtd = _totalPurchaseYtd;
			newVIndividualDemographics.DateFirstPurchase = _dateFirstPurchase;
			newVIndividualDemographics.BirthDate = _birthDate;
			newVIndividualDemographics.MaritalStatus = _maritalStatus;
			newVIndividualDemographics.YearlyIncome = _yearlyIncome;
			newVIndividualDemographics.Gender = _gender;
			newVIndividualDemographics.TotalChildren = _totalChildren;
			newVIndividualDemographics.NumberChildrenAtHome = _numberChildrenAtHome;
			newVIndividualDemographics.Education = _education;
			newVIndividualDemographics.Occupation = _occupation;
			newVIndividualDemographics.HomeOwnerFlag = _homeOwnerFlag;
			newVIndividualDemographics.NumberCarsOwned = _numberCarsOwned;
			return newVIndividualDemographics;
		}

		#endregion Constructors

		#region Properties
		/// <summary>
		/// 	Gets or Sets the CustomerID property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 CustomerId
		{
			get
			{
				return this._customerId;
			}
			set
			{
				if (_customerId == value)
					return;

				this._customerId = value;
				this._isDirty = true;

				OnPropertyChanged("CustomerId");
			}
		}

		/// <summary>
		/// 	Gets or Sets the TotalPurchaseYTD property.
		///
		/// </summary>
		/// <value>This type is money</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return 0. It is up to the developer
		/// to check the value of IsTotalPurchaseYtdNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Decimal? TotalPurchaseYtd
		{
			get
			{
				return this._totalPurchaseYtd;
			}
			set
			{
				if (_totalPurchaseYtd == value && TotalPurchaseYtd != null )
					return;

				this._totalPurchaseYtd = value;
				this._isDirty = true;

				OnPropertyChanged("TotalPurchaseYtd");
			}
		}

		/// <summary>
		/// 	Gets or Sets the DateFirstPurchase property.
		///
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsDateFirstPurchaseNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? DateFirstPurchase
		{
			get
			{
				return this._dateFirstPurchase;
			}
			set
			{
				if (_dateFirstPurchase == value && DateFirstPurchase != null )
					return;

				this._dateFirstPurchase = value;
				this._isDirty = true;

				OnPropertyChanged("DateFirstPurchase");
			}
		}

		/// <summary>
		/// 	Gets or Sets the BirthDate property.
		///
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsBirthDateNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? BirthDate
		{
			get
			{
				return this._birthDate;
			}
			set
			{
				if (_birthDate == value && BirthDate != null )
					return;

				this._birthDate = value;
				this._isDirty = true;

				OnPropertyChanged("BirthDate");
			}
		}

		/// <summary>
		/// 	Gets or Sets the MaritalStatus property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String MaritalStatus
		{
			get
			{
				return this._maritalStatus;
			}
			set
			{
				if (_maritalStatus == value)
					return;

				this._maritalStatus = value;
				this._isDirty = true;

				OnPropertyChanged("MaritalStatus");
			}
		}

		/// <summary>
		/// 	Gets or Sets the YearlyIncome property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String YearlyIncome
		{
			get
			{
				return this._yearlyIncome;
			}
			set
			{
				if (_yearlyIncome == value)
					return;

				this._yearlyIncome = value;
				this._isDirty = true;

				OnPropertyChanged("YearlyIncome");
			}
		}

		/// <summary>
		/// 	Gets or Sets the Gender property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if (_gender == value)
					return;

				this._gender = value;
				this._isDirty = true;

				OnPropertyChanged("Gender");
			}
		}

		/// <summary>
		/// 	Gets or Sets the TotalChildren property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsTotalChildrenNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? TotalChildren
		{
			get
			{
				return this._totalChildren;
			}
			set
			{
				if (_totalChildren == value && TotalChildren != null )
					return;

				this._totalChildren = value;
				this._isDirty = true;

				OnPropertyChanged("TotalChildren");
			}
		}

		/// <summary>
		/// 	Gets or Sets the NumberChildrenAtHome property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsNumberChildrenAtHomeNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? NumberChildrenAtHome
		{
			get
			{
				return this._numberChildrenAtHome;
			}
			set
			{
				if (_numberChildrenAtHome == value && NumberChildrenAtHome != null )
					return;

				this._numberChildrenAtHome = value;
				this._isDirty = true;

				OnPropertyChanged("NumberChildrenAtHome");
			}
		}

		/// <summary>
		/// 	Gets or Sets the Education property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Education
		{
			get
			{
				return this._education;
			}
			set
			{
				if (_education == value)
					return;

				this._education = value;
				this._isDirty = true;

				OnPropertyChanged("Education");
			}
		}

		/// <summary>
		/// 	Gets or Sets the Occupation property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Occupation
		{
			get
			{
				return this._occupation;
			}
			set
			{
				if (_occupation == value)
					return;

				this._occupation = value;
				this._isDirty = true;

				OnPropertyChanged("Occupation");
			}
		}

		/// <summary>
		/// 	Gets or Sets the HomeOwnerFlag property.
		///
		/// </summary>
		/// <value>This type is bit</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return false. It is up to the developer
		/// to check the value of IsHomeOwnerFlagNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Boolean? HomeOwnerFlag
		{
			get
			{
				return this._homeOwnerFlag;
			}
			set
			{
				if (_homeOwnerFlag == value && HomeOwnerFlag != null )
					return;

				this._homeOwnerFlag = value;
				this._isDirty = true;

				OnPropertyChanged("HomeOwnerFlag");
			}
		}

		/// <summary>
		/// 	Gets or Sets the NumberCarsOwned property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsNumberCarsOwnedNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? NumberCarsOwned
		{
			get
			{
				return this._numberCarsOwned;
			}
			set
			{
				if (_numberCarsOwned == value && NumberCarsOwned != null )
					return;

				this._numberCarsOwned = value;
				this._isDirty = true;

				OnPropertyChanged("NumberCarsOwned");
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
			get { return "vIndividualDemographics"; }
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
		///  Returns a Typed VIndividualDemographicsBase Entity
		///</summary>
		public virtual VIndividualDemographicsBase Copy()
		{
			//shallow copy entity
			VIndividualDemographics copy = new VIndividualDemographics();
				copy.CustomerId = this.CustomerId;
				copy.TotalPurchaseYtd = this.TotalPurchaseYtd;
				copy.DateFirstPurchase = this.DateFirstPurchase;
				copy.BirthDate = this.BirthDate;
				copy.MaritalStatus = this.MaritalStatus;
				copy.YearlyIncome = this.YearlyIncome;
				copy.Gender = this.Gender;
				copy.TotalChildren = this.TotalChildren;
				copy.NumberChildrenAtHome = this.NumberChildrenAtHome;
				copy.Education = this.Education;
				copy.Occupation = this.Occupation;
				copy.HomeOwnerFlag = this.HomeOwnerFlag;
				copy.NumberCarsOwned = this.NumberCarsOwned;
			copy.AcceptChanges();
			return (VIndividualDemographics)copy;
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
		///<returns>true if toObject is a <see cref="VIndividualDemographicsBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VIndividualDemographicsBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}


		///<summary>
		/// Determines whether the specified <see cref="VIndividualDemographicsBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VIndividualDemographicsBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VIndividualDemographicsBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VIndividualDemographicsBase Object1, VIndividualDemographicsBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.CustomerId != Object2.CustomerId)
				equal = false;
			if (Object1.TotalPurchaseYtd != null && Object2.TotalPurchaseYtd != null )
			{
				if (Object1.TotalPurchaseYtd != Object2.TotalPurchaseYtd)
					equal = false;
			}
			else if (Object1.TotalPurchaseYtd == null ^ Object1.TotalPurchaseYtd == null )
			{
				equal = false;
			}
			if (Object1.DateFirstPurchase != null && Object2.DateFirstPurchase != null )
			{
				if (Object1.DateFirstPurchase != Object2.DateFirstPurchase)
					equal = false;
			}
			else if (Object1.DateFirstPurchase == null ^ Object1.DateFirstPurchase == null )
			{
				equal = false;
			}
			if (Object1.BirthDate != null && Object2.BirthDate != null )
			{
				if (Object1.BirthDate != Object2.BirthDate)
					equal = false;
			}
			else if (Object1.BirthDate == null ^ Object1.BirthDate == null )
			{
				equal = false;
			}
			if (Object1.MaritalStatus != null && Object2.MaritalStatus != null )
			{
				if (Object1.MaritalStatus != Object2.MaritalStatus)
					equal = false;
			}
			else if (Object1.MaritalStatus == null ^ Object1.MaritalStatus == null )
			{
				equal = false;
			}
			if (Object1.YearlyIncome != null && Object2.YearlyIncome != null )
			{
				if (Object1.YearlyIncome != Object2.YearlyIncome)
					equal = false;
			}
			else if (Object1.YearlyIncome == null ^ Object1.YearlyIncome == null )
			{
				equal = false;
			}
			if (Object1.Gender != null && Object2.Gender != null )
			{
				if (Object1.Gender != Object2.Gender)
					equal = false;
			}
			else if (Object1.Gender == null ^ Object1.Gender == null )
			{
				equal = false;
			}
			if (Object1.TotalChildren != null && Object2.TotalChildren != null )
			{
				if (Object1.TotalChildren != Object2.TotalChildren)
					equal = false;
			}
			else if (Object1.TotalChildren == null ^ Object1.TotalChildren == null )
			{
				equal = false;
			}
			if (Object1.NumberChildrenAtHome != null && Object2.NumberChildrenAtHome != null )
			{
				if (Object1.NumberChildrenAtHome != Object2.NumberChildrenAtHome)
					equal = false;
			}
			else if (Object1.NumberChildrenAtHome == null ^ Object1.NumberChildrenAtHome == null )
			{
				equal = false;
			}
			if (Object1.Education != null && Object2.Education != null )
			{
				if (Object1.Education != Object2.Education)
					equal = false;
			}
			else if (Object1.Education == null ^ Object1.Education == null )
			{
				equal = false;
			}
			if (Object1.Occupation != null && Object2.Occupation != null )
			{
				if (Object1.Occupation != Object2.Occupation)
					equal = false;
			}
			else if (Object1.Occupation == null ^ Object1.Occupation == null )
			{
				equal = false;
			}
			if (Object1.HomeOwnerFlag != null && Object2.HomeOwnerFlag != null )
			{
				if (Object1.HomeOwnerFlag != Object2.HomeOwnerFlag)
					equal = false;
			}
			else if (Object1.HomeOwnerFlag == null ^ Object1.HomeOwnerFlag == null )
			{
				equal = false;
			}
			if (Object1.NumberCarsOwned != null && Object2.NumberCarsOwned != null )
			{
				if (Object1.NumberCarsOwned != Object2.NumberCarsOwned)
					equal = false;
			}
			else if (Object1.NumberCarsOwned == null ^ Object1.NumberCarsOwned == null )
			{
				equal = false;
			}
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
		public static object GetPropertyValueByName(VIndividualDemographics entity, string propertyName)
		{
			switch (propertyName)
			{
				case "CustomerId":
					return entity.CustomerId;
				case "TotalPurchaseYtd":
					return entity.TotalPurchaseYtd;
				case "DateFirstPurchase":
					return entity.DateFirstPurchase;
				case "BirthDate":
					return entity.BirthDate;
				case "MaritalStatus":
					return entity.MaritalStatus;
				case "YearlyIncome":
					return entity.YearlyIncome;
				case "Gender":
					return entity.Gender;
				case "TotalChildren":
					return entity.TotalChildren;
				case "NumberChildrenAtHome":
					return entity.NumberChildrenAtHome;
				case "Education":
					return entity.Education;
				case "Occupation":
					return entity.Occupation;
				case "HomeOwnerFlag":
					return entity.HomeOwnerFlag;
				case "NumberCarsOwned":
					return entity.NumberCarsOwned;
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
			return GetPropertyValueByName(this as VIndividualDemographics, propertyName);
		}

		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{14}{13}- CustomerId: {0}{13}- TotalPurchaseYtd: {1}{13}- DateFirstPurchase: {2}{13}- BirthDate: {3}{13}- MaritalStatus: {4}{13}- YearlyIncome: {5}{13}- Gender: {6}{13}- TotalChildren: {7}{13}- NumberChildrenAtHome: {8}{13}- Education: {9}{13}- Occupation: {10}{13}- HomeOwnerFlag: {11}{13}- NumberCarsOwned: {12}{13}",
				this.CustomerId,
				(this.TotalPurchaseYtd == null) ? string.Empty : this.TotalPurchaseYtd.ToString(),

				(this.DateFirstPurchase == null) ? string.Empty : this.DateFirstPurchase.ToString(),

				(this.BirthDate == null) ? string.Empty : this.BirthDate.ToString(),

				(this.MaritalStatus == null) ? string.Empty : this.MaritalStatus.ToString(),

				(this.YearlyIncome == null) ? string.Empty : this.YearlyIncome.ToString(),

				(this.Gender == null) ? string.Empty : this.Gender.ToString(),

				(this.TotalChildren == null) ? string.Empty : this.TotalChildren.ToString(),

				(this.NumberChildrenAtHome == null) ? string.Empty : this.NumberChildrenAtHome.ToString(),

				(this.Education == null) ? string.Empty : this.Education.ToString(),

				(this.Occupation == null) ? string.Empty : this.Occupation.ToString(),

				(this.HomeOwnerFlag == null) ? string.Empty : this.HomeOwnerFlag.ToString(),

				(this.NumberCarsOwned == null) ? string.Empty : this.NumberCarsOwned.ToString(),

				System.Environment.NewLine,
				this.GetType());
		}

	}//End Class


	/// <summary>
	/// Enumerate the VIndividualDemographics columns.
	/// </summary>
	[Serializable]
	public enum VIndividualDemographicsColumn
	{
		/// <summary>
		/// CustomerID :
		/// </summary>
		[EnumTextValue("CustomerID")]
		[ColumnEnum("CustomerID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		CustomerId,
		/// <summary>
		/// TotalPurchaseYTD :
		/// </summary>
		[EnumTextValue("TotalPurchaseYTD")]
		[ColumnEnum("TotalPurchaseYTD", typeof(System.Decimal), System.Data.DbType.Currency, false, false, true)]
		TotalPurchaseYtd,
		/// <summary>
		/// DateFirstPurchase :
		/// </summary>
		[EnumTextValue("DateFirstPurchase")]
		[ColumnEnum("DateFirstPurchase", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, true)]
		DateFirstPurchase,
		/// <summary>
		/// BirthDate :
		/// </summary>
		[EnumTextValue("BirthDate")]
		[ColumnEnum("BirthDate", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, true)]
		BirthDate,
		/// <summary>
		/// MaritalStatus :
		/// </summary>
		[EnumTextValue("MaritalStatus")]
		[ColumnEnum("MaritalStatus", typeof(System.String), System.Data.DbType.String, false, false, true, 1)]
		MaritalStatus,
		/// <summary>
		/// YearlyIncome :
		/// </summary>
		[EnumTextValue("YearlyIncome")]
		[ColumnEnum("YearlyIncome", typeof(System.String), System.Data.DbType.String, false, false, true, 30)]
		YearlyIncome,
		/// <summary>
		/// Gender :
		/// </summary>
		[EnumTextValue("Gender")]
		[ColumnEnum("Gender", typeof(System.String), System.Data.DbType.String, false, false, true, 1)]
		Gender,
		/// <summary>
		/// TotalChildren :
		/// </summary>
		[EnumTextValue("TotalChildren")]
		[ColumnEnum("TotalChildren", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		TotalChildren,
		/// <summary>
		/// NumberChildrenAtHome :
		/// </summary>
		[EnumTextValue("NumberChildrenAtHome")]
		[ColumnEnum("NumberChildrenAtHome", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		NumberChildrenAtHome,
		/// <summary>
		/// Education :
		/// </summary>
		[EnumTextValue("Education")]
		[ColumnEnum("Education", typeof(System.String), System.Data.DbType.String, false, false, true, 30)]
		Education,
		/// <summary>
		/// Occupation :
		/// </summary>
		[EnumTextValue("Occupation")]
		[ColumnEnum("Occupation", typeof(System.String), System.Data.DbType.String, false, false, true, 30)]
		Occupation,
		/// <summary>
		/// HomeOwnerFlag :
		/// </summary>
		[EnumTextValue("HomeOwnerFlag")]
		[ColumnEnum("HomeOwnerFlag", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, true)]
		HomeOwnerFlag,
		/// <summary>
		/// NumberCarsOwned :
		/// </summary>
		[EnumTextValue("NumberCarsOwned")]
		[ColumnEnum("NumberCarsOwned", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		NumberCarsOwned
	}//End enum

} // end namespace
