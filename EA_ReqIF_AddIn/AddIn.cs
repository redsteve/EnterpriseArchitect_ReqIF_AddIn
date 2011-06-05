/*
 * $Id:$
 */
 
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This is the main add-in class, providing implementations
	/// to respond to several EA Add-In events. For more information,
	/// please refer to the Enterprise Architect SDK documentation:
    /// http://www.sparxsystems.com/uml_tool_guide/sdk_for_enterprise_architect/introduction_2.htm
	/// </summary>
	[ComVisible(true)]
	public sealed class AddIn
	{
		private const string menuHeaderTxt = "-&Requirements Interchange Format Add-In";
		private const string menuItemImportExportTxt = "&Import/Export Requirements";
		private const string menuItemAboutTxt = "&About...";

		/// <summary>
		/// This method is called before Enterprise Architect starts to check that
		/// the Add-In exists.
		/// </summary>
		/// <param name="repository">The EA.Repository object representing the currently
		/// opened Enterprise Architect model repository.</param>
		public String EA_Connect(EA.Repository repository)
		{
			// No special processing required!
			return "";
		}
		
		/// <summary>
		/// This method is called when user clicks the Add-Ins Menu item from within EA.
		/// It populates the menu with our desired selections.
		/// </summary>
		/// <param name="repository">The EA.Repository object representing the currently
		/// opened Enterprise Architect model repository.</param>
		/// <param name="location">A string representing the part of the user interface
		/// that brought up the menu. Can be <c>TreeView</c>, <c>MainMenu</c> or
		/// <c>Diagram</c>.</param>
		/// <param name="menuName">The name of the parent menu for which sub-items are to
		/// be defined. In the case of the top-level menu it is an empty string.</param>
		/// <returns>One of the following types:
		/// <list type="bullet">
		/// <item><description>A string indicating the label for a single menu item.
		/// </description></item>
		/// <item><description>An array of strings containing labels for multiple menu
		/// items.</description></item>
		/// <item><description><c>null</c> to indicate that no menu should be displayed.
		/// </description></item>
		/// </list>
		/// </returns>
		public object EA_GetMenuItems(EA.Repository repository, string location, string menuName) 
		{
			switch (menuName)
			{
				case "":
					return menuHeaderTxt;
					
				case menuHeaderTxt:
					string[] subMenuItems = { menuItemImportExportTxt, menuItemAboutTxt };
					return subMenuItems;
			}
			
			return null;
		}

		/// <summary>
		/// This method is called once when the menu has been opened to see what menu items are
		/// enabled and/or checked.
		/// </summary>
		/// <param name="repository">The EA.Repository object representing the currently
		/// opened Enterprise Architect model repository.</param>
		/// <param name="location">A string representing the part of the user interface
		/// that brought up the menu. Can be <c>TreeView</c>, <c>MainMenu</c> or
		/// <c>Diagram</c>.</param>
		/// <param name="menuName">The name of the parent menu for which sub-items are to
		/// be defined. In the case of the top-level menu it is an empty string.</param>
		/// <param name="itemName">The name of the option actually clicked.</param>
		/// <param name="isEnabled">Set this to false to disable an particular menu option.</param>
		/// <param name="isChecked">Set this to true to check an particular menu option.</param>
		public void EA_GetMenuState(EA.Repository repository, string location, string menuName, string itemName, ref bool isEnabled, ref bool isChecked)
		{
			if (itemName == menuItemImportExportTxt ||
			    itemName == menuHeaderTxt)
			{
				isEnabled = IsProjectOpen(repository);
			}
		}
		
		/// <summary>
		/// This method is called by Enterprise Architect in response to user selection of
		/// an menu item.
		/// </summary>
		/// <param name="repository">The EA.Repository object representing the currently
		/// opened Enterprise Architect model repository.</param>
		/// <param name="location">A string representing the part of the user interface
		/// that brought up the menu. Can be <c>TreeView</c>, <c>MainMenu</c> or
		/// <c>Diagram</c>.</param>
		/// <param name="menuName">The name of the parent menu. In case of the top-level menu
		/// it is an empty string.</param>
		/// <param name="itemName">The name of the option actually clicked.</param>
		public void EA_MenuClick(EA.Repository repository, string location, string menuName, string itemName)
		{
			if (! IsProjectOpen(repository))
				return;
			
			switch (itemName)
			{
				case menuItemImportExportTxt:
					showImportExportFormWindow(repository);
					break;
					
				case menuItemAboutTxt:
					showAboutDialog();
					break;
			}
		}
		
		/// <summary>
		/// This method is called by Enterprise Architect when it is closed. Can be
		/// used to do some cleanup work.
		/// </summary>
        public void EA_Disconnect()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
        }
	
		private void showImportExportFormWindow(EA.Repository repository)
		{
			Form importExportForm = new ImportExportForm(repository);
			importExportForm.Show();
		}
		
		private void showAboutDialog()
		{
			Form aboutBox = new AboutBox();
			aboutBox.Show();
		}
		
		private static bool IsProjectOpen(EA.Repository repository)
		{
			try
			{
				return (repository.Models != null);
			}
			catch
			{
				return false;
			}
		}
        
		/// <summary>
		/// The program entry point; only used when add-in is launched from outside EA for
		/// testing purposes. IMPORTANT: in this case the Add-In must be build as an .exe!
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			EA.Repository repo = null;
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ImportExportForm(repo));
		}
	}
}
