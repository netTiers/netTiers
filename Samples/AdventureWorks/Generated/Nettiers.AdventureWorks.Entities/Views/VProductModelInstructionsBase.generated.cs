﻿/*
	File generated by NetTiers templates [https://github.com/netTiers/netTiers]
	Important: Do not modify this file. Edit the file VProductModelInstructions.cs instead.
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
	/// Displays the content from each element in the xml column Instructions for each product in the Production.ProductModel table that has manufacturing instructions.
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VProductModelInstructionsBase")]
	public abstract partial class VProductModelInstructionsBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{

		#region Variable Declarations

		/// <summary>
		/// ProductModelID :
		/// </summary>
		private System.Int32		  _productModelId = (int)0;

		/// <summary>
		/// Name :
		/// </summary>
		private System.String		  _name = string.Empty;

		/// <summary>
		/// Instructions :
		/// </summary>
		private System.String		  _instructions = null;

		/// <summary>
		/// LocationID :
		/// </summary>
		private System.Int32?		  _locationId = null;

		/// <summary>
		/// SetupHours :
		/// </summary>
		private System.Decimal?		  _setupHours = null;

		/// <summary>
		/// MachineHours :
		/// </summary>
		private System.Decimal?		  _machineHours = null;

		/// <summary>
		/// LaborHours :
		/// </summary>
		private System.Decimal?		  _laborHours = null;

		/// <summary>
		/// LotSize :
		/// </summary>
		private System.Int32?		  _lotSize = null;

		/// <summary>
		/// Step :
		/// </summary>
		private System.String		  _step = null;

		/// <summary>
		/// rowguid :
		/// </summary>
		private System.Guid		  _rowguid = Guid.Empty;

		/// <summary>
		/// ModifiedDate :
		/// </summary>
		private System.DateTime		  _modifiedDate = DateTime.MinValue;

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
		/// Creates a new <see cref="VProductModelInstructionsBase"/> instance.
		///</summary>
		public VProductModelInstructionsBase()
		{
		}

		///<summary>
		/// Creates a new <see cref="VProductModelInstructionsBase"/> instance.
		///</summary>
		///<param name="_productModelId"></param>
		///<param name="_name"></param>
		///<param name="_instructions"></param>
		///<param name="_locationId"></param>
		///<param name="_setupHours"></param>
		///<param name="_machineHours"></param>
		///<param name="_laborHours"></param>
		///<param name="_lotSize"></param>
		///<param name="_step"></param>
		///<param name="_rowguid"></param>
		///<param name="_modifiedDate"></param>
		public VProductModelInstructionsBase(System.Int32 _productModelId, System.String _name, System.String _instructions, System.Int32? _locationId, System.Decimal? _setupHours, System.Decimal? _machineHours, System.Decimal? _laborHours, System.Int32? _lotSize, System.String _step, System.Guid _rowguid, System.DateTime _modifiedDate)
		{
			this._productModelId = _productModelId;
			this._name = _name;
			this._instructions = _instructions;
			this._locationId = _locationId;
			this._setupHours = _setupHours;
			this._machineHours = _machineHours;
			this._laborHours = _laborHours;
			this._lotSize = _lotSize;
			this._step = _step;
			this._rowguid = _rowguid;
			this._modifiedDate = _modifiedDate;
		}

		///<summary>
		/// A simple factory method to create a new <see cref="VProductModelInstructions"/> instance.
		///</summary>
		///<param name="_productModelId"></param>
		///<param name="_name"></param>
		///<param name="_instructions"></param>
		///<param name="_locationId"></param>
		///<param name="_setupHours"></param>
		///<param name="_machineHours"></param>
		///<param name="_laborHours"></param>
		///<param name="_lotSize"></param>
		///<param name="_step"></param>
		///<param name="_rowguid"></param>
		///<param name="_modifiedDate"></param>
		public static VProductModelInstructions CreateVProductModelInstructions(System.Int32 _productModelId, System.String _name, System.String _instructions, System.Int32? _locationId, System.Decimal? _setupHours, System.Decimal? _machineHours, System.Decimal? _laborHours, System.Int32? _lotSize, System.String _step, System.Guid _rowguid, System.DateTime _modifiedDate)
		{
			VProductModelInstructions newVProductModelInstructions = new VProductModelInstructions();
			newVProductModelInstructions.ProductModelId = _productModelId;
			newVProductModelInstructions.Name = _name;
			newVProductModelInstructions.Instructions = _instructions;
			newVProductModelInstructions.LocationId = _locationId;
			newVProductModelInstructions.SetupHours = _setupHours;
			newVProductModelInstructions.MachineHours = _machineHours;
			newVProductModelInstructions.LaborHours = _laborHours;
			newVProductModelInstructions.LotSize = _lotSize;
			newVProductModelInstructions.Step = _step;
			newVProductModelInstructions.Rowguid = _rowguid;
			newVProductModelInstructions.ModifiedDate = _modifiedDate;
			return newVProductModelInstructions;
		}

		#endregion Constructors

		#region Properties
		/// <summary>
		/// 	Gets or Sets the ProductModelID property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 ProductModelId
		{
			get
			{
				return this._productModelId;
			}
			set
			{
				if (_productModelId == value)
					return;

				this._productModelId = value;
				this._isDirty = true;

				OnPropertyChanged("ProductModelId");
			}
		}

		/// <summary>
		/// 	Gets or Sets the Name property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "Name does not allow null values.");
				if (_name == value)
					return;

				this._name = value;
				this._isDirty = true;

				OnPropertyChanged("Name");
			}
		}

		/// <summary>
		/// 	Gets or Sets the Instructions property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Instructions
		{
			get
			{
				return this._instructions;
			}
			set
			{
				if (_instructions == value)
					return;

				this._instructions = value;
				this._isDirty = true;

				OnPropertyChanged("Instructions");
			}
		}

		/// <summary>
		/// 	Gets or Sets the LocationID property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsLocationIdNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? LocationId
		{
			get
			{
				return this._locationId;
			}
			set
			{
				if (_locationId == value && LocationId != null )
					return;

				this._locationId = value;
				this._isDirty = true;

				OnPropertyChanged("LocationId");
			}
		}

		/// <summary>
		/// 	Gets or Sets the SetupHours property.
		///
		/// </summary>
		/// <value>This type is decimal</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return 0.0m. It is up to the developer
		/// to check the value of IsSetupHoursNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Decimal? SetupHours
		{
			get
			{
				return this._setupHours;
			}
			set
			{
				if (_setupHours == value && SetupHours != null )
					return;

				this._setupHours = value;
				this._isDirty = true;

				OnPropertyChanged("SetupHours");
			}
		}

		/// <summary>
		/// 	Gets or Sets the MachineHours property.
		///
		/// </summary>
		/// <value>This type is decimal</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return 0.0m. It is up to the developer
		/// to check the value of IsMachineHoursNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Decimal? MachineHours
		{
			get
			{
				return this._machineHours;
			}
			set
			{
				if (_machineHours == value && MachineHours != null )
					return;

				this._machineHours = value;
				this._isDirty = true;

				OnPropertyChanged("MachineHours");
			}
		}

		/// <summary>
		/// 	Gets or Sets the LaborHours property.
		///
		/// </summary>
		/// <value>This type is decimal</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return 0.0m. It is up to the developer
		/// to check the value of IsLaborHoursNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Decimal? LaborHours
		{
			get
			{
				return this._laborHours;
			}
			set
			{
				if (_laborHours == value && LaborHours != null )
					return;

				this._laborHours = value;
				this._isDirty = true;

				OnPropertyChanged("LaborHours");
			}
		}

		/// <summary>
		/// 	Gets or Sets the LotSize property.
		///
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null.
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsLotSizeNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? LotSize
		{
			get
			{
				return this._lotSize;
			}
			set
			{
				if (_lotSize == value && LotSize != null )
					return;

				this._lotSize = value;
				this._isDirty = true;

				OnPropertyChanged("LotSize");
			}
		}

		/// <summary>
		/// 	Gets or Sets the Step property.
		///
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Step
		{
			get
			{
				return this._step;
			}
			set
			{
				if (_step == value)
					return;

				this._step = value;
				this._isDirty = true;

				OnPropertyChanged("Step");
			}
		}

		/// <summary>
		/// 	Gets or Sets the rowguid property.
		///
		/// </summary>
		/// <value>This type is uniqueidentifier</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Guid Rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if (_rowguid == value)
					return;

				this._rowguid = value;
				this._isDirty = true;

				OnPropertyChanged("Rowguid");
			}
		}

		/// <summary>
		/// 	Gets or Sets the ModifiedDate property.
		///
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can not be set to null.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime ModifiedDate
		{
			get
			{
				return this._modifiedDate;
			}
			set
			{
				if (_modifiedDate == value)
					return;

				this._modifiedDate = value;
				this._isDirty = true;

				OnPropertyChanged("ModifiedDate");
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
			get { return "vProductModelInstructions"; }
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
		///  Returns a Typed VProductModelInstructionsBase Entity
		///</summary>
		public virtual VProductModelInstructionsBase Copy()
		{
			//shallow copy entity
			VProductModelInstructions copy = new VProductModelInstructions();
				copy.ProductModelId = this.ProductModelId;
				copy.Name = this.Name;
				copy.Instructions = this.Instructions;
				copy.LocationId = this.LocationId;
				copy.SetupHours = this.SetupHours;
				copy.MachineHours = this.MachineHours;
				copy.LaborHours = this.LaborHours;
				copy.LotSize = this.LotSize;
				copy.Step = this.Step;
				copy.Rowguid = this.Rowguid;
				copy.ModifiedDate = this.ModifiedDate;
			copy.AcceptChanges();
			return (VProductModelInstructions)copy;
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
		///<returns>true if toObject is a <see cref="VProductModelInstructionsBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VProductModelInstructionsBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}


		///<summary>
		/// Determines whether the specified <see cref="VProductModelInstructionsBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VProductModelInstructionsBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VProductModelInstructionsBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VProductModelInstructionsBase Object1, VProductModelInstructionsBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.ProductModelId != Object2.ProductModelId)
				equal = false;
			if (Object1.Name != Object2.Name)
				equal = false;
			if (Object1.Instructions != null && Object2.Instructions != null )
			{
				if (Object1.Instructions != Object2.Instructions)
					equal = false;
			}
			else if (Object1.Instructions == null ^ Object1.Instructions == null )
			{
				equal = false;
			}
			if (Object1.LocationId != null && Object2.LocationId != null )
			{
				if (Object1.LocationId != Object2.LocationId)
					equal = false;
			}
			else if (Object1.LocationId == null ^ Object1.LocationId == null )
			{
				equal = false;
			}
			if (Object1.SetupHours != null && Object2.SetupHours != null )
			{
				if (Object1.SetupHours != Object2.SetupHours)
					equal = false;
			}
			else if (Object1.SetupHours == null ^ Object1.SetupHours == null )
			{
				equal = false;
			}
			if (Object1.MachineHours != null && Object2.MachineHours != null )
			{
				if (Object1.MachineHours != Object2.MachineHours)
					equal = false;
			}
			else if (Object1.MachineHours == null ^ Object1.MachineHours == null )
			{
				equal = false;
			}
			if (Object1.LaborHours != null && Object2.LaborHours != null )
			{
				if (Object1.LaborHours != Object2.LaborHours)
					equal = false;
			}
			else if (Object1.LaborHours == null ^ Object1.LaborHours == null )
			{
				equal = false;
			}
			if (Object1.LotSize != null && Object2.LotSize != null )
			{
				if (Object1.LotSize != Object2.LotSize)
					equal = false;
			}
			else if (Object1.LotSize == null ^ Object1.LotSize == null )
			{
				equal = false;
			}
			if (Object1.Step != null && Object2.Step != null )
			{
				if (Object1.Step != Object2.Step)
					equal = false;
			}
			else if (Object1.Step == null ^ Object1.Step == null )
			{
				equal = false;
			}
			if (Object1.Rowguid != Object2.Rowguid)
				equal = false;
			if (Object1.ModifiedDate != Object2.ModifiedDate)
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
		public static object GetPropertyValueByName(VProductModelInstructions entity, string propertyName)
		{
			switch (propertyName)
			{
				case "ProductModelId":
					return entity.ProductModelId;
				case "Name":
					return entity.Name;
				case "Instructions":
					return entity.Instructions;
				case "LocationId":
					return entity.LocationId;
				case "SetupHours":
					return entity.SetupHours;
				case "MachineHours":
					return entity.MachineHours;
				case "LaborHours":
					return entity.LaborHours;
				case "LotSize":
					return entity.LotSize;
				case "Step":
					return entity.Step;
				case "Rowguid":
					return entity.Rowguid;
				case "ModifiedDate":
					return entity.ModifiedDate;
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
			return GetPropertyValueByName(this as VProductModelInstructions, propertyName);
		}

		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{12}{11}- ProductModelId: {0}{11}- Name: {1}{11}- Instructions: {2}{11}- LocationId: {3}{11}- SetupHours: {4}{11}- MachineHours: {5}{11}- LaborHours: {6}{11}- LotSize: {7}{11}- Step: {8}{11}- Rowguid: {9}{11}- ModifiedDate: {10}{11}",
				this.ProductModelId,
				this.Name,
				(this.Instructions == null) ? string.Empty : this.Instructions.ToString(),

				(this.LocationId == null) ? string.Empty : this.LocationId.ToString(),

				(this.SetupHours == null) ? string.Empty : this.SetupHours.ToString(),

				(this.MachineHours == null) ? string.Empty : this.MachineHours.ToString(),

				(this.LaborHours == null) ? string.Empty : this.LaborHours.ToString(),

				(this.LotSize == null) ? string.Empty : this.LotSize.ToString(),

				(this.Step == null) ? string.Empty : this.Step.ToString(),

				this.Rowguid,
				this.ModifiedDate,
				System.Environment.NewLine,
				this.GetType());
		}

	}//End Class


	/// <summary>
	/// Enumerate the VProductModelInstructions columns.
	/// </summary>
	[Serializable]
	public enum VProductModelInstructionsColumn
	{
		/// <summary>
		/// ProductModelID :
		/// </summary>
		[EnumTextValue("ProductModelID")]
		[ColumnEnum("ProductModelID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		ProductModelId,
		/// <summary>
		/// Name :
		/// </summary>
		[EnumTextValue("Name")]
		[ColumnEnum("Name", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		Name,
		/// <summary>
		/// Instructions :
		/// </summary>
		[EnumTextValue("Instructions")]
		[ColumnEnum("Instructions", typeof(System.String), System.Data.DbType.String, false, false, true)]
		Instructions,
		/// <summary>
		/// LocationID :
		/// </summary>
		[EnumTextValue("LocationID")]
		[ColumnEnum("LocationID", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		LocationId,
		/// <summary>
		/// SetupHours :
		/// </summary>
		[EnumTextValue("SetupHours")]
		[ColumnEnum("SetupHours", typeof(System.Decimal), System.Data.DbType.Decimal, false, false, true)]
		SetupHours,
		/// <summary>
		/// MachineHours :
		/// </summary>
		[EnumTextValue("MachineHours")]
		[ColumnEnum("MachineHours", typeof(System.Decimal), System.Data.DbType.Decimal, false, false, true)]
		MachineHours,
		/// <summary>
		/// LaborHours :
		/// </summary>
		[EnumTextValue("LaborHours")]
		[ColumnEnum("LaborHours", typeof(System.Decimal), System.Data.DbType.Decimal, false, false, true)]
		LaborHours,
		/// <summary>
		/// LotSize :
		/// </summary>
		[EnumTextValue("LotSize")]
		[ColumnEnum("LotSize", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		LotSize,
		/// <summary>
		/// Step :
		/// </summary>
		[EnumTextValue("Step")]
		[ColumnEnum("Step", typeof(System.String), System.Data.DbType.String, false, false, true, 1024)]
		Step,
		/// <summary>
		/// rowguid :
		/// </summary>
		[EnumTextValue("rowguid")]
		[ColumnEnum("rowguid", typeof(System.Guid), System.Data.DbType.Guid, false, false, false)]
		Rowguid,
		/// <summary>
		/// ModifiedDate :
		/// </summary>
		[EnumTextValue("ModifiedDate")]
		[ColumnEnum("ModifiedDate", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, false)]
		ModifiedDate
	}//End enum

} // end namespace
