namespace bmp_creation
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.imageDisplay = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imageDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// imageDisplay
			// 
			this.imageDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imageDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.imageDisplay.Location = new System.Drawing.Point(12, 89);
			this.imageDisplay.Name = "imageDisplay";
			this.imageDisplay.Size = new System.Drawing.Size(260, 260);
			this.imageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imageDisplay.TabIndex = 0;
			this.imageDisplay.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 361);
			this.Controls.Add(this.imageDisplay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Nothing more than a test";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.imageDisplay)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imageDisplay;
	}
}

