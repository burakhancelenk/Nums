using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fundamentals
{
    public static class Comparer
    {

        private static byte onlyValue;
        private static byte placeAndValue;
        private static sbyte[] digit = new sbyte[9];
        private static sbyte[] nonDigit = new sbyte[9];

        public static sbyte[] Digit
        {
            get
            {
                return digit;
            }

        }
        public static sbyte[] NonDigit
        {
            get
            {
                return nonDigit;
            }
        }

        public static byte OnlyValue
        {
            get
            {
                return onlyValue;
            }
            
        }
        public static byte PlaceAndValue
        {
            get
            {
                return placeAndValue;
            }
        }
        


        public static void Compare(int pNumber,int gNumber)
        {
            onlyValue = 0;
            placeAndValue = 0;
            for(byte i = 0; i < digit.Length; i++)
            {
                digit[i] = -1;
                nonDigit[i] = -1;
            }
                string generatedNumber = gNumber.ToString();
                string playerNumber = pNumber.ToString();
                bool[] playerChecked = new bool[generatedNumber.Length];
                bool[] generatedChecked = new bool[generatedNumber.Length];

                for(byte i=0;i<generatedNumber.Length;i++)
                {
                    if (generatedNumber[i] == playerNumber[i])
                    {
                        playerChecked[i] = true;
                        generatedChecked[i] = true;
                        placeAndValue++;
                        digit[i] = sbyte.Parse(generatedNumber[i].ToString());
                    }
                    
                    

                }

                for(byte i=0;i<generatedNumber.Length;i++)
                {
                   for(byte x=0;x<generatedNumber.Length;x++)
                   {
                        if (i == x)
                        {
                            continue;
                        }
                        else if (playerNumber[i] == generatedNumber[x] && (playerChecked[i] == false && generatedChecked[x] == false))
                        {
                            onlyValue++;
                            playerChecked[i] = true;
                            generatedChecked[x] = true;
                            nonDigit[x] = sbyte.Parse(playerNumber[i].ToString());
                        }
                        
                   }
                }

        }

    }
}
