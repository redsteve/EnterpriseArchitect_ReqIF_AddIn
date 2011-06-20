namespace EA_ReqIF_AddIn
{
	partial class ImportExportForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label label2;
			System.Windows.Forms.GroupBox modeSelectionGroupBox;
			this.validateXmlCheckBox = new System.Windows.Forms.CheckBox();
			this.mergeRequirementsRadioButton = new System.Windows.Forms.RadioButton();
			this.importRequirementsRadioButton = new System.Windows.Forms.RadioButton();
			this.exportRequirementsRadioButton = new System.Windows.Forms.RadioButton();
			this.pathFileTextBox = new System.Windows.Forms.TextBox();
			this.fileDialogButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.pathFileTextBoxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.selectedPackageTextBox = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			modeSelectionGroupBox = new System.Windows.Forms.GroupBox();
			modeSelectionGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pathFileTextBoxErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.Location = new System.Drawing.Point(12, 214);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(407, 16);
			label2.TabIndex = 3;
			label2.Text = "Specify the path and the name of the ReqIF file:";
			// 
			// modeSelectionGroupBox
			// 
			modeSelectionGroupBox.Controls.Add(this.validateXmlCheckBox);
			modeSelectionGroupBox.Controls.Add(this.mergeRequirementsRadioButton);
			modeSelectionGroupBox.Controls.Add(this.importRequirementsRadioButton);
			modeSelectionGroupBox.Controls.Add(this.exportRequirementsRadioButton);
			modeSelectionGroupBox.Location = new System.Drawing.Point(12, 55);
			modeSelectionGroupBox.Name = "modeSelectionGroupBox";
			modeSelectionGroupBox.Size = new System.Drawing.Size(410, 145);
			modeSelectionGroupBox.TabIndex = 2;
			modeSelectionGroupBox.TabStop = false;
			modeSelectionGroupBox.Text = "What would you like to do?";
			// 
			// validateXmlCheckBox
			// 
			this.validateXmlCheckBox.Location = new System.Drawing.Point(31, 47);
			this.validateXmlCheckBox.Name = "validateXmlCheckBox";
			this.validateXmlCheckBox.Size = new System.Drawing.Size(375, 24);
			this.validateXmlCheckBox.TabIndex = 1;
			this.validateXmlCheckBox.Text = "Validate the file on conformity with the ReqIF 1.0 specification (XSD).";
			this.validateXmlCheckBox.UseVisualStyleBackColor = true;
			// 
			// mergeRequirementsRadioButton
			// 
			this.mergeRequirementsRadioButton.Location = new System.Drawing.Point(12, 73);
			this.mergeRequirementsRadioButton.Name = "mergeRequirementsRadioButton";
			this.mergeRequirementsRadioButton.Size = new System.Drawing.Size(394, 35);
			this.mergeRequirementsRadioButton.TabIndex = 2;
			this.mergeRequirementsRadioButton.Text = "Merge requirements from a ReqIF file and the current model (This mode provides fu" +
			"nctionalities to solve conflicts).";
			this.mergeRequirementsRadioButton.UseVisualStyleBackColor = true;
			this.mergeRequirementsRadioButton.CheckedChanged += new System.EventHandler(this.OnRadioButtonsSelectionChanged);
			// 
			// importRequirementsRadioButton
			// 
			this.importRequirementsRadioButton.Checked = true;
			this.importRequirementsRadioButton.Location = new System.Drawing.Point(12, 19);
			this.importRequirementsRadioButton.Name = "importRequirementsRadioButton";
			this.importRequirementsRadioButton.Size = new System.Drawing.Size(394, 26);
			this.importRequirementsRadioButton.TabIndex = 0;
			this.importRequirementsRadioButton.TabStop = true;
			this.importRequirementsRadioButton.Text = "Initial import of requirements from a ReqIF file.";
			this.importRequirementsRadioButton.UseVisualStyleBackColor = true;
			this.importRequirementsRadioButton.CheckedChanged += new System.EventHandler(this.OnRadioButtonsSelectionChanged);
			// 
			// exportRequirementsRadioButton
			// 
			this.exportRequirementsRadioButton.Location = new System.Drawing.Point(12, 110);
			this.exportRequirementsRadioButton.Name = "exportRequirementsRadioButton";
			this.exportRequirementsRadioButton.Size = new System.Drawing.Size(394, 24);
			this.exportRequirementsRadioButton.TabIndex = 3;
			this.exportRequirementsRadioButton.Text = "Export requirements from the model to a ReqIF file";
			this.exportRequirementsRadioButton.UseVisualStyleBackColor = true;
			this.exportRequirementsRadioButton.CheckedChanged += new System.EventHandler(this.OnRadioButtonsSelectionChanged);
			// 
			// pathFileTextBox
			// 
			this.pathFileTextBox.Location = new System.Drawing.Point(12, 233);
			this.pathFileTextBox.Name = "pathFileTextBox";
			this.pathFileTextBox.Size = new System.Drawing.Size(345, 20);
			this.pathFileTextBox.TabIndex = 4;
			this.pathFileTextBox.Validated += new System.EventHandler(this.OnValidatePathFileTextBox);
			// 
			// fileDialogButton
			// 
			this.fileDialogButton.Location = new System.Drawing.Point(378, 233);
			this.fileDialogButton.Name = "fileDialogButton";
			this.fileDialogButton.Size = new System.Drawing.Size(41, 21);
			this.fileDialogButton.TabIndex = 5;
			this.fileDialogButton.Text = "...";
			this.fileDialogButton.UseVisualStyleBackColor = true;
			this.fileDialogButton.Click += new System.EventHandler(this.OnFileDialogButtonClick);
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(347, 280);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 7;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.OnStartButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(266, 280);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
			// 
			// pathFileTextBoxErrorProvider
			// 
			this.pathFileTextBoxErrorProvider.ContainerControl = this;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(407, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current selected package in the model tree:";
			// 
			// selectedPackageTextBox
			// 
			this.selectedPackageTextBox.Location = new System.Drawing.Point(12, 29);
			this.selectedPackageTextBox.Name = "selectedPackageTextBox";
			this.selectedPackageTextBox.ReadOnly = true;
			this.selectedPackageTextBox.Size = new System.Drawing.Size(406, 20);
			this.selectedPackageTextBox.TabIndex = 1;
			// 
			// ImportExportForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(434, 315);
			this.Controls.Add(this.selectedPackageTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(modeSelectionGroupBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.fileDialogButton);
			this.Controls.Add(this.pathFileTextBox);
			this.Controls.Add(label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImportExportForm";
			this.ShowInTaskbar = false;
			this.Text = "ReqIF Import/Export Add-In";
			modeSelectionGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pathFileTextBoxErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox validateXmlCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox selectedPackageTextBox;
		private System.Windows.Forms.ErrorProvider pathFileTextBoxErrorProvider;
		private System.Windows.Forms.RadioButton mergeRequirementsRadioButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button fileDialogButton;
		private System.Windows.Forms.TextBox pathFileTextBox;
		private System.Windows.Forms.RadioButton exportRequirementsRadioButton;
		private System.Windows.Forms.RadioButton importRequirementsRadioButton;
	}
}
