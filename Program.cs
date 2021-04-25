using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<int>() { 34323 };
            var list = new List<int>() { 1220, 1331, 34323, 90, 9, 999, 99 };
            var output = new List<int>();
            foreach (var item in list)
            {
                var x = NextHighestPalindromeNumber(item);
                Console.WriteLine(x);
                output.Add(item);
            }
            Console.ReadKey();
        }
        private static int NextHighestPalindromeNumber(int x)
        {
            if(x>=0 && x<=9)
            {
                return x;
            }
            var strNumber = x.ToString();
            var strLength = strNumber.Length;
            bool IsoddLength = (strLength % 2) == 1? true:false;
            var FirstHalf = strNumber.Substring(0, strNumber.Length / 2);
            var SecondHalf = GetSecondHalfString(strNumber, IsoddLength);
            var reversedHalf = reversed(FirstHalf);

            var output = CompareTwoHalvesAndGetPalindrome(FirstHalf, SecondHalf, reversedHalf, IsoddLength, strNumber);
            int PalindromicNumber = int.Parse(output);
            return PalindromicNumber;
        }
        private static string CompareTwoHalvesAndGetPalindrome(string FirstHalf, string SecondHalf, string ReversedFirstHalf, bool IsOddLength, string strNumber)
        {
            
            if (ReversedFirstHalf.CompareTo(SecondHalf) <= 0)
            {
                if (IsOddLength)
                {
                    var StringToIncrement = strNumber.Substring(0, FirstHalf.Length + 1);
                    var incrementedNumber = int.Parse(StringToIncrement);
                    incrementedNumber++;
                    var StringIncremented = incrementedNumber.ToString();
                    var modifiedFirstHalf = StringIncremented.Substring(0, (StringIncremented.Length - 1));
                    if (modifiedFirstHalf.ToString().Length > FirstHalf.Length)
                    {
                        ///Console.Write("hello");
                        //specialCase; passing reversed string after modification will take care of special case
                    }
                    string revTempString = reversed(modifiedFirstHalf.Substring(0, FirstHalf.Length));
                    return StringIncremented + revTempString;
                }
                else
                {
                    var FirstHalfNumber = int.Parse(FirstHalf);
                    FirstHalfNumber++;
                    if (FirstHalfNumber.ToString().Length > FirstHalf.Length)
                    {
                        //Console.Write("hello");
                        //specialCase; 
                    }
                    string revTempString = reversed(FirstHalfNumber.ToString().Substring(0, FirstHalf.Length));
                    return FirstHalfNumber.ToString() + revTempString;
                }
            }
            else
            {
                if (IsOddLength)
                {
                    var ModifiedHalf = strNumber.Substring(0, FirstHalf.Length + 1);
                    return ModifiedHalf + ReversedFirstHalf;
                }
                return FirstHalf + ReversedFirstHalf;
            }
        }

        private static string GetSecondHalfString(string strNumber, bool IsOddLength)
        {
            int size = strNumber.Length / 2;
            if (IsOddLength)
            {
                size++;
            }
            var SecondHalf = strNumber.Substring(size);
            return SecondHalf;
        }
        private static string reversed(string FirstHalf)
        {
            var ReversedFirstHalf = new string(FirstHalf.Reverse().ToArray());
            return ReversedFirstHalf;
        }

    }
}
