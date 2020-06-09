using System;

namespace BottleRocket
{
    class HexHelpers
    {
        internal static byte InterpretBoolsAsByte(bool[] input) //has to be eight of them or it won't work right
        {
            var values = new byte[8]
            {
                0b00000001,
                0b00000010,
                0b00000100,
                0b00001000,
                0b00010000,
                0b00100000,
                0b01000000,
                0b10000000
            };


            byte result = 0b00000000;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]) result += values[i]; //binary math time
            }
            return result;
        }

        internal static bool[] InterpretByteAsBools(byte num)
        {
            var result = new bool[8];
            var inputTemp = Convert.ToString(num, 2).PadLeft(8, '0').ToCharArray(); //yes I know this is janky
            Array.Reverse(inputTemp);

            for (int i = 0; i < inputTemp.Length; i++)
            {
                if (inputTemp[i] == '0')
                    result[i] = false;
                else
                    result[i] = true;
            }
            return result;
        }
    }
}
