﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BottleRocket.Tables

{
    public class TrainDestination
    {
        public const int START_OFFSET = 0x1C90;
        public const int END_OFFSET = 0x1CF0;
        public const int NUMBER_OF_ENTRIES = 12;
        public const string JSON_PATH = @"train_destination_table.json";

        public string NameTextOffset { get; set; }
        public int MusicToPlay { get; set; }
        public int TrainStartLocationX { get; set; }
        public string StartDirection { get; set; }
        public int TrainStartLocationY { get; set; }
        public int Price { get; set; }

        public object GenerateTableEntry()
        {
            byte[] result = new byte[8];

            int textOffsetTemp = HexHelpers.HexStringToInt(NameTextOffset) + 0x7FF0;
            string namePointerBytes = HexHelpers.Swap(textOffsetTemp.ToString("X4"));

            //37 (decimal)
            //79 (decimal)
            //to
            //100101
            //0001001111
            //to
            //1001010001001111
            //to
            //94 4F

            //TODO: OVERHAUL THESE LINES AAUGH
            //string musicBytes = HexHelpers.Reverse(HexHelpers.Pad(HexHelpers.IntToBinaryString(MusicToPlay), 5));
            //string trainStartLocationXBytes = HexHelpers.Pad(HexHelpers.Reverse(HexHelpers.IntToBinaryString(TrainStartLocationX, 11)));
            //string bytesTwoAndThree = HexHelpers.IntToHexString(HexHelpers.BinaryStringToInt(musicBytes + trainStartLocationXBytes), false);

            byte direction; //TODO: Make sure these values are correct. If so, make into a class?
            if (StartDirection == "north" || StartDirection == "up")
                direction = 0;
            else if (StartDirection == "northeast")
                direction = 1;
            else if (StartDirection == "east" || StartDirection == "right")
                direction = 2;
            else if (StartDirection == "southeast")
                direction = 3;
            else if (StartDirection == "south" || StartDirection == "down")
                direction = 4;
            else if (StartDirection == "southwest")
                direction = 5;
            else if (StartDirection == "west" || StartDirection == "left")
                direction = 6;
            else if (StartDirection == "northwest")
                direction = 7;
            else throw new ArgumentException(
                $"Invalid compass direction: {StartDirection}\r\n" +
                "Please use north, northeast, east, southeast, etc.");

            //[C5][53]
            //to
            //11000 10101010011
            //to
            //00011 11001010101
            //to
            //3 1621

            string directionBytes = HexHelpers.Reverse(HexHelpers.IntToBinaryString(direction, 5));
            string trainStartLocationYBytes = HexHelpers.Reverse(HexHelpers.IntToBinaryString(TrainStartLocationY, 11));
            string bytesFourAndFive = HexHelpers.IntToHexString(
                HexHelpers.BinaryStringToInt(directionBytes + trainStartLocationYBytes), false);

            byte[] priceBytes = HexHelpers.HexStringToByteArray(HexHelpers.Swap(Price.ToString("X4")));

            result[0] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(0, 2));
            result[1] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(2, 2));
            result[2] = (byte)HexHelpers.HexStringToInt(bytesTwoAndThree.Substring(0, 2));
            result[3] = (byte)HexHelpers.HexStringToInt(bytesTwoAndThree.Substring(2, 2));
            result[4] = (byte)HexHelpers.HexStringToInt(bytesFourAndFive.Substring(0, 2));
            result[5] = (byte)HexHelpers.HexStringToInt(bytesFourAndFive.Substring(2, 2));
            result[6] = priceBytes[0];
            result[7] = priceBytes[1];
            return result;
        }
    }
}