using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using iTunesLib;

namespace iLyrics
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnAddLyrics;
		private System.Windows.Forms.ListView lsvSearchResults;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnAddLyrics = new System.Windows.Forms.Button();
			this.lsvSearchResults = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(312, 8);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnAddLyrics
			// 
			this.btnAddLyrics.Location = new System.Drawing.Point(312, 40);
			this.btnAddLyrics.Name = "btnAddLyrics";
			this.btnAddLyrics.TabIndex = 1;
			this.btnAddLyrics.Text = "Add Lyrics";
			this.btnAddLyrics.Click += new System.EventHandler(this.btnAddLyrics_Click);
			// 
			// lsvSearchResults
			// 
			this.lsvSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																											 this.columnHeader1,
																																											 this.columnHeader3,
																																											 this.columnHeader2});
			this.lsvSearchResults.FullRowSelect = true;
			this.lsvSearchResults.Location = new System.Drawing.Point(8, 8);
			this.lsvSearchResults.Name = "lsvSearchResults";
			this.lsvSearchResults.Size = new System.Drawing.Size(296, 240);
			this.lsvSearchResults.TabIndex = 2;
			this.lsvSearchResults.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Artist";
			this.columnHeader1.Width = 143;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Song";
			this.columnHeader2.Width = 142;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Album";
			this.columnHeader3.Width = 7;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(394, 256);
			this.Controls.Add(this.lsvSearchResults);
			this.Controls.Add(this.btnAddLyrics);
			this.Controls.Add(this.btnSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "iLyrics";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			IiTunes piTunesApp = new iTunesAppClass();
			string sTrackName = piTunesApp.SelectedTracks[1].Name;

			LyricsFairySearcher pSearcher = new LyricsFairySearcher();
			LyricSearchResultCollection pResults = pSearcher.Search(sTrackName);

			lsvSearchResults.BeginUpdate();
			lsvSearchResults.Items.Clear();
			foreach (LyricSearchResult pResult in pResults)
			{
				string[] lItems = new string[] {pResult.Artist, pResult.Album, pResult.Song};
				ListViewItem lListViewItem = new ListViewItem(lItems);
				lListViewItem.Tag = pResult.Url;
				lsvSearchResults.Items.Add(lListViewItem);
			}
			lsvSearchResults.EndUpdate();
		}

		private void btnAddLyrics_Click(object sender, System.EventArgs e)
		{
			string sUrl = (string) lsvSearchResults.SelectedItems[0].Tag;

			LyricsFairySearcher pSearcher = new LyricsFairySearcher();
			string sLyrics = pSearcher.GetLyrics(sUrl);

			IiTunes piTunesApp = new iTunesAppClass();
			IITFileOrCDTrack pTrack = (IITFileOrCDTrack) piTunesApp.SelectedTracks[1];
			pTrack.Lyrics = sLyrics;
		}
	}
}
