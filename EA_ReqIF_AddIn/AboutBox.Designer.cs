/*
 * $Id:$
 */
 
namespace EA_ReqIF_AddIn
{
	partial class AboutBox
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
			System.Windows.Forms.Label titleLabel;
			System.Windows.Forms.LinkLabel linkLabel1;
			this.OkButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			titleLabel = new System.Windows.Forms.Label();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			titleLabel.Location = new System.Drawing.Point(97, 9);
			titleLabel.Name = "titleLabel";
			titleLabel.Size = new System.Drawing.Size(246, 27);
			titleLabel.TabIndex = 1;
			titleLabel.Text = "Requirements Interchange Format (ReqIF) Import/Export Add-In";
			// 
			// linkLabel1
			// 
			linkLabel1.Location = new System.Drawing.Point(222, 47);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(121, 15);
			linkLabel1.TabIndex = 3;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "http://www.roth-soft.de";
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(268, 127);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 0;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OnOkButtonClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(97, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "Author: Stephan Roth";
			// 
			// versionLabel
			// 
			this.versionLabel.Location = new System.Drawing.Point(97, 62);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(244, 17);
			this.versionLabel.TabIndex = 4;
			this.versionLabel.Text = "Version: ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 9);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(79, 141);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// AboutBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 162);
			this.ControlBox = false;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(linkLabel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(titleLabel);
			this.Controls.Add(this.OkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AboutBox";
			this.Text = "About EA ReqIF Add-In...";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button OkButton;
	}
}
