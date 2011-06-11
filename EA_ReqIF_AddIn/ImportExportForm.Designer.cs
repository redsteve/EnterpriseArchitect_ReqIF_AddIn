/*
 * Created by SharpDevelop.
 * User: Stephan Roth
 * Date: 29.05.2011
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
			System.Windows.Forms.GroupBox groupBox1;
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
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pathFileTextBoxErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.Location = new System.Drawing.Point(12, 181);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(407, 16);
			label2.TabIndex = 4;
			label2.Text = "Specify the path and the name of the ReqIF file:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(this.mergeRequirementsRadioButton);
			groupBox1.Controls.Add(this.importRequirementsRadioButton);
			groupBox1.Controls.Add(this.exportRequirementsRadioButton);
			groupBox1.Location = new System.Drawing.Point(12, 55);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(410, 123);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "What would you like to do?";
			// 
			// mergeRequirementsRadioButton
			// 
			this.mergeRequirementsRadioButton.Location = new System.Drawing.Point(12, 51);
			this.mergeRequirementsRadioButton.Name = "mergeRequirementsRadioButton";
			this.mergeRequirementsRadioButton.Size = new System.Drawing.Size(394, 35);
			this.mergeRequirementsRadioButton.TabIndex = 2;
			this.mergeRequirementsRadioButton.Text = "Merge requirements from a ReqIF file and the current model (This mode provides fu" +
			"nctionalities to solve conflicts).";
			this.mergeRequirementsRadioButton.UseVisualStyleBackColor = true;
			// 
			// importRequirementsRadioButton
			// 
			this.importRequirementsRadioButton.Checked = true;
			this.importRequirementsRadioButton.Location = new System.Drawing.Point(12, 19);
			this.importRequirementsRadioButton.Name = "importRequirementsRadioButton";
			this.importRequirementsRadioButton.Size = new System.Drawing.Size(394, 26);
			this.importRequirementsRadioButton.TabIndex = 1;
			this.importRequirementsRadioButton.TabStop = true;
			this.importRequirementsRadioButton.Text = "Initial import of requirements from a ReqIF file.";
			this.importRequirementsRadioButton.UseVisualStyleBackColor = true;
			// 
			// exportRequirementsRadioButton
			// 
			this.exportRequirementsRadioButton.Location = new System.Drawing.Point(12, 92);
			this.exportRequirementsRadioButton.Name = "exportRequirementsRadioButton";
			this.exportRequirementsRadioButton.Size = new System.Drawing.Size(394, 24);
			this.exportRequirementsRadioButton.TabIndex = 3;
			this.exportRequirementsRadioButton.Text = "Export requirements from the model to a ReqIF file";
			this.exportRequirementsRadioButton.UseVisualStyleBackColor = true;
			// 
			// pathFileTextBox
			// 
			this.pathFileTextBox.Location = new System.Drawing.Point(12, 200);
			this.pathFileTextBox.Name = "pathFileTextBox";
			this.pathFileTextBox.Size = new System.Drawing.Size(345, 20);
			this.pathFileTextBox.TabIndex = 5;
			this.pathFileTextBox.Validated += new System.EventHandler(this.OnValidatePathFileTextBox);
			// 
			// fileDialogButton
			// 
			this.fileDialogButton.Location = new System.Drawing.Point(378, 200);
			this.fileDialogButton.Name = "fileDialogButton";
			this.fileDialogButton.Size = new System.Drawing.Size(41, 21);
			this.fileDialogButton.TabIndex = 6;
			this.fileDialogButton.Text = "...";
			this.fileDialogButton.UseVisualStyleBackColor = true;
			this.fileDialogButton.Click += new System.EventHandler(this.OnFileDialogButtonClick);
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(347, 237);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 8;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.OnStartButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(266, 237);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
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
			this.label1.Size = new System.Drawing.Size(226, 17);
			this.label1.TabIndex = 9;
			this.label1.Text = "Current selected package in the model tree:";
			// 
			// selectedPackageTextBox
			// 
			this.selectedPackageTextBox.Location = new System.Drawing.Point(12, 29);
			this.selectedPackageTextBox.Name = "selectedPackageTextBox";
			this.selectedPackageTextBox.ReadOnly = true;
			this.selectedPackageTextBox.Size = new System.Drawing.Size(406, 20);
			this.selectedPackageTextBox.TabIndex = 10;
			// 
			// ImportExportForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(434, 272);
			this.Controls.Add(this.selectedPackageTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(groupBox1);
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
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pathFileTextBoxErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
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
