using System;

namespace iLyrics
{
	/// <summary>
	/// Summary description for ILyricSearchEngine.
	/// </summary>
	public interface ILyricSearcher
	{
		LyricSearchResultCollection Search(string sText);
		string GetLyrics(string sUrl);
	}
}
