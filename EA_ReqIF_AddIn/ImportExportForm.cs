/*
 * $Id:$
 */

using System;
using System.IO;
using System.Windows.Forms;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of ImportExportForm.
	/// </summary>
	public partial class ImportExportForm : Form
	{
		private EA.Repository repository;
		
		public ImportExportForm(EA.Repository repository)
		{
			this.repository = repository;
			InitializeComponent();
		}
		
		private void OnFileDialogButtonClick(object sender, EventArgs e)
		{
			string fileName = retrieveFilenameFromFileDialog();
			if (fileName != null)
			{
				pathFileTextBox.Text = fileName;
			}
		}
		
		private void OnStartButtonClick(object sender, EventArgs e)
		{
			if (importRequirementsRadioButton.Checked)
			{
				importRequirementsFromReqIfFile();
			} else {
				exportRequirementsToReqIfFile();
			}
		}
		
		private void OnCancelButtonClick(object sender, System.EventArgs e)
		{
			Close();
		}
		
		private void OnValidatePathFileTextBox(object sender, System.EventArgs e)
		{
			if (pathFileTextBox.Text.Length == 0)
			{
				this.pathFileTextBoxErrorProvider.SetError(pathFileTextBox,
				                                           "You must provide a valid path and file name!");
			}
		}
		
		private string retrieveFilenameFromFileDialog()
		{
			string fileName;
			
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Choose ReqIF file";
			openFileDialog.Filter = "ReqIF XML files (*.xml)|*.xml";
			
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				fileName = openFileDialog.FileName;
			} else {
				fileName = string.Empty;
			}
			
			return fileName;
		}
		
		private void importRequirementsFromReqIfFile()
		{
			string filename = pathFileTextBox.Text;
			ReqIfParser reqIfParser = null;
			RequirementsFromReqIfFileImporter importer = new RequirementsFromReqIfFileImporter();
			
			try
			{
				reqIfParser = new ReqIfParser(ref filename);
				reqIfParser.parse(importer);
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show("The following error has occured:\n" +
				                ex.Message, "Error", MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			}
		}
		
		private void exportRequirementsToReqIfFile()
		{
			
		}
	}
}
