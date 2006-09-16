using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace NetTiers.Wizard.Forms
{
	/// <summary>
	/// Summary description for GenerationProgress.
	/// </summary>
	public class GenerationProgress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label uxMessageLabel;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button uxCancelButton;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;


		private Thread gThread;
		private EventHandler generationCompleted;

		public GenerationProgress()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Load += new EventHandler(GenerationProgress_Load);	
			this.generationCompleted = new EventHandler(GenerationCompleted);
		}

		private void GenerationProgress_Load(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			progressBar1.Visible = true;
			uxMessageLabel.Visible = true;
			timer1.Start();

			gThread = new Thread(new ThreadStart(RenderTemplate));
			gThread.Start();	
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.uxMessageLabel = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.uxCancelButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// uxMessageLabel
			// 
			this.uxMessageLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxMessageLabel.Location = new System.Drawing.Point(8, 40);
			this.uxMessageLabel.Name = "uxMessageLabel";
			this.uxMessageLabel.Size = new System.Drawing.Size(456, 24);
			this.uxMessageLabel.TabIndex = 31;
			this.uxMessageLabel.Text = "label1";
			this.uxMessageLabel.Visible = false;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 8);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(464, 23);
			this.progressBar1.TabIndex = 30;
			this.progressBar1.Visible = false;
			// 
			// uxCancelButton
			// 
			this.uxCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.uxCancelButton.Location = new System.Drawing.Point(200, 72);
			this.uxCancelButton.Name = "uxCancelButton";
			this.uxCancelButton.TabIndex = 33;
			this.uxCancelButton.Text = "&Cancel";
			this.uxCancelButton.Click += new System.EventHandler(this.uxCancelButton_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// GenerationProgress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 103);
			this.ControlBox = false;
			this.Controls.Add(this.uxCancelButton);
			this.Controls.Add(this.uxMessageLabel);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "GenerationProgress";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generation in progress...";
			this.ResumeLayout(false);

		}
		#endregion

		private void RenderTemplate()
		{	
			try
			{
				Program.Context.Template.RenderToString();
				BeginInvoke(generationCompleted, new object[] {this, EventArgs.Empty});
			}
			catch(CodeSmith.Engine.CodeTemplateValidationException ex)
			{
				MessageBox.Show(string.Format("{0}", ex));
			}
		}

		private void uxCancelButton_Click(object sender, System.EventArgs e)
		{
			if (gThread.IsAlive)
			{
				gThread.Abort();
			}
			
			this.Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Text = string.Format("{0}...", Program.Context.CurrentPhase);
			
			if (Program.Context.CurrentPhase == "Templates compilation")
			{
				progressBar1.Maximum = Program.Context.TotalTemplates;
				this.progressBar1.Value = Program.Context.CurrentTemplateIndex;
			}
			else
			{
				progressBar1.Maximum = Program.Context.TotalObjects;
				this.progressBar1.Value = Program.Context.CurrentObjectIndex;
			}

			this.uxMessageLabel.Text = Program.Context.CurrentFileName;
		}

		private void GenerationCompleted(object sender, EventArgs e)
		{
			timer1.Stop();
			progressBar1.Value = progressBar1.Maximum;
			Cursor.Current = Cursors.Default;
			uxMessageLabel.Text = string.Format("Finished. {0} files generated.", Program.Context.Counter);
			this.uxCancelButton.Text = "&Close";
			//uxMessageLabel.Visible = true;			
		}	

		
	}
}
