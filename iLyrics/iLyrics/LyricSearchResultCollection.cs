using System;

namespace iLyrics
{
	/// <summary>
	/// Summary description for LyricSearchResultCollection.
	/// </summary>
	public class LyricSearchResultCollection : System.Collections.CollectionBase
	{
		public LyricSearchResult this[int index]
		{
			get { return ((LyricSearchResult)(List[index])); }
			set { List[index] = value; }
		}

		public int Add(LyricSearchResult lResult)
		{
			return List.Add(lResult);
		}

		public void Insert(int index, LyricSearchResult lResult)
		{
			List.Insert(index, lResult);
		}

		public void Remove(LyricSearchResult lResult)
		{
			List.Remove(lResult);
		}

		public bool Contains(LyricSearchResult lResult)
		{
			return List.Contains(lResult);
		}
	}
}
