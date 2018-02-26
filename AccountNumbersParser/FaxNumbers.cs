using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNumbersParser
{
    public class FaxNumbers
    {
        public const string Zero = " _ | ||_|"; 
        public const string One = "     |  |";
        public const string Two = " _  _||_ ";
        public const string Three = " _  _| _|";
        public const string Four = "   |_|  |";
        public const string Five = " _ |_  _|";
        public const string Six = " _ |_ |_|";
        public const string Seven = " _   |  |";
        public const string Eight = " _ |_||_|";
        public const string Nine = " _ |_| _|";

        public static string GetNumber(string faxNumber)
        {
            switch (faxNumber) 
            {
                case Zero:
                    return "0";
                case One:
                    return "1";
                case Two:
                    return "2";
                case Three:
                    return "3";
                case Four:
                    return "4";
                case Five:
                    return "5";
                case Six:
                    return "6";
                case Seven:
                    return "7";
                case Eight:
                    return "8";
                case Nine:
                    return "9";
                default:
                    return "";
            }
        }
    }
}
