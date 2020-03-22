using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamentals
{
    public static class Number
    {

        private static int currentNumber;

        public static int CurrentNumber
        {
            get
            {
                if (currentNumber == 0)
                {
                    currentNumber = GenerateNumber(4);
                }
                return currentNumber;
            }

            set
            {
                if (value > 9)
                    value = 9;
                if (value < 1)
                    value = 1;
                currentNumber = GenerateNumber((byte)value);
            }
           
        }

        private static int GenerateNumber(byte baseNumber)
        {
            string number = "";
            byte basamak = 0;

            for (byte i = 0; i < baseNumber; i++)
            {
                if (i == 0)
                {
                    basamak = (byte)Random.Range(1, 10);
                }
                else
                {
                    basamak = (byte)Random.Range(0, 10);
                }
                number += basamak;
            }
            return int.Parse(number.Trim());
        }

    }
}