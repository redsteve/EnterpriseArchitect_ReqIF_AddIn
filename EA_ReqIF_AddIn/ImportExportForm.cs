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
		private Package currentSelectedPackage;
		
		public ImportExportForm(Repository repository)
		{
			this.repository = repository;
			InitializeComponent();
			ShowCurrentSelectedPackage();
		}
		
		private void OnRadioButtonsSelectionChanged(object sender, EventArgs eventArgs)
		{
			validateXmlCheckBox.Enabled = importRequirementsRadioButton.Checked;
		}
		
		private void OnFileDialogButtonClick(object sender, EventArgs eventArgs)
		{
			string fileName = RetrieveFilenameFromFileDialog();
			if (fileName != null)
			{
				pathFileTextBox.Text = fileName;
			}
		}
		
		private void OnStartButtonClick(object sender, EventArgs eventArgs)
		{
			if (importRequirementsRadioButton.Checked)
			{
				ImportRequirementsFromReqIfFile();
			} else {
				ExportRequirementsToReqIfFile();
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
				currentSelectedPackage = (EA.Package)item;
				string text = "\"" + currentSelectedPackage.Name + "\" (ID: " +
					currentSelectedPackage.PackageID + ")";
				selectedPackageTextBox.Text = text;
			}
		}
		
		private string RetrieveFilenameFromFileDialog()
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
		
		private bool IsValidationOfReqIfFileDesired()
		{
			return (validateXmlCheckBox.Enabled && validateXmlCheckBox.Checked);
		}
		
		private void ImportRequirementsFromReqIfFile()
		{
			string filename = pathFileTextBox.Text;
			ReqIfParser reqIfParser = null;
			RequirementsFromReqIfFileImporter importer =
				new RequirementsFromReqIfFileImporter(currentSelectedPackage);
			
			try
			{
				bool doValidate = IsValidationOfReqIfFileDesired();
				reqIfParser = new ReqIfParser(filename, doValidate);
				reqIfParser.Parse(importer);
			}
			catch (Exception ex)
			{
				MessageBox.Show("The following exception has occured: " +
				                ex.GetType().ToString() + "\n" +
				                ex.Message, "Error!", MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			}
		}
		
		private void ExportRequirementsToReqIfFile()
		{
			object item;
			if (repository.GetTreeSelectedItem(out item) == ObjectType.otPackage)
			{
				EA.Package package = (EA.Package)item;
				
				short numOfPackages = package.Packages.Count;
				for (short index = 0; index < numOfPackages; index++)
				{
					
				}
			}
		}
	}
}
