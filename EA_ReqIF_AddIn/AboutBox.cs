/*
 * $Id:$
 */

using System;
using System.Windows.Forms;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This is a simple dialog box showing version and copyright informations of
	/// the Add-In.
	/// </summary>
	public partial class AboutBox : Form
	{
		public AboutBox()
		{
			InitializeComponent();
		}
		
		private void OnOkButtonClick(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
