using System;
using System.Text.RegularExpressions;

namespace iLyrics
{
	/// <summary>
	/// Summary description for LyricsFairySearcher.
	/// </summary>
	public class LyricsFairySearcher : ILyricSearcher
	{
		public LyricSearchResultCollection Search(string sText)
		{
			string lUrl = "http://www.lyricsfairy.com/search.php?q=" + sText;
			string lHtml = HttpHelper.MakeWebRequest(lUrl);
			
			// extract list of song matches
			Regex lRegex = new Regex(@"face=""Arial"">Song list</font>[\s\S]{1,100}<ul class=""text"">[\s\S]{1,100}(<li>[\s\S]*?</li>[\s\S]{1,100}?)+[\s\S]{1,100}</ul>");
			Match lMatch = lRegex.Match(lHtml);

			LyricSearchResultCollection lResults = new LyricSearchResultCollection();
			foreach (Capture lCapture in lMatch.Groups[1].Captures)
			{
				Regex lSongRegex = new Regex(@"<a href=""([\s\S]{1,200}?)""><b>([\s\S]{1,200}?)</b>[\s\S]{1,200}?"">([\s\S]{1,200}?)</a>");
				Match lSongMatch = lSongRegex.Match(lCapture.Value);

				// now extract individual song from html
				LyricSearchResult lResult = new LyricSearchResult();
				lResult.Artist = lSongMatch.Groups[3].Value;
				lResult.Album = string.Empty;
				lResult.Song = lSongMatch.Groups[2].Value;
				lResult.Url = lSongMatch.Groups[1].Value;

				lResults.Add(lResult);
			}

			return lResults;
		}

		public string GetLyrics(string sUrl)
		{
			string sHtml = HttpHelper.MakeWebRequest(sUrl);

			Regex lRegex = new Regex(@"</div>([\s\S]{1,2000}?)</td>");
			Match lMatch = lRegex.Match(sHtml);

			string lLyrics = lMatch.Groups[1].Value;
			lLyrics = lLyrics.Replace("<br />", string.Empty);
			lLyrics = lLyrics.Trim();

			return lLyrics;
		}
	}
}
