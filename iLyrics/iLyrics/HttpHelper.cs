using System;
using System.IO;
using System.Net;

namespace iLyrics
{
	/// <summary>
	/// Summary description for HttpHelper.
	/// </summary>
	public class HttpHelper
	{
		public static string MakeWebRequest(string sUrl)
		{
			HttpWebRequest lRequest = (HttpWebRequest) HttpWebRequest.Create(sUrl);
			lRequest.Method = "GET";

			HttpWebResponse lResponse = (HttpWebResponse) lRequest.GetResponse();
			StreamReader lStreamReader = new StreamReader(lResponse.GetResponseStream());

			string sHtml = lStreamReader.ReadToEnd();

			lResponse.Close();

			return sHtml;
		}
	}
}
