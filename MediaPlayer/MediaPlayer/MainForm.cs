using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{
	public partial class MainForm : Form
	{
		private WMPLib.WindowsMediaPlayer m_pMediaPlayer;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// create media player object
			m_pMediaPlayer = new WMPLib.WindowsMediaPlayerClass();

			// get list of albums
			WMPLib.IWMPStringCollection lAlbums = m_pMediaPlayer.mediaCollection.getAttributeStringCollection("WM/AlbumTitle", "audio");
			lsbAlbums.BeginUpdate();
			for (int i = 0, length = lAlbums.count; i < length; i++)
			{
				lsbAlbums.Items.Add(lAlbums.Item(i));
			}
			lsbAlbums.EndUpdate();
		}

		private void lsbAlbums_SelectedIndexChanged(object sender, EventArgs e)
		{
			lsbTracks.Items.Clear();

			string sAlbumName = (string) lsbAlbums.SelectedItem;
			WMPLib.IWMPPlaylist lTracks = m_pMediaPlayer.mediaCollection.getByAlbum(sAlbumName);
			lsbTracks.BeginUpdate();
			for (int i = 0, length = lTracks.count; i < length; i++)
			{
				Track pTrack = new Track();
				pTrack.TrackName = lTracks.get_Item(i).name;
				pTrack.Media = lTracks.get_Item(i);
				lsbTracks.Items.Add(pTrack);
			}
			lsbTracks.EndUpdate();
		}

		private void lsbTracks_SelectedIndexChanged(object sender, EventArgs e)
		{
			Track pTrack = (Track) lsbTracks.SelectedItem;
			m_pMediaPlayer.currentMedia = pTrack.Media;
		}

		private class Track
		{
			public string TrackName;
			public WMPLib.IWMPMedia Media;

			public override string ToString()
			{
				return TrackName; ;
			}
		}
	}
}