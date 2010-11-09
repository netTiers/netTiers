
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.Product"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class ProductEditControlBase : System.Windows.Forms.UserControl
	{
		#region Fields
		
		//private System.Windows.Forms.TableLayoutPanel uxTableLayoutPanel;
		/// <summary>
		/// The ErrorProvider for the Entity;
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxErrorProvider;
		
		/// <summary>
		/// The BindingSource for the entity.
		///</summary>
		protected System.Windows.Forms.BindingSource uxBindingSource;
						
		
		/// <summary>
		/// TextBox for the ProductId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductIdLabel;
		
		/// <summary>
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// TextBox for the ProductNumber property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductNumber;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductNumber property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductNumberLabel;
		
		/// <summary>
		/// CheckBox for the MakeFlag property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxMakeFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the MakeFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxMakeFlagLabel;
		
		/// <summary>
		/// CheckBox for the FinishedGoodsFlag property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxFinishedGoodsFlag;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FinishedGoodsFlag property.
		/// </summary>
		protected System.Windows.Forms.Label uxFinishedGoodsFlagLabel;
		
		/// <summary>
		/// TextBox for the Color property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxColor;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Color property.
		/// </summary>
		protected System.Windows.Forms.Label uxColorLabel;
		
		/// <summary>
		/// TextBox for the SafetyStockLevel property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSafetyStockLevel;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SafetyStockLevel property.
		/// </summary>
		protected System.Windows.Forms.Label uxSafetyStockLevelLabel;
		
		/// <summary>
		/// TextBox for the ReorderPoint property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxReorderPoint;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ReorderPoint property.
		/// </summary>
		protected System.Windows.Forms.Label uxReorderPointLabel;
		
		/// <summary>
		/// TextBox for the StandardCost property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStandardCost;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the StandardCost property.
		/// </summary>
		protected System.Windows.Forms.Label uxStandardCostLabel;
		
		/// <summary>
		/// TextBox for the ListPrice property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxListPrice;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ListPrice property.
		/// </summary>
		protected System.Windows.Forms.Label uxListPriceLabel;
		
		/// <summary>
		/// TextBox for the Size property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSize;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Size property.
		/// </summary>
		protected System.Windows.Forms.Label uxSizeLabel;
		
		/// <summary>
		/// ComboBox for the SizeUnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxSizeUnitMeasureCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SizeUnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxSizeUnitMeasureCodeLabel;
		
		/// <summary>
		/// ComboBox for the WeightUnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxWeightUnitMeasureCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the WeightUnitMeasureCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxWeightUnitMeasureCodeLabel;
		
		/// <summary>
		/// TextBox for the Weight property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxWeight;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Weight property.
		/// </summary>
		protected System.Windows.Forms.Label uxWeightLabel;
		
		/// <summary>
		/// TextBox for the DaysToManufacture property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDaysToManufacture;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DaysToManufacture property.
		/// </summary>
		protected System.Windows.Forms.Label uxDaysToManufactureLabel;
		
		/// <summary>
		/// TextBox for the ProductLine property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductLine;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductLine property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductLineLabel;
		
		/// <summary>
		/// TextBox for the SafeNameClass property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSafeNameClass;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SafeNameClass property.
		/// </summary>
		protected System.Windows.Forms.Label uxSafeNameClassLabel;
		
		/// <summary>
		/// TextBox for the Style property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStyle;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Style property.
		/// </summary>
		protected System.Windows.Forms.Label uxStyleLabel;
		
		/// <summary>
		/// ComboBox for the ProductSubcategoryId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductSubcategoryId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductSubcategoryId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductSubcategoryIdLabel;
		
		/// <summary>
		/// ComboBox for the ProductModelId property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxProductModelId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductModelId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductModelIdLabel;
		
		/// <summary>
		/// DataTimePicker for the SellStartDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxSellStartDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SellStartDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxSellStartDateLabel;
		
		/// <summary>
		/// DataTimePicker for the SellEndDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxSellEndDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the SellEndDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxSellEndDateLabel;
		
		/// <summary>
		/// DataTimePicker for the DiscontinuedDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDiscontinuedDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DiscontinuedDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxDiscontinuedDateLabel;
		
		/// <summary>
		/// TextBox for the Rowguid property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxRowguid;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Rowguid property.
		/// </summary>
		protected System.Windows.Forms.Label uxRowguidLabel;
		
		/// <summary>
		/// DataTimePicker for the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxModifiedDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ModifiedDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxModifiedDateLabel;
		#endregion
		
		#region Main entity
		private Entities.Product _Product;
		/// <summary>
		/// Gets or sets the <see cref="Entities.Product"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.Product"/> instance.</value>
		public Entities.Product Product
		{
			get {return this._Product;}
			set
			{
				this._Product = value;
				if (value != null) 
				{
					this.uxBindingSource.DataSource = value;
					BindControls();
				}			
				
			}
		}
		#endregion
		
		/// <summary>
		/// Binds the controls.
		/// </summary>
		private void BindControls()
		{
			this.uxProductId.DataBindings.Clear();
			this.uxProductId.DataBindings.Add("Text", this.uxBindingSource, "ProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductNumber.DataBindings.Clear();
			this.uxProductNumber.DataBindings.Add("Text", this.uxBindingSource, "ProductNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMakeFlag.DataBindings.Clear();
			this.uxMakeFlag.DataBindings.Add("Checked", this.uxBindingSource, "MakeFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFinishedGoodsFlag.DataBindings.Clear();
			this.uxFinishedGoodsFlag.DataBindings.Add("Checked", this.uxBindingSource, "FinishedGoodsFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxColor.DataBindings.Clear();
			this.uxColor.DataBindings.Add("Text", this.uxBindingSource, "Color", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSafetyStockLevel.DataBindings.Clear();
			this.uxSafetyStockLevel.DataBindings.Add("Text", this.uxBindingSource, "SafetyStockLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxReorderPoint.DataBindings.Clear();
			this.uxReorderPoint.DataBindings.Add("Text", this.uxBindingSource, "ReorderPoint", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStandardCost.DataBindings.Clear();
			this.uxStandardCost.DataBindings.Add("Text", this.uxBindingSource, "StandardCost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxListPrice.DataBindings.Clear();
			this.uxListPrice.DataBindings.Add("Text", this.uxBindingSource, "ListPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSize.DataBindings.Clear();
			this.uxSize.DataBindings.Add("Text", this.uxBindingSource, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSizeUnitMeasureCode.DataBindings.Clear();
			this.uxSizeUnitMeasureCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "SizeUnitMeasureCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxWeightUnitMeasureCode.DataBindings.Clear();
			this.uxWeightUnitMeasureCode.DataBindings.Add("SelectedValue", this.uxBindingSource, "WeightUnitMeasureCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxWeight.DataBindings.Clear();
			this.uxWeight.DataBindings.Add("Text", this.uxBindingSource, "Weight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDaysToManufacture.DataBindings.Clear();
			this.uxDaysToManufacture.DataBindings.Add("Text", this.uxBindingSource, "DaysToManufacture", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductLine.DataBindings.Clear();
			this.uxProductLine.DataBindings.Add("Text", this.uxBindingSource, "ProductLine", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSafeNameClass.DataBindings.Clear();
			this.uxSafeNameClass.DataBindings.Add("Text", this.uxBindingSource, "SafeNameClass", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStyle.DataBindings.Clear();
			this.uxStyle.DataBindings.Add("Text", this.uxBindingSource, "Style", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductSubcategoryId.DataBindings.Clear();
			this.uxProductSubcategoryId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductSubcategoryId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductModelId.DataBindings.Clear();
			this.uxProductModelId.DataBindings.Add("SelectedValue", this.uxBindingSource, "ProductModelId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSellStartDate.DataBindings.Clear();
			this.uxSellStartDate.DataBindings.Add("Value", this.uxBindingSource, "SellStartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSellEndDate.DataBindings.Clear();
			this.uxSellEndDate.DataBindings.Add("Value", this.uxBindingSource, "SellEndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDiscontinuedDate.DataBindings.Clear();
			this.uxDiscontinuedDate.DataBindings.Add("Value", this.uxBindingSource, "DiscontinuedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxRowguid.DataBindings.Clear();
			this.uxRowguid.DataBindings.Add("Text", this.uxBindingSource, "Rowguid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModifiedDate.DataBindings.Clear();
			this.uxModifiedDate.DataBindings.Add("Value", this.uxBindingSource, "ModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductEditControlBase"/> class.
		/// </summary>
		public ProductEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Product != null) _Product.Validate();
		}	
				
		/// <summary>
		/// Initializes the component.
		/// </summary>
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.uxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxBindingSource = new System.Windows.Forms.BindingSource(this.components);
			
			//this.uxTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.uxProductId = new System.Windows.Forms.TextBox();
			uxProductIdLabel = new System.Windows.Forms.Label();
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxProductNumber = new System.Windows.Forms.TextBox();
			uxProductNumberLabel = new System.Windows.Forms.Label();
			this.uxMakeFlag = new System.Windows.Forms.CheckBox();
			uxMakeFlagLabel = new System.Windows.Forms.Label();
			this.uxFinishedGoodsFlag = new System.Windows.Forms.CheckBox();
			uxFinishedGoodsFlagLabel = new System.Windows.Forms.Label();
			this.uxColor = new System.Windows.Forms.TextBox();
			uxColorLabel = new System.Windows.Forms.Label();
			this.uxSafetyStockLevel = new System.Windows.Forms.TextBox();
			uxSafetyStockLevelLabel = new System.Windows.Forms.Label();
			this.uxReorderPoint = new System.Windows.Forms.TextBox();
			uxReorderPointLabel = new System.Windows.Forms.Label();
			this.uxStandardCost = new System.Windows.Forms.TextBox();
			uxStandardCostLabel = new System.Windows.Forms.Label();
			this.uxListPrice = new System.Windows.Forms.TextBox();
			uxListPriceLabel = new System.Windows.Forms.Label();
			this.uxSize = new System.Windows.Forms.TextBox();
			uxSizeLabel = new System.Windows.Forms.Label();
			this.uxSizeUnitMeasureCode = new System.Windows.Forms.ComboBox();
			uxSizeUnitMeasureCodeLabel = new System.Windows.Forms.Label();
			this.uxWeightUnitMeasureCode = new System.Windows.Forms.ComboBox();
			uxWeightUnitMeasureCodeLabel = new System.Windows.Forms.Label();
			this.uxWeight = new System.Windows.Forms.TextBox();
			uxWeightLabel = new System.Windows.Forms.Label();
			this.uxDaysToManufacture = new System.Windows.Forms.TextBox();
			uxDaysToManufactureLabel = new System.Windows.Forms.Label();
			this.uxProductLine = new System.Windows.Forms.TextBox();
			uxProductLineLabel = new System.Windows.Forms.Label();
			this.uxSafeNameClass = new System.Windows.Forms.TextBox();
			uxSafeNameClassLabel = new System.Windows.Forms.Label();
			this.uxStyle = new System.Windows.Forms.TextBox();
			uxStyleLabel = new System.Windows.Forms.Label();
			this.uxProductSubcategoryId = new System.Windows.Forms.ComboBox();
			uxProductSubcategoryIdLabel = new System.Windows.Forms.Label();
			this.uxProductModelId = new System.Windows.Forms.ComboBox();
			uxProductModelIdLabel = new System.Windows.Forms.Label();
			this.uxSellStartDate = new System.Windows.Forms.DateTimePicker();
			uxSellStartDateLabel = new System.Windows.Forms.Label();
			this.uxSellEndDate = new System.Windows.Forms.DateTimePicker();
			uxSellEndDateLabel = new System.Windows.Forms.Label();
			this.uxDiscontinuedDate = new System.Windows.Forms.DateTimePicker();
			uxDiscontinuedDateLabel = new System.Windows.Forms.Label();
			this.uxRowguid = new System.Windows.Forms.TextBox();
			uxRowguidLabel = new System.Windows.Forms.Label();
			this.uxModifiedDate = new System.Windows.Forms.DateTimePicker();
			uxModifiedDateLabel = new System.Windows.Forms.Label();
			
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).BeginInit();
			this.SuspendLayout();
			
			// 
			// uxTableLayoutPanel
			// 
			//this.uxTableLayoutPanel.AutoSize = true;
			//this.uxTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			//this.uxTableLayoutPanel.ColumnCount = 2;
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			//this.uxTableLayoutPanel.Location = new System.Drawing.System.Drawing.Point(3, 3);
			//this.uxTableLayoutPanel.Name = "uxTableLayoutPanel";
			//this.uxTableLayoutPanel.RowCount = 2;
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.Size = new System.Drawing.Size(450, 50);
			//this.uxTableLayoutPanel.TabIndex = 0;
			
			//
			// uxErrorProvider
			//
			this.uxErrorProvider.ContainerControl = this;
			this.uxErrorProvider.DataSource = this.uxBindingSource;
			
			//
			// uxProductIdLabel
			//
			this.uxProductIdLabel.Name = "uxProductIdLabel";
			this.uxProductIdLabel.Text = "Product Id:";
			this.uxProductIdLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductIdLabel);			
			//
			// uxProductId
			//
			this.uxProductId.Name = "uxProductId";
            this.uxProductId.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductId);
			this.uxProductId.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxProductId);
			//
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxName);
			//
			// uxProductNumberLabel
			//
			this.uxProductNumberLabel.Name = "uxProductNumberLabel";
			this.uxProductNumberLabel.Text = "Product Number:";
			this.uxProductNumberLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxProductNumberLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductNumberLabel);			
			//
			// uxProductNumber
			//
			this.uxProductNumber.Name = "uxProductNumber";
			this.uxProductNumber.Width = 250;
			this.uxProductNumber.MaxLength = 25;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductNumber);
			this.uxProductNumber.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxProductNumber);
			//
			// uxMakeFlagLabel
			//
			this.uxMakeFlagLabel.Name = "uxMakeFlagLabel";
			this.uxMakeFlagLabel.Text = "Make Flag:";
			this.uxMakeFlagLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxMakeFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMakeFlagLabel);			
			//
			// uxMakeFlag
			//
			this.uxMakeFlag.Name = "uxMakeFlag";
			//this.uxTableLayoutPanel.Controls.Add(this.uxMakeFlag);
			this.uxMakeFlag.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxMakeFlag);
			//
			// uxFinishedGoodsFlagLabel
			//
			this.uxFinishedGoodsFlagLabel.Name = "uxFinishedGoodsFlagLabel";
			this.uxFinishedGoodsFlagLabel.Text = "Finished Goods Flag:";
			this.uxFinishedGoodsFlagLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxFinishedGoodsFlagLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFinishedGoodsFlagLabel);			
			//
			// uxFinishedGoodsFlag
			//
			this.uxFinishedGoodsFlag.Name = "uxFinishedGoodsFlag";
			//this.uxTableLayoutPanel.Controls.Add(this.uxFinishedGoodsFlag);
			this.uxFinishedGoodsFlag.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxFinishedGoodsFlag);
			//
			// uxColorLabel
			//
			this.uxColorLabel.Name = "uxColorLabel";
			this.uxColorLabel.Text = "Color:";
			this.uxColorLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxColorLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxColorLabel);			
			//
			// uxColor
			//
			this.uxColor.Name = "uxColor";
			this.uxColor.Width = 250;
			this.uxColor.MaxLength = 15;
			//this.uxTableLayoutPanel.Controls.Add(this.uxColor);
			this.uxColor.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxColor);
			//
			// uxSafetyStockLevelLabel
			//
			this.uxSafetyStockLevelLabel.Name = "uxSafetyStockLevelLabel";
			this.uxSafetyStockLevelLabel.Text = "Safety Stock Level:";
			this.uxSafetyStockLevelLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxSafetyStockLevelLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafetyStockLevelLabel);			
			//
			// uxSafetyStockLevel
			//
			this.uxSafetyStockLevel.Name = "uxSafetyStockLevel";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafetyStockLevel);
			this.uxSafetyStockLevel.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxSafetyStockLevel);
			//
			// uxReorderPointLabel
			//
			this.uxReorderPointLabel.Name = "uxReorderPointLabel";
			this.uxReorderPointLabel.Text = "Reorder Point:";
			this.uxReorderPointLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxReorderPointLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxReorderPointLabel);			
			//
			// uxReorderPoint
			//
			this.uxReorderPoint.Name = "uxReorderPoint";
			//this.uxTableLayoutPanel.Controls.Add(this.uxReorderPoint);
			this.uxReorderPoint.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxReorderPoint);
			//
			// uxStandardCostLabel
			//
			this.uxStandardCostLabel.Name = "uxStandardCostLabel";
			this.uxStandardCostLabel.Text = "Standard Cost:";
			this.uxStandardCostLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxStandardCostLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStandardCostLabel);			
			//
			// uxStandardCost
			//
			this.uxStandardCost.Name = "uxStandardCost";
			//this.uxTableLayoutPanel.Controls.Add(this.uxStandardCost);
			this.uxStandardCost.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxStandardCost);
			//
			// uxListPriceLabel
			//
			this.uxListPriceLabel.Name = "uxListPriceLabel";
			this.uxListPriceLabel.Text = "List Price:";
			this.uxListPriceLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxListPriceLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxListPriceLabel);			
			//
			// uxListPrice
			//
			this.uxListPrice.Name = "uxListPrice";
			//this.uxTableLayoutPanel.Controls.Add(this.uxListPrice);
			this.uxListPrice.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxListPrice);
			//
			// uxSizeLabel
			//
			this.uxSizeLabel.Name = "uxSizeLabel";
			this.uxSizeLabel.Text = "Size:";
			this.uxSizeLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxSizeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSizeLabel);			
			//
			// uxSize
			//
			this.uxSize.Name = "uxSize";
			this.uxSize.Width = 250;
			this.uxSize.MaxLength = 5;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSize);
			this.uxSize.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxSize);
			//
			// uxSizeUnitMeasureCodeLabel
			//
			this.uxSizeUnitMeasureCodeLabel.Name = "uxSizeUnitMeasureCodeLabel";
			this.uxSizeUnitMeasureCodeLabel.Text = "Size Unit Measure Code:";
			this.uxSizeUnitMeasureCodeLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxSizeUnitMeasureCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSizeUnitMeasureCodeLabel);			
			//
			// uxSizeUnitMeasureCode
			//
			this.uxSizeUnitMeasureCode.Name = "uxSizeUnitMeasureCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSizeUnitMeasureCode);
			this.uxSizeUnitMeasureCode.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxSizeUnitMeasureCode);
			//
			// uxWeightUnitMeasureCodeLabel
			//
			this.uxWeightUnitMeasureCodeLabel.Name = "uxWeightUnitMeasureCodeLabel";
			this.uxWeightUnitMeasureCodeLabel.Text = "Weight Unit Measure Code:";
			this.uxWeightUnitMeasureCodeLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxWeightUnitMeasureCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxWeightUnitMeasureCodeLabel);			
			//
			// uxWeightUnitMeasureCode
			//
			this.uxWeightUnitMeasureCode.Name = "uxWeightUnitMeasureCode";
			//this.uxTableLayoutPanel.Controls.Add(this.uxWeightUnitMeasureCode);
			this.uxWeightUnitMeasureCode.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxWeightUnitMeasureCode);
			//
			// uxWeightLabel
			//
			this.uxWeightLabel.Name = "uxWeightLabel";
			this.uxWeightLabel.Text = "Weight:";
			this.uxWeightLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxWeightLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxWeightLabel);			
			//
			// uxWeight
			//
			this.uxWeight.Name = "uxWeight";
			//this.uxTableLayoutPanel.Controls.Add(this.uxWeight);
			this.uxWeight.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxWeight);
			//
			// uxDaysToManufactureLabel
			//
			this.uxDaysToManufactureLabel.Name = "uxDaysToManufactureLabel";
			this.uxDaysToManufactureLabel.Text = "Days To Manufacture:";
			this.uxDaysToManufactureLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxDaysToManufactureLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDaysToManufactureLabel);			
			//
			// uxDaysToManufacture
			//
			this.uxDaysToManufacture.Name = "uxDaysToManufacture";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDaysToManufacture);
			this.uxDaysToManufacture.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxDaysToManufacture);
			//
			// uxProductLineLabel
			//
			this.uxProductLineLabel.Name = "uxProductLineLabel";
			this.uxProductLineLabel.Text = "Product Line:";
			this.uxProductLineLabel.Location = new System.Drawing.Point(3, 390);
			this.Controls.Add(this.uxProductLineLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductLineLabel);			
			//
			// uxProductLine
			//
			this.uxProductLine.Name = "uxProductLine";
			this.uxProductLine.Width = 250;
			this.uxProductLine.MaxLength = 2;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductLine);
			this.uxProductLine.Location = new System.Drawing.Point(160, 390);
			this.Controls.Add(this.uxProductLine);
			//
			// uxSafeNameClassLabel
			//
			this.uxSafeNameClassLabel.Name = "uxSafeNameClassLabel";
			this.uxSafeNameClassLabel.Text = "Class:";
			this.uxSafeNameClassLabel.Location = new System.Drawing.Point(3, 416);
			this.Controls.Add(this.uxSafeNameClassLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafeNameClassLabel);			
			//
			// uxSafeNameClass
			//
			this.uxSafeNameClass.Name = "uxSafeNameClass";
			this.uxSafeNameClass.Width = 250;
			this.uxSafeNameClass.MaxLength = 2;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSafeNameClass);
			this.uxSafeNameClass.Location = new System.Drawing.Point(160, 416);
			this.Controls.Add(this.uxSafeNameClass);
			//
			// uxStyleLabel
			//
			this.uxStyleLabel.Name = "uxStyleLabel";
			this.uxStyleLabel.Text = "Style:";
			this.uxStyleLabel.Location = new System.Drawing.Point(3, 442);
			this.Controls.Add(this.uxStyleLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStyleLabel);			
			//
			// uxStyle
			//
			this.uxStyle.Name = "uxStyle";
			this.uxStyle.Width = 250;
			this.uxStyle.MaxLength = 2;
			//this.uxTableLayoutPanel.Controls.Add(this.uxStyle);
			this.uxStyle.Location = new System.Drawing.Point(160, 442);
			this.Controls.Add(this.uxStyle);
			//
			// uxProductSubcategoryIdLabel
			//
			this.uxProductSubcategoryIdLabel.Name = "uxProductSubcategoryIdLabel";
			this.uxProductSubcategoryIdLabel.Text = "Product Subcategory Id:";
			this.uxProductSubcategoryIdLabel.Location = new System.Drawing.Point(3, 468);
			this.Controls.Add(this.uxProductSubcategoryIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductSubcategoryIdLabel);			
			//
			// uxProductSubcategoryId
			//
			this.uxProductSubcategoryId.Name = "uxProductSubcategoryId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductSubcategoryId);
			this.uxProductSubcategoryId.Location = new System.Drawing.Point(160, 468);
			this.Controls.Add(this.uxProductSubcategoryId);
			//
			// uxProductModelIdLabel
			//
			this.uxProductModelIdLabel.Name = "uxProductModelIdLabel";
			this.uxProductModelIdLabel.Text = "Product Model Id:";
			this.uxProductModelIdLabel.Location = new System.Drawing.Point(3, 494);
			this.Controls.Add(this.uxProductModelIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductModelIdLabel);			
			//
			// uxProductModelId
			//
			this.uxProductModelId.Name = "uxProductModelId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductModelId);
			this.uxProductModelId.Location = new System.Drawing.Point(160, 494);
			this.Controls.Add(this.uxProductModelId);
			//
			// uxSellStartDateLabel
			//
			this.uxSellStartDateLabel.Name = "uxSellStartDateLabel";
			this.uxSellStartDateLabel.Text = "Sell Start Date:";
			this.uxSellStartDateLabel.Location = new System.Drawing.Point(3, 520);
			this.Controls.Add(this.uxSellStartDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSellStartDateLabel);			
			//
			// uxSellStartDate
			//
			this.uxSellStartDate.Name = "uxSellStartDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSellStartDate);
			this.uxSellStartDate.Location = new System.Drawing.Point(160, 520);
			this.Controls.Add(this.uxSellStartDate);
			//
			// uxSellEndDateLabel
			//
			this.uxSellEndDateLabel.Name = "uxSellEndDateLabel";
			this.uxSellEndDateLabel.Text = "Sell End Date:";
			this.uxSellEndDateLabel.Location = new System.Drawing.Point(3, 546);
			this.Controls.Add(this.uxSellEndDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSellEndDateLabel);			
			//
			// uxSellEndDate
			//
			this.uxSellEndDate.Name = "uxSellEndDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSellEndDate);
			this.uxSellEndDate.Location = new System.Drawing.Point(160, 546);
			this.Controls.Add(this.uxSellEndDate);
			//
			// uxDiscontinuedDateLabel
			//
			this.uxDiscontinuedDateLabel.Name = "uxDiscontinuedDateLabel";
			this.uxDiscontinuedDateLabel.Text = "Discontinued Date:";
			this.uxDiscontinuedDateLabel.Location = new System.Drawing.Point(3, 572);
			this.Controls.Add(this.uxDiscontinuedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDiscontinuedDateLabel);			
			//
			// uxDiscontinuedDate
			//
			this.uxDiscontinuedDate.Name = "uxDiscontinuedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDiscontinuedDate);
			this.uxDiscontinuedDate.Location = new System.Drawing.Point(160, 572);
			this.Controls.Add(this.uxDiscontinuedDate);
			//
			// uxRowguidLabel
			//
			this.uxRowguidLabel.Name = "uxRowguidLabel";
			this.uxRowguidLabel.Text = "Rowguid:";
			this.uxRowguidLabel.Location = new System.Drawing.Point(3, 598);
			this.Controls.Add(this.uxRowguidLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguidLabel);			
			//
			// uxRowguid
			//
			this.uxRowguid.Name = "uxRowguid";
            this.uxRowguid.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxRowguid);
			this.uxRowguid.Location = new System.Drawing.Point(160, 598);
			this.Controls.Add(this.uxRowguid);
			//
			// uxModifiedDateLabel
			//
			this.uxModifiedDateLabel.Name = "uxModifiedDateLabel";
			this.uxModifiedDateLabel.Text = "Modified Date:";
			this.uxModifiedDateLabel.Location = new System.Drawing.Point(3, 624);
			this.Controls.Add(this.uxModifiedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDateLabel);			
			//
			// uxModifiedDate
			//
			this.uxModifiedDate.Name = "uxModifiedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxModifiedDate);
			this.uxModifiedDate.Location = new System.Drawing.Point(160, 624);
			this.Controls.Add(this.uxModifiedDate);
			//
			// uxProductModelId
			//				
			this.uxProductModelId.DisplayMember = "Name";	
			this.uxProductModelId.ValueMember = "ProductModelId";	
			//
			// uxProductSubcategoryId
			//				
			this.uxProductSubcategoryId.DisplayMember = "ProductCategoryId";	
			this.uxProductSubcategoryId.ValueMember = "ProductSubcategoryId";	
			//
			// uxSizeUnitMeasureCode
			//				
			this.uxSizeUnitMeasureCode.DisplayMember = "Name";	
			this.uxSizeUnitMeasureCode.ValueMember = "UnitMeasureCode";	
			//
			// uxWeightUnitMeasureCode
			//				
			this.uxWeightUnitMeasureCode.DisplayMember = "Name";	
			this.uxWeightUnitMeasureCode.ValueMember = "UnitMeasureCode";	
			// 
			// ProductEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "ProductEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private Entities.TList<Entities.ProductModel> _ProductModelIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductModelId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.ProductModel> ProductModelIdList
		{
			get {return _ProductModelIdList;}
			set 
			{
				this._ProductModelIdList = value;
				this.uxProductModelId.DataSource = null;
				this.uxProductModelId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductModelIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductModelId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductModelIdList
		{
			get { return _allowNewItemInProductModelIdList;}
			set
			{
				this._allowNewItemInProductModelIdList = value;
				this.uxProductModelId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.ProductSubcategory> _ProductSubcategoryIdList;
		
		/// <summary>
		/// The ComboBox associated with the ProductSubcategoryId property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.ProductSubcategory> ProductSubcategoryIdList
		{
			get {return _ProductSubcategoryIdList;}
			set 
			{
				this._ProductSubcategoryIdList = value;
				this.uxProductSubcategoryId.DataSource = null;
				this.uxProductSubcategoryId.DataSource = value;
			}
		}
		
		private bool _allowNewItemInProductSubcategoryIdList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the ProductSubcategoryId property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInProductSubcategoryIdList
		{
			get { return _allowNewItemInProductSubcategoryIdList;}
			set
			{
				this._allowNewItemInProductSubcategoryIdList = value;
				this.uxProductSubcategoryId.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.UnitMeasure> _SizeUnitMeasureCodeList;
		
		/// <summary>
		/// The ComboBox associated with the SizeUnitMeasureCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.UnitMeasure> SizeUnitMeasureCodeList
		{
			get {return _SizeUnitMeasureCodeList;}
			set 
			{
				this._SizeUnitMeasureCodeList = value;
				this.uxSizeUnitMeasureCode.DataSource = null;
				this.uxSizeUnitMeasureCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInSizeUnitMeasureCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the SizeUnitMeasureCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInSizeUnitMeasureCodeList
		{
			get { return _allowNewItemInSizeUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInSizeUnitMeasureCodeList = value;
				this.uxSizeUnitMeasureCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private Entities.TList<Entities.UnitMeasure> _WeightUnitMeasureCodeList;
		
		/// <summary>
		/// The ComboBox associated with the WeightUnitMeasureCode property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public Entities.TList<Entities.UnitMeasure> WeightUnitMeasureCodeList
		{
			get {return _WeightUnitMeasureCodeList;}
			set 
			{
				this._WeightUnitMeasureCodeList = value;
				this.uxWeightUnitMeasureCode.DataSource = null;
				this.uxWeightUnitMeasureCode.DataSource = value;
			}
		}
		
		private bool _allowNewItemInWeightUnitMeasureCodeList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the WeightUnitMeasureCode property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInWeightUnitMeasureCodeList
		{
			get { return _allowNewItemInWeightUnitMeasureCodeList;}
			set
			{
				this._allowNewItemInWeightUnitMeasureCodeList = value;
				this.uxWeightUnitMeasureCode.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductIdVisible
        {
            get { return this.uxProductId.Visible; }
            set
            {
                this.uxProductIdLabel.Visible = value;
                this.uxProductId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductIdEnabled
        {
            get { return this.uxProductId.Enabled; }
            set
            {
                this.uxProductId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNameVisible
        {
            get { return this.uxName.Visible; }
            set
            {
                this.uxNameLabel.Visible = value;
                this.uxName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNameEnabled
        {
            get { return this.uxName.Enabled; }
            set
            {
                this.uxName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductNumber property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductNumberVisible
        {
            get { return this.uxProductNumber.Visible; }
            set
            {
                this.uxProductNumberLabel.Visible = value;
                this.uxProductNumber.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductNumber property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductNumberEnabled
        {
            get { return this.uxProductNumber.Enabled; }
            set
            {
                this.uxProductNumber.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxMakeFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMakeFlagVisible
        {
            get { return this.uxMakeFlag.Visible; }
            set
            {
                this.uxMakeFlagLabel.Visible = value;
                this.uxMakeFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMakeFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMakeFlagEnabled
        {
            get { return this.uxMakeFlag.Enabled; }
            set
            {
                this.uxMakeFlag.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFinishedGoodsFlag property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFinishedGoodsFlagVisible
        {
            get { return this.uxFinishedGoodsFlag.Visible; }
            set
            {
                this.uxFinishedGoodsFlagLabel.Visible = value;
                this.uxFinishedGoodsFlag.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFinishedGoodsFlag property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFinishedGoodsFlagEnabled
        {
            get { return this.uxFinishedGoodsFlag.Enabled; }
            set
            {
                this.uxFinishedGoodsFlag.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxColor property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxColorVisible
        {
            get { return this.uxColor.Visible; }
            set
            {
                this.uxColorLabel.Visible = value;
                this.uxColor.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxColor property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxColorEnabled
        {
            get { return this.uxColor.Enabled; }
            set
            {
                this.uxColor.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSafetyStockLevel property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSafetyStockLevelVisible
        {
            get { return this.uxSafetyStockLevel.Visible; }
            set
            {
                this.uxSafetyStockLevelLabel.Visible = value;
                this.uxSafetyStockLevel.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSafetyStockLevel property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSafetyStockLevelEnabled
        {
            get { return this.uxSafetyStockLevel.Enabled; }
            set
            {
                this.uxSafetyStockLevel.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxReorderPoint property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxReorderPointVisible
        {
            get { return this.uxReorderPoint.Visible; }
            set
            {
                this.uxReorderPointLabel.Visible = value;
                this.uxReorderPoint.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxReorderPoint property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxReorderPointEnabled
        {
            get { return this.uxReorderPoint.Enabled; }
            set
            {
                this.uxReorderPoint.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStandardCost property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStandardCostVisible
        {
            get { return this.uxStandardCost.Visible; }
            set
            {
                this.uxStandardCostLabel.Visible = value;
                this.uxStandardCost.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStandardCost property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStandardCostEnabled
        {
            get { return this.uxStandardCost.Enabled; }
            set
            {
                this.uxStandardCost.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxListPrice property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxListPriceVisible
        {
            get { return this.uxListPrice.Visible; }
            set
            {
                this.uxListPriceLabel.Visible = value;
                this.uxListPrice.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxListPrice property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxListPriceEnabled
        {
            get { return this.uxListPrice.Enabled; }
            set
            {
                this.uxListPrice.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSize property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSizeVisible
        {
            get { return this.uxSize.Visible; }
            set
            {
                this.uxSizeLabel.Visible = value;
                this.uxSize.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSize property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSizeEnabled
        {
            get { return this.uxSize.Enabled; }
            set
            {
                this.uxSize.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSizeUnitMeasureCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSizeUnitMeasureCodeVisible
        {
            get { return this.uxSizeUnitMeasureCode.Visible; }
            set
            {
                this.uxSizeUnitMeasureCodeLabel.Visible = value;
                this.uxSizeUnitMeasureCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSizeUnitMeasureCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSizeUnitMeasureCodeEnabled
        {
            get { return this.uxSizeUnitMeasureCode.Enabled; }
            set
            {
                this.uxSizeUnitMeasureCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxWeightUnitMeasureCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxWeightUnitMeasureCodeVisible
        {
            get { return this.uxWeightUnitMeasureCode.Visible; }
            set
            {
                this.uxWeightUnitMeasureCodeLabel.Visible = value;
                this.uxWeightUnitMeasureCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxWeightUnitMeasureCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxWeightUnitMeasureCodeEnabled
        {
            get { return this.uxWeightUnitMeasureCode.Enabled; }
            set
            {
                this.uxWeightUnitMeasureCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxWeight property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxWeightVisible
        {
            get { return this.uxWeight.Visible; }
            set
            {
                this.uxWeightLabel.Visible = value;
                this.uxWeight.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxWeight property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxWeightEnabled
        {
            get { return this.uxWeight.Enabled; }
            set
            {
                this.uxWeight.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDaysToManufacture property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDaysToManufactureVisible
        {
            get { return this.uxDaysToManufacture.Visible; }
            set
            {
                this.uxDaysToManufactureLabel.Visible = value;
                this.uxDaysToManufacture.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDaysToManufacture property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDaysToManufactureEnabled
        {
            get { return this.uxDaysToManufacture.Enabled; }
            set
            {
                this.uxDaysToManufacture.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductLine property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductLineVisible
        {
            get { return this.uxProductLine.Visible; }
            set
            {
                this.uxProductLineLabel.Visible = value;
                this.uxProductLine.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductLine property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductLineEnabled
        {
            get { return this.uxProductLine.Enabled; }
            set
            {
                this.uxProductLine.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSafeNameClass property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSafeNameClassVisible
        {
            get { return this.uxSafeNameClass.Visible; }
            set
            {
                this.uxSafeNameClassLabel.Visible = value;
                this.uxSafeNameClass.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSafeNameClass property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSafeNameClassEnabled
        {
            get { return this.uxSafeNameClass.Enabled; }
            set
            {
                this.uxSafeNameClass.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStyle property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStyleVisible
        {
            get { return this.uxStyle.Visible; }
            set
            {
                this.uxStyleLabel.Visible = value;
                this.uxStyle.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStyle property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStyleEnabled
        {
            get { return this.uxStyle.Enabled; }
            set
            {
                this.uxStyle.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductSubcategoryId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductSubcategoryIdVisible
        {
            get { return this.uxProductSubcategoryId.Visible; }
            set
            {
                this.uxProductSubcategoryIdLabel.Visible = value;
                this.uxProductSubcategoryId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductSubcategoryId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductSubcategoryIdEnabled
        {
            get { return this.uxProductSubcategoryId.Enabled; }
            set
            {
                this.uxProductSubcategoryId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductModelId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductModelIdVisible
        {
            get { return this.uxProductModelId.Visible; }
            set
            {
                this.uxProductModelIdLabel.Visible = value;
                this.uxProductModelId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductModelId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductModelIdEnabled
        {
            get { return this.uxProductModelId.Enabled; }
            set
            {
                this.uxProductModelId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSellStartDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSellStartDateVisible
        {
            get { return this.uxSellStartDate.Visible; }
            set
            {
                this.uxSellStartDateLabel.Visible = value;
                this.uxSellStartDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSellStartDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSellStartDateEnabled
        {
            get { return this.uxSellStartDate.Enabled; }
            set
            {
                this.uxSellStartDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSellEndDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSellEndDateVisible
        {
            get { return this.uxSellEndDate.Visible; }
            set
            {
                this.uxSellEndDateLabel.Visible = value;
                this.uxSellEndDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSellEndDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSellEndDateEnabled
        {
            get { return this.uxSellEndDate.Enabled; }
            set
            {
                this.uxSellEndDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDiscontinuedDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDiscontinuedDateVisible
        {
            get { return this.uxDiscontinuedDate.Visible; }
            set
            {
                this.uxDiscontinuedDateLabel.Visible = value;
                this.uxDiscontinuedDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDiscontinuedDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDiscontinuedDateEnabled
        {
            get { return this.uxDiscontinuedDate.Enabled; }
            set
            {
                this.uxDiscontinuedDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxRowguid property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxRowguidVisible
        {
            get { return this.uxRowguid.Visible; }
            set
            {
                this.uxRowguidLabel.Visible = value;
                this.uxRowguid.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxRowguid property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxRowguidEnabled
        {
            get { return this.uxRowguid.Enabled; }
            set
            {
                this.uxRowguid.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxModifiedDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxModifiedDateVisible
        {
            get { return this.uxModifiedDate.Visible; }
            set
            {
                this.uxModifiedDateLabel.Visible = value;
                this.uxModifiedDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxModifiedDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxModifiedDateEnabled
        {
            get { return this.uxModifiedDate.Enabled; }
            set
            {
                this.uxModifiedDate.Enabled = value;
            }
        }

        #endregion

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
