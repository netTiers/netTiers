
namespace Nettiers.AdventureWorks.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="Entities.TestProduct"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class TestProductEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the ProductTypeId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductTypeId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductTypeId property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductTypeIdLabel;
		
		/// <summary>
		/// TextBox for the DownloadId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDownloadId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DownloadId property.
		/// </summary>
		protected System.Windows.Forms.Label uxDownloadIdLabel;
		
		/// <summary>
		/// TextBox for the ManufacturerId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxManufacturerId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ManufacturerId property.
		/// </summary>
		protected System.Windows.Forms.Label uxManufacturerIdLabel;
		
		/// <summary>
		/// TextBox for the BrandName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBrandName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BrandName property.
		/// </summary>
		protected System.Windows.Forms.Label uxBrandNameLabel;
		
		/// <summary>
		/// TextBox for the ProductName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductName property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductNameLabel;
		
		/// <summary>
		/// TextBox for the ProductCode property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductCodeLabel;
		
		/// <summary>
		/// TextBox for the UniqueIdentifier property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUniqueIdentifier;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UniqueIdentifier property.
		/// </summary>
		protected System.Windows.Forms.Label uxUniqueIdentifierLabel;
		
		/// <summary>
		/// TextBox for the TypeName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTypeName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TypeName property.
		/// </summary>
		protected System.Windows.Forms.Label uxTypeNameLabel;
		
		/// <summary>
		/// TextBox for the ModelName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxModelName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ModelName property.
		/// </summary>
		protected System.Windows.Forms.Label uxModelNameLabel;
		
		/// <summary>
		/// TextBox for the DisplayName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDisplayName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DisplayName property.
		/// </summary>
		protected System.Windows.Forms.Label uxDisplayNameLabel;
		
		/// <summary>
		/// TextBox for the ProductLink property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxProductLink;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ProductLink property.
		/// </summary>
		protected System.Windows.Forms.Label uxProductLinkLabel;
		
		/// <summary>
		/// TextBox for the ConnectorCode property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxConnectorCode;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ConnectorCode property.
		/// </summary>
		protected System.Windows.Forms.Label uxConnectorCodeLabel;
		
		/// <summary>
		/// TextBox for the BaseId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBaseId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BaseId property.
		/// </summary>
		protected System.Windows.Forms.Label uxBaseIdLabel;
		
		/// <summary>
		/// TextBox for the OrgProductId property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxOrgProductId;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the OrgProductId property.
		/// </summary>
		protected System.Windows.Forms.Label uxOrgProductIdLabel;
		
		/// <summary>
		/// TextBox for the ImageFileType property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxImageFileType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ImageFileType property.
		/// </summary>
		protected System.Windows.Forms.Label uxImageFileTypeLabel;
		
		/// <summary>
		/// TextBox for the FullImageFileType property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFullImageFileType;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FullImageFileType property.
		/// </summary>
		protected System.Windows.Forms.Label uxFullImageFileTypeLabel;
		
		/// <summary>
		/// TextBox for the Status property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxStatus;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Status property.
		/// </summary>
		protected System.Windows.Forms.Label uxStatusLabel;
		
		/// <summary>
		/// TextBox for the AddedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddedByLabel;
		
		/// <summary>
		/// DataTimePicker for the AddedDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxAddedDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the AddedDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddedDateLabel;
		
		/// <summary>
		/// TextBox for the UpdatedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUpdatedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UpdatedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxUpdatedByLabel;
		
		/// <summary>
		/// DataTimePicker for the UpdatedDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxUpdatedDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UpdatedDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxUpdatedDateLabel;
		#endregion
		
		#region Main entity
		private Entities.TestProduct _TestProduct;
		/// <summary>
		/// Gets or sets the <see cref="Entities.TestProduct"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="Entities.TestProduct"/> instance.</value>
		public Entities.TestProduct TestProduct
		{
			get {return this._TestProduct;}
			set
			{
				this._TestProduct = value;
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
			this.uxProductTypeId.DataBindings.Clear();
			this.uxProductTypeId.DataBindings.Add("Text", this.uxBindingSource, "ProductTypeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDownloadId.DataBindings.Clear();
			this.uxDownloadId.DataBindings.Add("Text", this.uxBindingSource, "DownloadId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxManufacturerId.DataBindings.Clear();
			this.uxManufacturerId.DataBindings.Add("Text", this.uxBindingSource, "ManufacturerId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBrandName.DataBindings.Clear();
			this.uxBrandName.DataBindings.Add("Text", this.uxBindingSource, "BrandName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductName.DataBindings.Clear();
			this.uxProductName.DataBindings.Add("Text", this.uxBindingSource, "ProductName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductCode.DataBindings.Clear();
			this.uxProductCode.DataBindings.Add("Text", this.uxBindingSource, "ProductCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUniqueIdentifier.DataBindings.Clear();
			this.uxUniqueIdentifier.DataBindings.Add("Text", this.uxBindingSource, "UniqueIdentifier", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxTypeName.DataBindings.Clear();
			this.uxTypeName.DataBindings.Add("Text", this.uxBindingSource, "TypeName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxModelName.DataBindings.Clear();
			this.uxModelName.DataBindings.Add("Text", this.uxBindingSource, "ModelName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDisplayName.DataBindings.Clear();
			this.uxDisplayName.DataBindings.Add("Text", this.uxBindingSource, "DisplayName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxProductLink.DataBindings.Clear();
			this.uxProductLink.DataBindings.Add("Text", this.uxBindingSource, "ProductLink", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxConnectorCode.DataBindings.Clear();
			this.uxConnectorCode.DataBindings.Add("Text", this.uxBindingSource, "ConnectorCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBaseId.DataBindings.Clear();
			this.uxBaseId.DataBindings.Add("Text", this.uxBindingSource, "BaseId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxOrgProductId.DataBindings.Clear();
			this.uxOrgProductId.DataBindings.Add("Text", this.uxBindingSource, "OrgProductId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxImageFileType.DataBindings.Clear();
			this.uxImageFileType.DataBindings.Add("Text", this.uxBindingSource, "ImageFileType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFullImageFileType.DataBindings.Clear();
			this.uxFullImageFileType.DataBindings.Add("Text", this.uxBindingSource, "FullImageFileType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxStatus.DataBindings.Clear();
			this.uxStatus.DataBindings.Add("Text", this.uxBindingSource, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddedBy.DataBindings.Clear();
			this.uxAddedBy.DataBindings.Add("Text", this.uxBindingSource, "AddedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddedDate.DataBindings.Clear();
			this.uxAddedDate.DataBindings.Add("Value", this.uxBindingSource, "AddedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUpdatedBy.DataBindings.Clear();
			this.uxUpdatedBy.DataBindings.Add("Text", this.uxBindingSource, "UpdatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUpdatedDate.DataBindings.Clear();
			this.uxUpdatedDate.DataBindings.Add("Value", this.uxBindingSource, "UpdatedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TestProductEditControlBase"/> class.
		/// </summary>
		public TestProductEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_TestProduct != null) _TestProduct.Validate();
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
			this.uxProductTypeId = new System.Windows.Forms.TextBox();
			uxProductTypeIdLabel = new System.Windows.Forms.Label();
			this.uxDownloadId = new System.Windows.Forms.TextBox();
			uxDownloadIdLabel = new System.Windows.Forms.Label();
			this.uxManufacturerId = new System.Windows.Forms.TextBox();
			uxManufacturerIdLabel = new System.Windows.Forms.Label();
			this.uxBrandName = new System.Windows.Forms.TextBox();
			uxBrandNameLabel = new System.Windows.Forms.Label();
			this.uxProductName = new System.Windows.Forms.TextBox();
			uxProductNameLabel = new System.Windows.Forms.Label();
			this.uxProductCode = new System.Windows.Forms.TextBox();
			uxProductCodeLabel = new System.Windows.Forms.Label();
			this.uxUniqueIdentifier = new System.Windows.Forms.TextBox();
			uxUniqueIdentifierLabel = new System.Windows.Forms.Label();
			this.uxTypeName = new System.Windows.Forms.TextBox();
			uxTypeNameLabel = new System.Windows.Forms.Label();
			this.uxModelName = new System.Windows.Forms.TextBox();
			uxModelNameLabel = new System.Windows.Forms.Label();
			this.uxDisplayName = new System.Windows.Forms.TextBox();
			uxDisplayNameLabel = new System.Windows.Forms.Label();
			this.uxProductLink = new System.Windows.Forms.TextBox();
			uxProductLinkLabel = new System.Windows.Forms.Label();
			this.uxConnectorCode = new System.Windows.Forms.TextBox();
			uxConnectorCodeLabel = new System.Windows.Forms.Label();
			this.uxBaseId = new System.Windows.Forms.TextBox();
			uxBaseIdLabel = new System.Windows.Forms.Label();
			this.uxOrgProductId = new System.Windows.Forms.TextBox();
			uxOrgProductIdLabel = new System.Windows.Forms.Label();
			this.uxImageFileType = new System.Windows.Forms.TextBox();
			uxImageFileTypeLabel = new System.Windows.Forms.Label();
			this.uxFullImageFileType = new System.Windows.Forms.TextBox();
			uxFullImageFileTypeLabel = new System.Windows.Forms.Label();
			this.uxStatus = new System.Windows.Forms.TextBox();
			uxStatusLabel = new System.Windows.Forms.Label();
			this.uxAddedBy = new System.Windows.Forms.TextBox();
			uxAddedByLabel = new System.Windows.Forms.Label();
			this.uxAddedDate = new System.Windows.Forms.DateTimePicker();
			uxAddedDateLabel = new System.Windows.Forms.Label();
			this.uxUpdatedBy = new System.Windows.Forms.TextBox();
			uxUpdatedByLabel = new System.Windows.Forms.Label();
			this.uxUpdatedDate = new System.Windows.Forms.DateTimePicker();
			uxUpdatedDateLabel = new System.Windows.Forms.Label();
			
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
			// uxProductTypeIdLabel
			//
			this.uxProductTypeIdLabel.Name = "uxProductTypeIdLabel";
			this.uxProductTypeIdLabel.Text = "Product Type Id:";
			this.uxProductTypeIdLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxProductTypeIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductTypeIdLabel);			
			//
			// uxProductTypeId
			//
			this.uxProductTypeId.Name = "uxProductTypeId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductTypeId);
			this.uxProductTypeId.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxProductTypeId);
			//
			// uxDownloadIdLabel
			//
			this.uxDownloadIdLabel.Name = "uxDownloadIdLabel";
			this.uxDownloadIdLabel.Text = "Download Id:";
			this.uxDownloadIdLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxDownloadIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDownloadIdLabel);			
			//
			// uxDownloadId
			//
			this.uxDownloadId.Name = "uxDownloadId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDownloadId);
			this.uxDownloadId.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxDownloadId);
			//
			// uxManufacturerIdLabel
			//
			this.uxManufacturerIdLabel.Name = "uxManufacturerIdLabel";
			this.uxManufacturerIdLabel.Text = "Manufacturer Id:";
			this.uxManufacturerIdLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxManufacturerIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxManufacturerIdLabel);			
			//
			// uxManufacturerId
			//
			this.uxManufacturerId.Name = "uxManufacturerId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxManufacturerId);
			this.uxManufacturerId.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxManufacturerId);
			//
			// uxBrandNameLabel
			//
			this.uxBrandNameLabel.Name = "uxBrandNameLabel";
			this.uxBrandNameLabel.Text = "Brand Name:";
			this.uxBrandNameLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxBrandNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBrandNameLabel);			
			//
			// uxBrandName
			//
			this.uxBrandName.Name = "uxBrandName";
			this.uxBrandName.Width = 250;
			this.uxBrandName.MaxLength = 500;
			//this.uxTableLayoutPanel.Controls.Add(this.uxBrandName);
			this.uxBrandName.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxBrandName);
			//
			// uxProductNameLabel
			//
			this.uxProductNameLabel.Name = "uxProductNameLabel";
			this.uxProductNameLabel.Text = "Product Name:";
			this.uxProductNameLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxProductNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductNameLabel);			
			//
			// uxProductName
			//
			this.uxProductName.Name = "uxProductName";
			this.uxProductName.Width = 250;
			this.uxProductName.MaxLength = 500;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductName);
			this.uxProductName.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxProductName);
			//
			// uxProductCodeLabel
			//
			this.uxProductCodeLabel.Name = "uxProductCodeLabel";
			this.uxProductCodeLabel.Text = "Product Code:";
			this.uxProductCodeLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxProductCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductCodeLabel);			
			//
			// uxProductCode
			//
			this.uxProductCode.Name = "uxProductCode";
			this.uxProductCode.Width = 250;
			this.uxProductCode.MaxLength = 100;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductCode);
			this.uxProductCode.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxProductCode);
			//
			// uxUniqueIdentifierLabel
			//
			this.uxUniqueIdentifierLabel.Name = "uxUniqueIdentifierLabel";
			this.uxUniqueIdentifierLabel.Text = "Unique Identifier:";
			this.uxUniqueIdentifierLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxUniqueIdentifierLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUniqueIdentifierLabel);			
			//
			// uxUniqueIdentifier
			//
			this.uxUniqueIdentifier.Name = "uxUniqueIdentifier";
			this.uxUniqueIdentifier.Width = 250;
			this.uxUniqueIdentifier.MaxLength = 500;
			//this.uxTableLayoutPanel.Controls.Add(this.uxUniqueIdentifier);
			this.uxUniqueIdentifier.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxUniqueIdentifier);
			//
			// uxTypeNameLabel
			//
			this.uxTypeNameLabel.Name = "uxTypeNameLabel";
			this.uxTypeNameLabel.Text = "Type Name:";
			this.uxTypeNameLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxTypeNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTypeNameLabel);			
			//
			// uxTypeName
			//
			this.uxTypeName.Name = "uxTypeName";
			this.uxTypeName.Width = 250;
			this.uxTypeName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTypeName);
			this.uxTypeName.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxTypeName);
			//
			// uxModelNameLabel
			//
			this.uxModelNameLabel.Name = "uxModelNameLabel";
			this.uxModelNameLabel.Text = "Model Name:";
			this.uxModelNameLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxModelNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxModelNameLabel);			
			//
			// uxModelName
			//
			this.uxModelName.Name = "uxModelName";
			this.uxModelName.Width = 250;
			this.uxModelName.MaxLength = 150;
			//this.uxTableLayoutPanel.Controls.Add(this.uxModelName);
			this.uxModelName.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxModelName);
			//
			// uxDisplayNameLabel
			//
			this.uxDisplayNameLabel.Name = "uxDisplayNameLabel";
			this.uxDisplayNameLabel.Text = "Display Name:";
			this.uxDisplayNameLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxDisplayNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDisplayNameLabel);			
			//
			// uxDisplayName
			//
			this.uxDisplayName.Name = "uxDisplayName";
			this.uxDisplayName.Width = 250;
			this.uxDisplayName.MaxLength = 150;
			//this.uxTableLayoutPanel.Controls.Add(this.uxDisplayName);
			this.uxDisplayName.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxDisplayName);
			//
			// uxProductLinkLabel
			//
			this.uxProductLinkLabel.Name = "uxProductLinkLabel";
			this.uxProductLinkLabel.Text = "Product Link:";
			this.uxProductLinkLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxProductLinkLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductLinkLabel);			
			//
			// uxProductLink
			//
			this.uxProductLink.Name = "uxProductLink";
			this.uxProductLink.Width = 250;
			this.uxProductLink.MaxLength = 1000;
			//this.uxTableLayoutPanel.Controls.Add(this.uxProductLink);
			this.uxProductLink.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxProductLink);
			//
			// uxConnectorCodeLabel
			//
			this.uxConnectorCodeLabel.Name = "uxConnectorCodeLabel";
			this.uxConnectorCodeLabel.Text = "Connector Code:";
			this.uxConnectorCodeLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxConnectorCodeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxConnectorCodeLabel);			
			//
			// uxConnectorCode
			//
			this.uxConnectorCode.Name = "uxConnectorCode";
			this.uxConnectorCode.Width = 250;
			this.uxConnectorCode.MaxLength = 1000;
			//this.uxTableLayoutPanel.Controls.Add(this.uxConnectorCode);
			this.uxConnectorCode.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxConnectorCode);
			//
			// uxBaseIdLabel
			//
			this.uxBaseIdLabel.Name = "uxBaseIdLabel";
			this.uxBaseIdLabel.Text = "Base Id:";
			this.uxBaseIdLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxBaseIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBaseIdLabel);			
			//
			// uxBaseId
			//
			this.uxBaseId.Name = "uxBaseId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBaseId);
			this.uxBaseId.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxBaseId);
			//
			// uxOrgProductIdLabel
			//
			this.uxOrgProductIdLabel.Name = "uxOrgProductIdLabel";
			this.uxOrgProductIdLabel.Text = "Org Product Id:";
			this.uxOrgProductIdLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxOrgProductIdLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrgProductIdLabel);			
			//
			// uxOrgProductId
			//
			this.uxOrgProductId.Name = "uxOrgProductId";
			//this.uxTableLayoutPanel.Controls.Add(this.uxOrgProductId);
			this.uxOrgProductId.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxOrgProductId);
			//
			// uxImageFileTypeLabel
			//
			this.uxImageFileTypeLabel.Name = "uxImageFileTypeLabel";
			this.uxImageFileTypeLabel.Text = "Image File Type:";
			this.uxImageFileTypeLabel.Location = new System.Drawing.Point(3, 390);
			this.Controls.Add(this.uxImageFileTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxImageFileTypeLabel);			
			//
			// uxImageFileType
			//
			this.uxImageFileType.Name = "uxImageFileType";
			this.uxImageFileType.Width = 250;
			this.uxImageFileType.MaxLength = 1;
			//this.uxTableLayoutPanel.Controls.Add(this.uxImageFileType);
			this.uxImageFileType.Location = new System.Drawing.Point(160, 390);
			this.Controls.Add(this.uxImageFileType);
			//
			// uxFullImageFileTypeLabel
			//
			this.uxFullImageFileTypeLabel.Name = "uxFullImageFileTypeLabel";
			this.uxFullImageFileTypeLabel.Text = "Full Image File Type:";
			this.uxFullImageFileTypeLabel.Location = new System.Drawing.Point(3, 416);
			this.Controls.Add(this.uxFullImageFileTypeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFullImageFileTypeLabel);			
			//
			// uxFullImageFileType
			//
			this.uxFullImageFileType.Name = "uxFullImageFileType";
			this.uxFullImageFileType.Width = 250;
			this.uxFullImageFileType.MaxLength = 1;
			//this.uxTableLayoutPanel.Controls.Add(this.uxFullImageFileType);
			this.uxFullImageFileType.Location = new System.Drawing.Point(160, 416);
			this.Controls.Add(this.uxFullImageFileType);
			//
			// uxStatusLabel
			//
			this.uxStatusLabel.Name = "uxStatusLabel";
			this.uxStatusLabel.Text = "Status:";
			this.uxStatusLabel.Location = new System.Drawing.Point(3, 442);
			this.Controls.Add(this.uxStatusLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatusLabel);			
			//
			// uxStatus
			//
			this.uxStatus.Name = "uxStatus";
			this.uxStatus.Width = 250;
			this.uxStatus.MaxLength = 1;
			//this.uxTableLayoutPanel.Controls.Add(this.uxStatus);
			this.uxStatus.Location = new System.Drawing.Point(160, 442);
			this.Controls.Add(this.uxStatus);
			//
			// uxAddedByLabel
			//
			this.uxAddedByLabel.Name = "uxAddedByLabel";
			this.uxAddedByLabel.Text = "Added By:";
			this.uxAddedByLabel.Location = new System.Drawing.Point(3, 468);
			this.Controls.Add(this.uxAddedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddedByLabel);			
			//
			// uxAddedBy
			//
			this.uxAddedBy.Name = "uxAddedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddedBy);
			this.uxAddedBy.Location = new System.Drawing.Point(160, 468);
			this.Controls.Add(this.uxAddedBy);
			//
			// uxAddedDateLabel
			//
			this.uxAddedDateLabel.Name = "uxAddedDateLabel";
			this.uxAddedDateLabel.Text = "Added Date:";
			this.uxAddedDateLabel.Location = new System.Drawing.Point(3, 494);
			this.Controls.Add(this.uxAddedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddedDateLabel);			
			//
			// uxAddedDate
			//
			this.uxAddedDate.Name = "uxAddedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddedDate);
			this.uxAddedDate.Location = new System.Drawing.Point(160, 494);
			this.Controls.Add(this.uxAddedDate);
			//
			// uxUpdatedByLabel
			//
			this.uxUpdatedByLabel.Name = "uxUpdatedByLabel";
			this.uxUpdatedByLabel.Text = "Updated By:";
			this.uxUpdatedByLabel.Location = new System.Drawing.Point(3, 520);
			this.Controls.Add(this.uxUpdatedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedByLabel);			
			//
			// uxUpdatedBy
			//
			this.uxUpdatedBy.Name = "uxUpdatedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedBy);
			this.uxUpdatedBy.Location = new System.Drawing.Point(160, 520);
			this.Controls.Add(this.uxUpdatedBy);
			//
			// uxUpdatedDateLabel
			//
			this.uxUpdatedDateLabel.Name = "uxUpdatedDateLabel";
			this.uxUpdatedDateLabel.Text = "Updated Date:";
			this.uxUpdatedDateLabel.Location = new System.Drawing.Point(3, 546);
			this.Controls.Add(this.uxUpdatedDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedDateLabel);			
			//
			// uxUpdatedDate
			//
			this.uxUpdatedDate.Name = "uxUpdatedDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedDate);
			this.uxUpdatedDate.Location = new System.Drawing.Point(160, 546);
			this.Controls.Add(this.uxUpdatedDate);
			// 
			// TestProductEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "TestProductEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
		
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
        /// Indicates if the controls associated with the uxProductTypeId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductTypeIdVisible
        {
            get { return this.uxProductTypeId.Visible; }
            set
            {
                this.uxProductTypeIdLabel.Visible = value;
                this.uxProductTypeId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductTypeId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductTypeIdEnabled
        {
            get { return this.uxProductTypeId.Enabled; }
            set
            {
                this.uxProductTypeId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDownloadId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDownloadIdVisible
        {
            get { return this.uxDownloadId.Visible; }
            set
            {
                this.uxDownloadIdLabel.Visible = value;
                this.uxDownloadId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDownloadId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDownloadIdEnabled
        {
            get { return this.uxDownloadId.Enabled; }
            set
            {
                this.uxDownloadId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxManufacturerId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxManufacturerIdVisible
        {
            get { return this.uxManufacturerId.Visible; }
            set
            {
                this.uxManufacturerIdLabel.Visible = value;
                this.uxManufacturerId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxManufacturerId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxManufacturerIdEnabled
        {
            get { return this.uxManufacturerId.Enabled; }
            set
            {
                this.uxManufacturerId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBrandName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBrandNameVisible
        {
            get { return this.uxBrandName.Visible; }
            set
            {
                this.uxBrandNameLabel.Visible = value;
                this.uxBrandName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBrandName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBrandNameEnabled
        {
            get { return this.uxBrandName.Enabled; }
            set
            {
                this.uxBrandName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductNameVisible
        {
            get { return this.uxProductName.Visible; }
            set
            {
                this.uxProductNameLabel.Visible = value;
                this.uxProductName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductNameEnabled
        {
            get { return this.uxProductName.Enabled; }
            set
            {
                this.uxProductName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductCodeVisible
        {
            get { return this.uxProductCode.Visible; }
            set
            {
                this.uxProductCodeLabel.Visible = value;
                this.uxProductCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductCodeEnabled
        {
            get { return this.uxProductCode.Enabled; }
            set
            {
                this.uxProductCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUniqueIdentifier property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUniqueIdentifierVisible
        {
            get { return this.uxUniqueIdentifier.Visible; }
            set
            {
                this.uxUniqueIdentifierLabel.Visible = value;
                this.uxUniqueIdentifier.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUniqueIdentifier property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUniqueIdentifierEnabled
        {
            get { return this.uxUniqueIdentifier.Enabled; }
            set
            {
                this.uxUniqueIdentifier.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxTypeName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTypeNameVisible
        {
            get { return this.uxTypeName.Visible; }
            set
            {
                this.uxTypeNameLabel.Visible = value;
                this.uxTypeName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTypeName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTypeNameEnabled
        {
            get { return this.uxTypeName.Enabled; }
            set
            {
                this.uxTypeName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxModelName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxModelNameVisible
        {
            get { return this.uxModelName.Visible; }
            set
            {
                this.uxModelNameLabel.Visible = value;
                this.uxModelName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxModelName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxModelNameEnabled
        {
            get { return this.uxModelName.Enabled; }
            set
            {
                this.uxModelName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDisplayName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDisplayNameVisible
        {
            get { return this.uxDisplayName.Visible; }
            set
            {
                this.uxDisplayNameLabel.Visible = value;
                this.uxDisplayName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDisplayName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDisplayNameEnabled
        {
            get { return this.uxDisplayName.Enabled; }
            set
            {
                this.uxDisplayName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxProductLink property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxProductLinkVisible
        {
            get { return this.uxProductLink.Visible; }
            set
            {
                this.uxProductLinkLabel.Visible = value;
                this.uxProductLink.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxProductLink property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxProductLinkEnabled
        {
            get { return this.uxProductLink.Enabled; }
            set
            {
                this.uxProductLink.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxConnectorCode property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxConnectorCodeVisible
        {
            get { return this.uxConnectorCode.Visible; }
            set
            {
                this.uxConnectorCodeLabel.Visible = value;
                this.uxConnectorCode.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxConnectorCode property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxConnectorCodeEnabled
        {
            get { return this.uxConnectorCode.Enabled; }
            set
            {
                this.uxConnectorCode.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBaseId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBaseIdVisible
        {
            get { return this.uxBaseId.Visible; }
            set
            {
                this.uxBaseIdLabel.Visible = value;
                this.uxBaseId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBaseId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBaseIdEnabled
        {
            get { return this.uxBaseId.Enabled; }
            set
            {
                this.uxBaseId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxOrgProductId property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxOrgProductIdVisible
        {
            get { return this.uxOrgProductId.Visible; }
            set
            {
                this.uxOrgProductIdLabel.Visible = value;
                this.uxOrgProductId.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxOrgProductId property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxOrgProductIdEnabled
        {
            get { return this.uxOrgProductId.Enabled; }
            set
            {
                this.uxOrgProductId.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxImageFileType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxImageFileTypeVisible
        {
            get { return this.uxImageFileType.Visible; }
            set
            {
                this.uxImageFileTypeLabel.Visible = value;
                this.uxImageFileType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxImageFileType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxImageFileTypeEnabled
        {
            get { return this.uxImageFileType.Enabled; }
            set
            {
                this.uxImageFileType.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFullImageFileType property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFullImageFileTypeVisible
        {
            get { return this.uxFullImageFileType.Visible; }
            set
            {
                this.uxFullImageFileTypeLabel.Visible = value;
                this.uxFullImageFileType.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFullImageFileType property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFullImageFileTypeEnabled
        {
            get { return this.uxFullImageFileType.Enabled; }
            set
            {
                this.uxFullImageFileType.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxStatus property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxStatusVisible
        {
            get { return this.uxStatus.Visible; }
            set
            {
                this.uxStatusLabel.Visible = value;
                this.uxStatus.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxStatus property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxStatusEnabled
        {
            get { return this.uxStatus.Enabled; }
            set
            {
                this.uxStatus.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddedByVisible
        {
            get { return this.uxAddedBy.Visible; }
            set
            {
                this.uxAddedByLabel.Visible = value;
                this.uxAddedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddedByEnabled
        {
            get { return this.uxAddedBy.Enabled; }
            set
            {
                this.uxAddedBy.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddedDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddedDateVisible
        {
            get { return this.uxAddedDate.Visible; }
            set
            {
                this.uxAddedDateLabel.Visible = value;
                this.uxAddedDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddedDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddedDateEnabled
        {
            get { return this.uxAddedDate.Enabled; }
            set
            {
                this.uxAddedDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUpdatedByVisible
        {
            get { return this.uxUpdatedBy.Visible; }
            set
            {
                this.uxUpdatedByLabel.Visible = value;
                this.uxUpdatedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUpdatedByEnabled
        {
            get { return this.uxUpdatedBy.Enabled; }
            set
            {
                this.uxUpdatedBy.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUpdatedDateVisible
        {
            get { return this.uxUpdatedDate.Visible; }
            set
            {
                this.uxUpdatedDateLabel.Visible = value;
                this.uxUpdatedDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUpdatedDateEnabled
        {
            get { return this.uxUpdatedDate.Enabled; }
            set
            {
                this.uxUpdatedDate.Enabled = value;
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
