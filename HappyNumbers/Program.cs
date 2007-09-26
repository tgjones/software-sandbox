using System;
using System.Collections;
using System.IO;

namespace HappyNumbers
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Program
	{
		private static ArrayList m_pKnownUnhappyNumbers;
		private static ArrayList m_pCheckedNumbers;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			m_pKnownUnhappyNumbers = new ArrayList();

			int nCounter = 0;
			int nTimeStart = Environment.TickCount;

			StreamWriter pWriter = new StreamWriter("output.txt");

			const int LENGTH = 100000;
			for (int i = 1; i < LENGTH; i++)
			{
				m_pCheckedNumbers = new ArrayList();
				if (IsHappyNumber(i))
				{
					++nCounter;
					pWriter.WriteLine(i.ToString());
					Console.WriteLine(i.ToString());
				}
			}

			pWriter.Close();

			int nTimeEnd = Environment.TickCount;
			int nTime = nTimeEnd - nTimeStart;

			double dRatio = (double) nCounter / (double) LENGTH;
			Console.WriteLine("Found {0} happy numbers, which is a ratio of {1}", nCounter, dRatio);
			Console.WriteLine("Time taken: {0}ms", nTime);
		}

		private static bool IsHappyNumber(int nNumber)
		{
			// check if this number is 1 - if so, it's happy, by definition
			if (nNumber == 1)
			{
				return true;
			}

			// check if we've already had this number, in which case we're into
			// infinite recursion and this number is unhappy
			if (m_pCheckedNumbers.Contains(nNumber))
			{
				m_pKnownUnhappyNumbers.Add(nNumber);
				return false;
			}

			m_pCheckedNumbers.Add(nNumber);

			// calculate sum of squares of digits and recursively check if happy number
			int nSumOfSquaresOfDigits = CalculateSumOfSquaresOfDigits(nNumber);
			return IsHappyNumber(nSumOfSquaresOfDigits);
		}

		private static int CalculateSumOfSquaresOfDigits(int nNumber)
		{
			int nTotal = 0;

			// recursively check digits
			string sNumber = nNumber.ToString();
			for (int i = 0, length = sNumber.Length; i < length; i++)
			{
				int nDigit = int.Parse(sNumber[i].ToString());
				int nDigitSquared = nDigit * nDigit;
				nTotal += nDigitSquared;
			}

			return nTotal;
		}
	}
}