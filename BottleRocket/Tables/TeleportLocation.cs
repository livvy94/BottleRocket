using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BottleRocket.Tables
{
    public class TeleportLocation
    {
        public const int START_OFFSET = 0x1C10;
        public const int END_OFFSET = 0x1C50;
        public const int TABLE_SIZE = END_OFFSET - START_OFFSET;
        public const int NUMBER_OF_ENTRIES = 8;

        public string NameTextOffset { get; set; } //Bytes 0 and 1
        public int X { get; set; } //Bytes 2 and 3
        public int Y { get; set; } //Bytes 4 and 5
        //Bytes 6 and 7 are unused

        public byte[] GenerateTableEntry()
        {
            byte[] result = new byte[8];

            int textOffsetTemp = HexHelpers.HexStringToInt(NameTextOffset) + 0x7FF0;
            string namePointerBytes = HexHelpers.Swap(textOffsetTemp.ToString("X4"));

            string xString = HexHelpers.IntToHexString(X, false);
            string yString = HexHelpers.IntToHexString(Y, false);

            xString = HexHelpers.Pad(xString, 4); //Force it to be two bytes
            xString = HexHelpers.Swap(xString); //Swap them
            yString = HexHelpers.Pad(yString, 4);
            yString = HexHelpers.Swap(yString);
            

            result[0] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(0, 2));
            result[1] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(2, 2));
            result[2] = (byte)HexHelpers.HexStringToInt(xString.Substring(0, 2));
            result[3] = (byte)HexHelpers.HexStringToInt(xString.Substring(2, 2));
            result[4] = (byte)HexHelpers.HexStringToInt(yString.Substring(0, 2));
            result[5] = (byte)HexHelpers.HexStringToInt(yString.Substring(2, 2));
            result[6] = 0x00; //Unused byte
            result[7] = 0x00; //Unused byte
            return result;
        }

        public static TeleportLocation ParseHex(byte[] input)
        {
            if (input.Length != 8)
                throw new ArgumentException("This pointer table entry isn't eight hex codes long...");

            var namePointerTemp = HexHelpers.HexStringToInt(input[1].ToString("X2") + input[0].ToString("X2"));
            
            var result = new TeleportLocation
            {
                NameTextOffset = (namePointerTemp - 0x7FF0).ToString("X4"),
                X = HexHelpers.ByteArrayToInt(new[] {input[3], input[2]}),
                Y = HexHelpers.ByteArrayToInt(new[] {input[5], input[4]})
            };

            return result;
        }

        public static void ExportJSON(TeleportLocation[] locations)
        {
            var json = JsonConvert.SerializeObject(locations, Formatting.Indented);
            FileStuff.ExportItemJSON(json);
        }

        public static TeleportLocation[] ImportJSON(string json)
        {
            var results = JsonConvert.DeserializeObject<List<TeleportLocation>>(json);
            return results.ToArray();
        }
    }
}
