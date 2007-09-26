namespace MediaPlayer
{
	partial class MainForm
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
			this.lsbAlbums = new System.Windows.Forms.ListBox();
			this.lsbTracks = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lsbAlbums
			// 
			this.lsbAlbums.FormattingEnabled = true;
			this.lsbAlbums.Location = new System.Drawing.Point(12, 12);
			this.lsbAlbums.Name = "lsbAlbums";
			this.lsbAlbums.ScrollAlwaysVisible = true;
			this.lsbAlbums.Size = new System.Drawing.Size(345, 238);
			this.lsbAlbums.TabIndex = 0;
			this.lsbAlbums.SelectedIndexChanged += new System.EventHandler(this.lsbAlbums_SelectedIndexChanged);
			// 
			// lsbTracks
			// 
			this.lsbTracks.FormattingEnabled = true;
			this.lsbTracks.Location = new System.Drawing.Point(12, 270);
			this.lsbTracks.Name = "lsbTracks";
			this.lsbTracks.ScrollAlwaysVisible = true;
			this.lsbTracks.Size = new System.Drawing.Size(345, 173);
			this.lsbTracks.TabIndex = 1;
			this.lsbTracks.SelectedIndexChanged += new System.EventHandler(this.lsbTracks_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 455);
			this.Controls.Add(this.lsbTracks);
			this.Controls.Add(this.lsbAlbums);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lsbAlbums;
		private System.Windows.Forms.ListBox lsbTracks;

	}
}

