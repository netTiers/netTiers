#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using netTiers.Petshop.Web.Data;

#endregion

namespace NetTiers
{

    public class EntityGridView : GridView
    {
        #region class member variables
        private string _excelExportFileName = "Export.xls";
        private string _defaultSortColumnName = string.Empty;
        private SortDirection _defaultSortDirection = SortDirection.Ascending;
        private string _exportToExcelText = "Excel";
        private bool _allowExportToExcel = true;
        private int _pageSelectorPageSizeInterval = 5;
        private TableRow _gridPagerRow = null;
        #endregion

        #region Properties
        /// <summary>
        /// Set / Gets the Export File Name
        /// </summary>
        [
        Description("Set / Gets the Export File Name"),
        Category("Misc"),
        DefaultValue("Export.xls"),
        ]
        public string ExcelExportFileName
        {
            get { return _excelExportFileName; }
            set { _excelExportFileName = value; }
        }

        /// <summary>
        /// Gets / Sets Page Selector PageSize Interval
        /// </summary>
        [
        Description("Gets / Sets Page Selector PageSize Interval"),
        Category("Misc"),
        DefaultValue("10"),
        ]
        public int PageSelectorPageSizeInterval
        {
            get { return _pageSelectorPageSizeInterval; }
            set { _pageSelectorPageSizeInterval = value; }
        }

        /// <summary>
        /// Get / Sest the Export to excel text
        /// </summary>
        [
        Description("Gets / Sets the Export to Excel Text"),
        Category("Misc"),
        DefaultValue("Export"),
        ]
        public string ExportToExcelText
        {
            get
            {
                return _exportToExcelText;
            }
            set
            {
                _exportToExcelText = value;
            }
        }

        /// <summary>
        /// Enable/Disable ExportToExcel
        /// </summary>
        [
        Description("Whether Exporting Or Not to Excel file"),
        Category("Behavior"),
        DefaultValue("true"),
        ]
        public bool AllowExportToExcel
        {
            get { return _allowExportToExcel; }
            set { _allowExportToExcel = value; }
        }

        /// <summary>
        /// Sets / Gets Default Sort Column Name
        /// </summary>
        [
        Description("Sets / Gets Default Sort Column Name"),
        Category("Behavior"),
        DefaultValue(""),
        ]
        public string DefaultSortColumnName
        {
            get
            {
                return (_defaultSortColumnName == string.Empty) ? GetDefaultSortColumn() : _defaultSortColumnName;

            }
            set { _defaultSortColumnName = value; }
        }

        /// <summary>
        /// Setting the default sort order direction 
        /// </summary>
        [
        Description("Default Sort Order Direction"),
        Category("Misc"),
        Editor("System.Web.UI.WebControls.SortDirection", typeof(System.Web.UI.WebControls.SortDirection)),
        DefaultValue("SortDirection.Ascending"),
        ]
        public SortDirection DefaultSortDirection
        {
            get { return _defaultSortDirection; }
            set { _defaultSortDirection = value; }
        }

        /// <summary>
        /// Enable/Disable MultiColumn Sorting.
        /// </summary>
        [
        Description("Whether Sorting On more than one column is enabled"),
        Category("Behavior"),
        DefaultValue("false"),
        ]
        public bool AllowMultiColumnSorting
        {
            get
            {
                object o = ViewState["EnableMultiColumnSorting"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                AllowSorting = true;
                ViewState["EnableMultiColumnSorting"] = value;
            }
        }
        /// <summary>
        /// Get or Set Image location to be used to display Ascending Sort order.
        /// </summary>
        [
        Description("Image to display for Ascending Sort"),
        Category("Misc"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue(""),
        ]
        public string SortAscImageUrl
        {
            get
            {
                object o = ViewState["SortImageAsc"];
                return (o != null ? o.ToString() : "");
            }
            set
            {
                ViewState["SortImageAsc"] = value;
            }
        }
        /// <summary>
        /// Get or Set Image location to be used to display Ascending Sort order.
        /// </summary>
        [
        Description("Image to display for Descending Sort"),
        Category("Misc"),
        Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),
        DefaultValue(""),
        ]
        public string SortDescImageUrl
        {
            get
            {
                object o = ViewState["SortImageDesc"];
                return (o != null ? o.ToString() : "");
            }
            set
            {
                ViewState["SortImageDesc"] = value;
            }
        }

        /// <summary>
        /// Total Records Count being assigned the value in the DataSource_Selected event
        /// </summary>
        protected int RecordsCount
        {
            get
            {
                return (int)ViewState["_recordsCount"];
            }
            set
            {
                ViewState["_recordsCount"] = value;
            }
        }
        #endregion

        #region Life Cycle

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Page.IsPostBack == false)
            {
                this.Sort(DefaultSortColumnName, _defaultSortDirection);
            }

            DataSourceControl dsc = (DataSourceControl)this.Parent.FindControl(string.Format("{0}", this.DataSourceID));

            System.Reflection.EventInfo eventInfo = dsc.GetType().GetEvent("Selected");
            Delegate d = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, "dsc_Selected");

            eventInfo.AddEventHandler(dsc, d);

        }

        void dsc_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            RecordsCount = e.AffectedRows;
        }

        void dsc_Selected(object sender, netTiers.Petshop.Web.Data.EntityDataSourceMethodEventArgs e)
        {
            RecordsCount = e.AffectedRows;
        }


        protected override void OnSorting(GridViewSortEventArgs e)
        {
            if (AllowMultiColumnSorting)
                e.SortExpression = GetSortExpression(e);

            base.OnSorting(e);
        }

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (SortExpression != String.Empty)
                    DisplaySortOrderImages(SortExpression, e.Row);
            }
            else if (e.Row.RowType == DataControlRowType.Pager)
            {
                DisplayPageSizeSelector(e.Row);
                _gridPagerRow = e.Row;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            if (this.RecordsCount > 0)
            _gridPagerRow.Visible = true;
        }
        #endregion

        #region Help Methonds
        protected string GetDefaultSortColumn()
        {
            string SortColumnName = string.Empty;

            for (int i = 0; i <= this.Columns.Count; i++)
            {
                SortColumnName = this.Columns[i].SortExpression;
                if (SortColumnName != string.Empty)
                {
                    break;
                }
            }

            return SortColumnName;
        }

        private void DisplayPageSizeSelector(GridViewRow dgItem)
        {
            TableCell pagerCell;
            TableRow pagerRow;

            int j = 0;
            System.Web.UI.WebControls.DropDownList cboPageSize = new DropDownList();
            cboPageSize.AutoPostBack = true;

            ((DropDownList)(cboPageSize)).SelectedIndexChanged += new EventHandler(this.cboPageSize_SelectedIndexChanged);

            // -- we don't want to allow to page more then 500 records at a time
            j = this.RecordsCount + _pageSelectorPageSizeInterval;
            for (int i = _pageSelectorPageSizeInterval; i <= ((j > 250) ? 250 : j); )
            {
                cboPageSize.Items.Add(i.ToString());
                i += _pageSelectorPageSizeInterval;
            }

            if (cboPageSize.Items.FindByText(this.PageSize.ToString()) != null)
            {
                cboPageSize.Items.FindByText(this.PageSize.ToString()).Selected = true;
            }

            pagerRow = dgItem;
            pagerCell = ((TableCell)(pagerRow.Controls[0]));
            TableRow pagerTableRow = ((Table)pagerCell.Controls[0]).Rows[0];
            TableCell cell = new TableCell();
            cell.Text = "Show page: ";
            cell.Wrap = false;
            pagerTableRow.Cells.AddAt(0, cell);

            cell = new TableCell();
            cell.Text = string.Format("&nbsp; (Total Records: {0})", RecordsCount);
            cell.Wrap = false;
            pagerTableRow.Cells.Add(cell);

            cell = new TableCell();
            cell.Width = Unit.Percentage(100);
            pagerTableRow.Cells.Add(cell);

            cell = new TableCell();
            cell.Controls.Add(ExcelButton());
            cell.Wrap = false;
            pagerTableRow.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "Records Per Page: ";
            cell.Wrap = false;
            cell.HorizontalAlign = HorizontalAlign.Right;
            pagerTableRow.Cells.Add(cell);

            cell = new TableCell();
            cell.Controls.Add(cboPageSize);
            cell.HorizontalAlign = HorizontalAlign.Right;
            pagerTableRow.Cells.Add(cell);
        }

        private LinkButton ExcelButton()
        {
            LinkButton lnkExport = new LinkButton();
            lnkExport.ToolTip = _exportToExcelText;
            lnkExport.Text = _exportToExcelText;
            lnkExport.Click += new EventHandler(lnkExport_Click);

            return lnkExport;
        }
        #endregion

        #region Controls Events
        /// <summary>
        /// Exporting all the records by rebinding the gridview and re-setting the page index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lnkExport_Click(object sender, EventArgs e)
        {
            this.AllowMultiColumnSorting = false;
            this.AllowPaging = false;
            this.AllowSorting = false;
            this.ShowFooter = false;
            this.EnableViewState = false;

            this.PageIndex = 0;
            this.PageSize = this.RecordsCount;
            this.DataSourceID = this.DataSourceID;
            this.DataBind();

            GridViewExcelExporter exp = new GridViewExcelExporter();
            exp.Export(_excelExportFileName, this.Page, this);
        }
        


        #region cboPageSize_SelectedIndexChanged
        /// <summary> 
        /// this function edits is being triggered whenever 'All' link is clicked
        /// </summary> 
        /// <paramname="sender"></param> 
        /// <paramname="e"></param> 
        private void cboPageSize_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // -- reset current page index to 0, that is nessessary so that there won't be a situation when datagrid current page index is off causing an exception
            this.PageIndex = 0;
            DropDownList cboPageSize = (DropDownList)sender;
            this.PageSize = int.Parse(cboPageSize.SelectedValue);
        }
        #endregion

        #endregion

        #region Protected Methods
        /// <summary>
        ///  Get Sort Expression by Looking up the existing Grid View Sort Expression 
        /// </summary>
        protected string GetSortExpression(GridViewSortEventArgs e)
        {
            string[] sortColumns = null;
            string sortAttribute = SortExpression;

            //Check to See if we have an existing Sort Order already in the Grid View.	
            //If so get the Sort Columns into an array
            if (sortAttribute != String.Empty)
            {
                sortColumns = sortAttribute.Split(",".ToCharArray());
            }

            //if User clicked on the columns in the existing sort sequence.
            //Toggle the sort order or remove the column from sort appropriately

            if (sortAttribute.IndexOf(e.SortExpression) > 0 || sortAttribute.StartsWith(e.SortExpression))
                sortAttribute = ModifySortExpression(sortColumns, e.SortExpression);
            else
                sortAttribute += String.Concat(",", e.SortExpression, " ASC ");
            return sortAttribute.TrimStart(",".ToCharArray()).TrimEnd(",".ToCharArray());

        }
        /// <summary>
        ///  Toggle the sort order or remove the column from sort appropriately
        /// </summary>
        protected string ModifySortExpression(string[] sortColumns, string sortExpression)
        {

            string ascSortExpression = String.Concat(sortExpression, " ASC ");
            string descSortExpression = String.Concat(sortExpression, " DESC ");

            for (int i = 0; i < sortColumns.Length; i++)
            {

                if (ascSortExpression.Equals(sortColumns[i]))
                {
                    sortColumns[i] = descSortExpression;
                }

                else if (descSortExpression.Equals(sortColumns[i]))
                {
                    Array.Clear(sortColumns, i, 1);
                }
            }

            return String.Join(",", sortColumns).Replace(",,", ",").TrimStart(",".ToCharArray());

        }
        /// <summary>
        ///  Lookup the Current Sort Expression to determine the Order of a specific item.
        /// </summary>
        protected void SearchSortExpression(string[] sortColumns, string sortColumn, out string sortOrder, out int sortOrderNo)
        {
            sortOrder = "";
            sortOrderNo = -1;
            for (int i = 0; i < sortColumns.Length; i++)
            {
                if (sortColumns[i].StartsWith(sortColumn))
                {
                    sortOrderNo = i + 1;
                    if (AllowMultiColumnSorting)
                        sortOrder = sortColumns[i].Substring(sortColumn.Length).Trim();
                    else
                        sortOrder = ((SortDirection == SortDirection.Ascending) ? "ASC" : "DESC");
                }
            }
        }
        /// <summary>
        ///  Display a graphic image for the Sort Order along with the sort sequence no.
        /// </summary>
        protected void DisplaySortOrderImages(string sortExpression, GridViewRow dgItem)
        {
            string[] sortColumns = sortExpression.Split(",".ToCharArray());

            for (int i = 0; i < dgItem.Cells.Count; i++)
            {
                if (dgItem.Cells[i].Controls.Count > 0 && dgItem.Cells[i].Controls[0] is LinkButton)
                {
                    string sortOrder;
                    int sortOrderNo;
                    string column = ((LinkButton)dgItem.Cells[i].Controls[0]).CommandArgument;
                    SearchSortExpression(sortColumns, column, out sortOrder, out sortOrderNo);
                    if (sortOrderNo > 0)
                    {
                        string sortImgLoc = (sortOrder.Equals("ASC") ? SortAscImageUrl : SortDescImageUrl);

                        if (sortImgLoc != String.Empty)
                        {
                            Image imgSortDirection = new Image();
                            imgSortDirection.ImageUrl = sortImgLoc;
                            dgItem.Cells[i].Controls.Add(imgSortDirection);
                            Label lblSortOrder = new Label();
                            lblSortOrder.Font.Size = FontUnit.Small;
                            lblSortOrder.Text = sortOrderNo.ToString();
                            dgItem.Cells[i].Controls.Add(lblSortOrder);

                        }
                        else
                        {

                            Label lblSortDirection = new Label();
                            lblSortDirection.Font.Size = FontUnit.XSmall;
                            lblSortDirection.Font.Name = "webdings";
                            lblSortDirection.EnableTheming = false;
                            lblSortDirection.Text = (sortOrder.Equals("ASC") ? "5" : "6");
                            dgItem.Cells[i].Controls.Add(lblSortDirection);

                            if (AllowMultiColumnSorting)
                            {
                                Literal litSortSeq = new Literal();
                                litSortSeq.Text = sortOrderNo.ToString();
                                dgItem.Cells[i].Controls.Add(litSortSeq);

                            }
                        }
                    }
                }
            }
        }
        #endregion
    }

    #region Excel Export Implementation


    /// <summary>
    /// Exports a datagrid to a excel file. 
    /// </summary>
    /// <requirements>Microsoft Excel 97 or above should be installed on the client machine in order to make 
    /// this function work
    /// </requirements>
    public class GridViewExcelExporter
    {
        public GridViewExcelExporter()
        {
        }


        /// <summary>
        /// Exports the datagrid to an Excel file with the name of the datasheet provided by the passed in parameter
        /// </summary>
        /// <param name="reportName">Name of the datasheet.
        /// </param>
        public virtual void Export(string reportName, Page CurrentPage, Control NtGridView)
        {
            System.Web.UI.HtmlControls.HtmlForm htmlForm = new System.Web.UI.HtmlControls.HtmlForm();
            CurrentPage.Controls.Add(htmlForm);
            htmlForm.Controls.Add(NtGridView);

            ClearChildControls((GridView)NtGridView);

            CurrentPage.Response.Clear();
            CurrentPage.Response.Buffer = true;

            CurrentPage.Response.AddHeader("Content-Disposition", "attachment; filename=" + reportName);
            CurrentPage.Response.ContentType = "application/vnd.ms-excel";
            CurrentPage.Response.ContentEncoding = System.Text.Encoding.UTF8;
            CurrentPage.Response.Charset = "";
            CurrentPage.EnableViewState = false;

            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
                htmlForm.RenderControl(htmlWriter);
                htmlWriter.Flush();

                CurrentPage.Response.Write(stringWriter.ToString());
                CurrentPage.Response.End();
            }
        }

        /// <summary>
        /// Iterates a control and its children controls, ensuring they are all LiteralControls
        /// <remarks>
        /// Only LiteralControl can call RenderControl(System.Web.UI.HTMLTextWriter htmlWriter) method. Otherwise 
        /// a runtime error will occur. This is the reason why this method exists.
        /// </remarks>
        /// </summary>
        /// <param name="control">The control to be cleared and verified</param>
        private void RecursiveClear(Control control)
        {
            //Clears children controls
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                RecursiveClear(control.Controls[i]);
            }

            //If it is a LinkButton, convert it to a LiteralControl
            if (control is LinkButton)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                literal.Text = ((LinkButton)control).Text;
                control.Parent.Controls.Remove(control);
            }
            //We don't need a button in the excel sheet, so simply delete it
            else if (control is Button)
            {
                control.Parent.Controls.Remove(control);
            }

            else if (control is Image)
            {
                if (((Image)control).Visible)
                {
                    control.Parent.Controls.Add(new LiteralControl("<span style='font-size:8px;'>o</span>"));
                }
                control.Parent.Controls.Remove(control);
            }
            //If it is a ListControl, copy the text to a new LiteralControl
            else if (control is ListControl)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = ((ListControl)control).SelectedItem.Text;
                }
                catch
                {
                }
                control.Parent.Controls.Remove(control);

            }
            //You may add more conditions when necessary

            return;
        }

        /// <summary>
        /// Clears the child controls of a Datagrid to make sure all controls are LiteralControls
        /// </summary>
        /// <param name="dg">Datagrid to be cleared and verified</param>
        protected void ClearChildControls(System.Web.UI.WebControls.GridView dg)
        {

            for (int i = dg.Columns.Count - 1; i >= 0; i--)
            {
                if (dg.Columns[i].GetType().Name == "ButtonColumn" || dg.Columns[i].GetType().Name == "CheckBoxField")
                {
                    dg.Columns.Remove(dg.Columns[i]);
                }
            }

            this.RecursiveClear(dg);

        }
    }

    #endregion
}