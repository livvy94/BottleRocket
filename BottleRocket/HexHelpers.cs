using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BottleRocket
{
    class HexHelpers
    {
        public static string IntToBinaryString(int input)
        {
            var result = Convert.ToString(input, 2);
            return Pad(result);
        }

        public static int BinaryStringToInt(string input)
        {
            input = HexClean(input);
            return Convert.ToInt32(input, 2);
        }

        public static int HexStringToInt(string input)
        {
            input = HexClean(input);
            return Convert.ToInt32(input, 16);
        }
        
        public static string IntToHexString(int input, bool brackets)
        {
            var result = Convert.ToString(input, 16);
            result = Pad(result);
            if (brackets) result = $"[{result}]";
            
            return result;
        }

        public static int ByteArrayToInt(byte[] input)
        {
            var result = ByteArrayToHexString(input, false);
            return HexStringToInt(result);
        }

        public static byte[] HexStringToByteArray(string input)
        {
            var result = new List<byte>();
            
            for (var i = 0; i < input.Length; i += 2)
            {
                result.Add(byte.Parse(input.Substring(i, 2), NumberStyles.HexNumber));
            }

            return result.ToArray();
        }

        public static string ByteArrayToHexString(byte[] input, bool brackets)
        {
            var result = new StringBuilder();
            foreach (byte b in input)
            {
                result.Append(b.ToString("X2"));
            }

            if (brackets)
                return $"[{result}]";
            
            return result.ToString();
        }

        public static string Swap(string input)
        {
            input = Pad(input);

            switch (input.Length)
            {
                case 4: //AABB
                    return input.Substring(2, 2) + input.Substring(0, 2);
                case 6: //AABBCC
                    return input.Substring(0, 2) + input.Substring(4, 2) + input.Substring(2, 2);
                default:
                    throw new System.ArgumentException("Not sure how to swap that number of bytes...");
            }
        }

        public static byte[] Swap(byte[] input)
        {
            switch (input.Length)
            {
                case 2:
                    Array.Reverse(input);
                    return input;
                case 3:
                    return new byte[]
                    {
                        input[0],
                        input[2],
                        input[1]
                    };
                default:
                    throw new ArgumentException($"Not sure how to swap that many bytes... ({input.Length.ToString()} of them)");
            }
        }

        //public static byte[] Swap(int input)
        //{
        //    byte[] array = BitConverter.GetBytes(input);
        //    if (array.Length < 2) array.Append(Convert.ToByte(0x00)); //so if the person tried to convert [05], then [05 00] would be returned.
        //    return Swap(array);
        //}

        public static string Pad(string input)
        {
            //pad a hex string with zeroes if it's not an even number of chars
            if (input.Length % 2 != 0)
                return "0" + input;
            else return input;
        }

        public static string Pad(string input, int desiredLength)
        {
            while (input.Length < desiredLength)
            {
                input = "0" + input;
            }

            return input;
        }

        public static string HexClean(string input)
        {
            return input.Replace(" ", string.Empty)
                        .Replace("[", string.Empty)
                        .Replace("]", string.Empty);
        }

        public static int InterpretBoolsAsBinary(bool[] input)
        {
            var result = new StringBuilder();
            foreach (var bit in input)
            {
                result.Append(bit ? '1' : '0');
            }

            return BinaryStringToInt(result.ToString());
        }

        public static string ReaderToASCII(BinaryReader reader, int numberOfChars)
        {
            return Encoding.ASCII.GetString(reader.ReadBytes(numberOfChars));
        }
    }
}
