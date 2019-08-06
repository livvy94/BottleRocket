using System;
using System.Collections.Generic;
using Nett;

namespace BottleRocket.Tables
{
    public class TeleportLocation
    {
        public const int START_OFFSET = 0x1C10;
        public const int END_OFFSET = 0x1C50;
        public const int NUMBER_OF_ENTRIES = 8;
        public const string TOML_PATH = @"teleport_location_table.toml";

        public string NameTextOffset; //Bytes 0 and 1       0xD383 "MyHome"
        public byte Song; //Byte 2                          0x86
        public byte X; //Byte 3                             0x33
        public byte MinitileCode; //Byte 4, first half      0x4
        public string Direction; //byte 4, 2nd half          0x6
        public byte Y; //Byte 5                             0x51
        //Bytes 6 and 7 are unused

        public byte[] GenerateTableEntry()
        {
            byte[] result = new byte[8];

            int textOffsetTemp = HexHelpers.HexStringToInt(NameTextOffset) + 0x7FF0;
            string namePointerBytes = HexHelpers.Swap(textOffsetTemp.ToString("X4"));

            byte direction;
            Direction = Direction.ToLower().Trim();

            if (Direction == "north" || Direction == "up")
                direction = 0;
            else if (Direction == "northeast")
                direction = 1;
            else if (Direction == "east" || Direction == "right")
                direction = 2;
            else if (Direction == "southeast")
                direction = 3;
            else if (Direction == "south" || Direction == "down")
                direction = 4;
            else if (Direction == "southwest")
                direction = 5;
            else if (Direction == "west" || Direction == "left")
                direction = 6;
            else if (Direction == "northwest")
                direction = 7;
            else throw new ArgumentException(
                $"Invalid compass direction: {Direction}\r\n" +
                 "Please use north, northeast, east, southeast, etc.");

            result[0] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(0, 2));
            result[1] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(2, 2));
            result[2] = Song;
            result[3] = X;
            result[4] = (byte)HexHelpers.HexStringToInt(MinitileCode.ToString("X1") + direction);
            result[5] = Y;
            result[6] = 0x00; //Unused byte
            result[7] = 0x00; //Unused byte
            return result;
        }

        public static TeleportLocation ParseHex(byte[] input)
        {
            if (input.Length != 8)
                throw new ArgumentException("This pointer table entry isn't eight hex codes long...");

            var namePointerTemp = HexHelpers.HexStringToInt(input[1].ToString("X2") + input[0].ToString("X2"));

            var minitileTemp = input[4].ToString("X2").Substring(0, 1);
            var directionTemp = byte.Parse(input[4].ToString("X2").Substring(1, 1));
            var directionStringTemp = string.Empty;

            if (directionTemp == 0)
                directionStringTemp = "north";
            else if (directionTemp == 1)
                directionStringTemp = "northeast";
            else if (directionTemp == 2)
                directionStringTemp = "east";
            else if (directionTemp == 3)
                directionStringTemp = "southeast";
            else if (directionTemp == 4)
                directionStringTemp = "south";
            else if (directionTemp == 5)
                directionStringTemp = "southwest";
            else if (directionTemp == 6)
                directionStringTemp = "west";
            else if (directionTemp == 7)
                directionStringTemp = "northwest";

            var result = new TeleportLocation
            {
                NameTextOffset = (namePointerTemp - 0x7FF0).ToString("X4"),
                Song = input[2],
                X = input[3],
                MinitileCode = (byte)HexHelpers.HexStringToInt(minitileTemp),
                Direction = directionStringTemp,
                Y = input[5]
            };

            return result;
        }

        public static void ExportData(TeleportLocation[] locations)
        {
            Toml.WriteFile(locations, TOML_PATH);
        }

        public static TeleportLocation[] ImportTOML(string toml)
        {
            var results = Toml.ReadFile<List<TeleportLocation>>(toml);
            return results.ToArray();
        }
    }
}
