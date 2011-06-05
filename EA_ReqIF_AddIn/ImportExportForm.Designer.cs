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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			this.importRequirementsRadioButton = new System.Windows.Forms.RadioButton();
			this.exportRequirementsRadioButton = new System.Windows.Forms.RadioButton();
			this.pathFileTextBox = new System.Windows.Forms.TextBox();
			this.fileDialogButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(407, 17);
			label1.TabIndex = 0;
			label1.Text = "Specify whether you would like to import or export requirements.";
			// 
			// label2
			// 
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.Location = new System.Drawing.Point(12, 62);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(407, 16);
			label2.TabIndex = 3;
			label2.Text = "Specify the path and the name of the ReqIF file for im- resp. export.";
			// 
			// importRequirementsRadioButton
			// 
			this.importRequirementsRadioButton.Location = new System.Drawing.Point(12, 29);
			this.importRequirementsRadioButton.Name = "importRequirementsRadioButton";
			this.importRequirementsRadioButton.Size = new System.Drawing.Size(132, 24);
			this.importRequirementsRadioButton.TabIndex = 1;
			this.importRequirementsRadioButton.TabStop = true;
			this.importRequirementsRadioButton.Text = "Import requirements.";
			this.importRequirementsRadioButton.UseVisualStyleBackColor = true;
			// 
			// exportRequirementsRadioButton
			// 
			this.exportRequirementsRadioButton.Location = new System.Drawing.Point(150, 29);
			this.exportRequirementsRadioButton.Name = "exportRequirementsRadioButton";
			this.exportRequirementsRadioButton.Size = new System.Drawing.Size(134, 24);
			this.exportRequirementsRadioButton.TabIndex = 2;
			this.exportRequirementsRadioButton.TabStop = true;
			this.exportRequirementsRadioButton.Text = "Export requirements.";
			this.exportRequirementsRadioButton.UseVisualStyleBackColor = true;
			// 
			// pathFileTextBox
			// 
			this.pathFileTextBox.Location = new System.Drawing.Point(12, 83);
			this.pathFileTextBox.Name = "pathFileTextBox";
			this.pathFileTextBox.Size = new System.Drawing.Size(360, 20);
			this.pathFileTextBox.TabIndex = 4;
			// 
			// fileDialogButton
			// 
			this.fileDialogButton.Location = new System.Drawing.Point(378, 81);
			this.fileDialogButton.Name = "fileDialogButton";
			this.fileDialogButton.Size = new System.Drawing.Size(41, 21);
			this.fileDialogButton.TabIndex = 5;
			this.fileDialogButton.Text = "...";
			this.fileDialogButton.UseVisualStyleBackColor = true;
			this.fileDialogButton.Click += new System.EventHandler(this.OnFileDialogButtonClick);
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(344, 121);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 6;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.OnStartButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(263, 121);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(434, 157);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.fileDialogButton);
			this.Controls.Add(this.pathFileTextBox);
			this.Controls.Add(label2);
			this.Controls.Add(this.exportRequirementsRadioButton);
			this.Controls.Add(this.importRequirementsRadioButton);
			this.Controls.Add(label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.Text = "ReqIF Import/Export Add-In";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button fileDialogButton;
		private System.Windows.Forms.TextBox pathFileTextBox;
		private System.Windows.Forms.RadioButton exportRequirementsRadioButton;
		private System.Windows.Forms.RadioButton importRequirementsRadioButton;
	}
}
