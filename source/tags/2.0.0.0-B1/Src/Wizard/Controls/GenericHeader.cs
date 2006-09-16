using System;
using System.Drawing;

namespace NetTiers.Wizard.Controls
{
	/// <summary>
	/// Description résumée de GenericHeader.
	/// </summary>
	public class GenericHeader : SerialCoder.Windows.Controls.Wizard.Header
	{
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GenericHeader));
			// 
			// GenericHeader
			// 
			//this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
			this.Name = "GenericHeader";
			System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream file = thisExe.GetManifestResourceStream("NetTiers.Wizard.Resources.header.png");
			this.Image = Image.FromStream(file);
		}
	
		public GenericHeader()
		{
			InitializeComponent();

			this.BackColor = System.Drawing.Color.White;
			this.Description = "The .Net Data Tiers application block generator";
			this.Title = ".NetTiers Wizard";			
		}
	}
}
