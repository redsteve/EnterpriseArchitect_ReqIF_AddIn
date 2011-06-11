using System;
using System.IO;
using System.Windows.Forms;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// The ImportExportForm is the main dialog of the add-in. It will be created
	/// and shown if the user selects the corresponding menu item.
	/// </summary>
	public partial class ImportExportForm : Form
	{
		private Repository repository;
		
		public ImportExportForm(Repository repository)
		{
			this.repository = repository;
			InitializeComponent();
			ShowCurrentSelectedPackage();
		}
		
		private void OnFileDialogButtonClick(object sender, EventArgs eventArgs)
		{
			string fileName = retrieveFilenameFromFileDialog();
			if (fileName != null)
			{
				pathFileTextBox.Text = fileName;
			}
		}
		
		private void OnStartButtonClick(object sender, EventArgs eventArgs)
		{
			if (importRequirementsRadioButton.Checked)
			{
				importRequirementsFromReqIfFile();
			} else {
				exportRequirementsToReqIfFile();
			}
		}
		
		private void OnCancelButtonClick(object sender, EventArgs eventArgs)
		{
			Close();
		}
		
		private void OnValidatePathFileTextBox(object sender, EventArgs eventArgs)
		{
			if (pathFileTextBox.Text.Length == 0)
			{
				this.pathFileTextBoxErrorProvider.SetError(pathFileTextBox,
				                                           "You must provide a valid path and file name!");
			}
		}
		
		private void ShowCurrentSelectedPackage()
		{
			object item;
			if (repository.GetTreeSelectedItem(out item) == ObjectType.otPackage)
			{
				EA.Package package = (EA.Package)item;
				string text = "\"" + package.Name + "\" (ID: " + package.PackageID + ")";
				selectedPackageTextBox.Text = text;
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
