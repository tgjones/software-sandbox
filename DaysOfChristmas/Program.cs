using System;
using System.Collections.Generic;
using System.Text;

namespace DaysOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
List<string> pGiftsReceived = new List<string>();
for (int nDay = 1; nDay <= 12; nDay++)
{
    Console.WriteLine("On the " + nDay + " day of Christmas,");
    Console.WriteLine("my true love sent to me");

    switch (nDay)
    {
        case 1 : pGiftsReceived.Add("And a partridge in a pair tree."); break;
        case 2 : pGiftsReceived.Add("Two turtle doves,"); break;
        case 3 : pGiftsReceived.Add("Three French hens,"); break;
        case 4 : pGiftsReceived.Add("Four calling birds,"); break;
        case 5 : pGiftsReceived.Add("Five golden rings,"); break;
        case 6 : pGiftsReceived.Add("Six geese a-laying,"); break;
        case 7 : pGiftsReceived.Add("Seven swans a-swimming,"); break;
        case 8 : pGiftsReceived.Add("Eight maids a-milking,"); break;
        case 9 : pGiftsReceived.Add("Nine ladies dancing,"); break;
        case 10 : pGiftsReceived.Add("Ten lords a-leaping,"); break;
        case 11 : pGiftsReceived.Add("Eleven pipers piping,"); break;
        case 12 : pGiftsReceived.Add("Twelve drummers drumming,"); break;
    }

    for (int j = pGiftsReceived.Count - 1; j >= 0; j--)
    {
        string sGift = pGiftsReceived[j];
        if (nDay == 1 && j == 0) sGift = sGift.Substring(4);
        Console.WriteLine(sGift);
    }

    Console.WriteLine();
}
        }
    }
}
