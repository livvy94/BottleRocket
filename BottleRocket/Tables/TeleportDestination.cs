using System;

namespace BottleRocket.Tables
{
    public class TeleportDestination
    {
        public const int START_OFFSET = 0x1C10;
        public const int END_OFFSET = 0x1C50;
        public const int NUMBER_OF_ENTRIES = 8;
        public const string FILENAME = "teleport_location_table";

        public string NameTextOffset; //Bytes 0 and 1       0xD383 "MyHome"
        public byte Song; //Byte 2                          0x86
        public byte X; //Byte 3                             0x33
        public byte MinitileCode; //Byte 4, first half      0x4
        public string Direction; //byte 4, 2nd half          0x6
        public byte Y; //Byte 5                             0x51
        //Bytes 6 and 7 are unused

        public byte[] TableEntry
        {
            get
            {
                var result = new byte[8];
                var textOffsetTemp = 0x7FF0 + int.Parse(NameTextOffset, System.Globalization.NumberStyles.HexNumber);
                var textOffsetArray = BitConverter.GetBytes(textOffsetTemp);

                var minitileCodeBits = CalculateMinitileCode();
                var directionBits = CalculateDirection();
                var minitileDirectionCombo = Convert.ToByte(minitileCodeBits + directionBits, 2); //both values are stored in one byte, split down the middle!

                result[0] = textOffsetArray[0];
                result[1] = textOffsetArray[1];
                result[2] = Song;
                result[3] = X;
                result[4] = minitileDirectionCombo;
                result[5] = Y;
                result[6] = 0x00; //unused
                result[7] = 0x00; //unused
                return result;
            }
        }

        public static TeleportDestination ParseHex(byte[] input)
        {
            int offsetTemp = BitConverter.ToUInt16(new byte[] { input[0], input[1] }, 0);
            offsetTemp -= 0x7FF0;

            return new TeleportDestination()
            {
                NameTextOffset = offsetTemp.ToString("X4"),
                Song = input[2],
                X = input[3],
                MinitileCode = CalculateMinitileCode(input[4]),
                Direction = CalculateDirection(input[4]),
                Y = input[5],
            };
        }

        ////////////////////////////////////
        //Helper Methods
        private string CalculateMinitileCode()
        {
            if (MinitileCode > 0x0F)
                throw new Exception($"Invalid Minitile Code: {MinitileCode}\r\n"
                                   + "This field can only go up to 15.");

            return Convert.ToString(MinitileCode, 2).PadLeft(4, '0');
        }

        private static byte CalculateMinitileCode(byte input)
        {
            var inputBits = Convert.ToString(input, 2).PadLeft(8, '0'); //convert to binary string
            var minitileCode = Convert.ToByte(inputBits.Substring(0, 4), 2); //grab that side of the byte -> 11110000
            return minitileCode;
        }

        private string CalculateDirection()
        {
            var input = Direction.ToLower().Trim();
            string result;

            if (input == "north" || Direction == "up")
                result = "0000";
            else if (input == "northeast")
                result = "0001";
            else if (input == "east" || Direction == "right")
                result = "0010";
            else if (input == "southeast")
                result = "0011";
            else if (input == "south" || Direction == "down")
                result = "0100";
            else if (input == "southwest")
                result = "0101";
            else if (input == "west" || Direction == "left")
                result = "0110";
            else if (input == "northwest")
                result = "0111";
            else throw new ArgumentException(
                $"Invalid compass direction: {Direction}\r\n" +
                 "Please use north, northeast, east, southeast, etc.");

            return result;
        }

        private static string CalculateDirection(byte input)
        {
            var inputBits = Convert.ToString(input, 2).PadLeft(8, '0'); //convert to binary string
            var direction = Convert.ToByte(inputBits.Substring(4, 4), 2); //00001111 <- grab that side of the byte

            return direction switch
            {
                0 => "north",
                1 => "northeast",
                2 => "east",
                3 => "southeast",
                4 => "south",
                5 => "southwest",
                6 => "west",
                7 => "northwest",
                _ => $"Invalid direction byte: {input:X2} (this should never happen!)",
            };
        }

    }
}
