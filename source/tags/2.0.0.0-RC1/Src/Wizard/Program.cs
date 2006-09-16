using System;
using System.IO;
using System.Windows.Forms;

namespace NetTiers.Wizard
{
	/// <summary>
	/// Description résumée de Program.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{			
			if (Context.NetTiersPath.Length == 0 )
			{
				MessageBox.Show("Please edit the NetTiers.Wizard.exe.config file and set the NetTiersPath settings.");
				return;
			}


			if (args.Length>0)
			{
				if (File.Exists(args[0]))
				{
					try
					{
						Program.Context.LoadSettingsFile(args[0]);

						if (args.Length > 1 && (args[1].ToLower() == "-generate" || args[1].ToLower() == "/generate" || args[1].ToLower() == "-g" || args[1].ToLower() == "/g"))
						{
							//Generate();
							Application.Run(new Forms.GenerationProgress());
							return;
						}
					}
					catch(Exception e)
					{
						MessageBox.Show(string.Format("An error occured while loading the file {0}.", args[0]));
						System.Diagnostics.Debug.Write(e);
					}
				}
				else
				{
					MessageBox.Show(string.Format("File {0} do not exists.", args[0]));
				}
			}
			
			Application.Run(new Forms.Main());
		}

		private static volatile Context current;
		private static object syncRoot = new Object();

		internal static Context Context
		{
			get 
			{
				if (current == null) 
				{
					lock (syncRoot)
					{
						if (current == null) 
							current = new Context();
					}
				}

				return current;
			}
		}

//		public static void Generate()
//		{
//			Forms.GenerationProgress genForm = new NetTiers.Wizard.Forms.GenerationProgress();
//			genForm.ShowDialog();
//		}
	}
}
