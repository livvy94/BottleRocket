using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BottleRocket
{
    public class Item
    {
        public const int START_OFFSET = 0x1810;
        public const int END_OFFSET = 0x1C10; //the last byte of the last entry is 1C0F
        public const int TABLE_SIZE = END_OFFSET - START_OFFSET; //Is this ever going to be used?
        public const int NUMBER_OF_ENTRIES = 128; //There are 128 items in the table, though quite a few of them are dummied out

        //In the future, something cool to do would be to make it not dependent on there being the same number of entries,
        //and make it so that you can change the order, and it affects references to item numbers throughout the map data/rest of the ROM
        //to let people "refactor" item usage and shuffle them around.
        //Though now that just sounds like a pipe dream that might not even be worth it lmao

        public string NameTextOffset { get; set; }

        public bool NintenUsable { get; set; } //Second half   000X
        public bool AnaUsable { get; set; }    //Second half   00X0
        public bool LloydUsable { get; set; }  //Second half   0X00
        public bool TeddyUsable { get; set; }  //Second half   X000

        public bool Unknown1 { get; set; }     //First half    000X
        public bool Unknown2 { get; set; }     //First half    00X0
        public bool Edible { get; set; }       //First half    0X00
        public bool Permanent { get; set; }    //First half    X000

        public byte WeaponStrength { get; set; }
        public byte EffectOutsideOfBattle { get; set; }
        public byte EffectInBattle { get; set; }
        public int Price { get; set; }

        public byte[] GenerateTableEntry()
        {
            byte[] result = new byte[8];

            int textOffsetTemp = HexHelpers.HexStringToInt(NameTextOffset) + 0x7FF0;
            string namePointerBytes = HexHelpers.Swap(textOffsetTemp.ToString("X4"));

            //5A

            byte digit2 = Convert.ToByte(
            HexHelpers.InterpretBoolsAsBinary(new bool[]
            {       //3
                    Permanent,     //0
                    Edible,        //0
                    Unknown2,      //1
                    Unknown1,      //1

                    //F
                    TeddyUsable,   //1
                    LloydUsable,   //1
                    AnaUsable,     //1
                    NintenUsable   //1

                //...results in 0x3F
            }));

            byte[] priceBytes = HexHelpers.HexStringToByteArray(HexHelpers.Swap(Price.ToString("X4")));

            result[0] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(0, 2));
            result[1] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(2, 2));

            result[2] = digit2;
            result[3] = WeaponStrength;
            result[4] = EffectOutsideOfBattle;
            result[5] = EffectInBattle;
            result[6] = priceBytes[0];
            result[7] = priceBytes[1];

            return result;
        }

        public static Item ParseHex(byte[] input)
        {
            if (input.Length != 8)
                throw new ArgumentException("This pointer table entry isn't eight hex codes long...");

            var result = new Item();

            var namePointerTemp = HexHelpers.HexStringToInt(input[1].ToString("X2") + input[0].ToString("X2")); //for example, 4A80. we can swap it here so it's 804A
            result.NameTextOffset = (namePointerTemp - 0x7FF0).ToString("X4"); //subtract the magic NES number to get the proper ROM offset: 5A

            var itemProperties = HexHelpers.IntToBinaryString(input[2]); //get the one with all of the boolean values in it
            itemProperties = HexHelpers.Pad(itemProperties, 8); //pad the thing with zeroes so all of the properties can be set

            //set properties based on the 1s and 0s
            result.Permanent = GetProperty(itemProperties, 0);
            result.Edible = GetProperty(itemProperties, 1);
            result.Unknown2 = GetProperty(itemProperties, 2);
            result.Unknown1 = GetProperty(itemProperties, 3);
            result.TeddyUsable = GetProperty(itemProperties, 4);
            result.LloydUsable = GetProperty(itemProperties, 5);
            result.AnaUsable = GetProperty(itemProperties, 6);
            result.NintenUsable = GetProperty(itemProperties, 7);

            result.WeaponStrength = input[3];
            result.EffectOutsideOfBattle = input[4];
            result.EffectInBattle = input[5];

            var priceTemp = input[7].ToString("X2") + input[6].ToString("X2"); //the price is stored swapped, with no extra math applied to it! We can just swap the numbers like so.
            result.Price = HexHelpers.HexStringToInt(priceTemp);

            return result;
        }

        private static bool GetProperty(string input, int position)
        {
            return input.Substring(position, 1) == "1"; //return true for 1 and false for 0. Thanks for the simplification, ReSharper
        }

        //https://www.newtonsoft.com/json/help/html/SerializingCollections.htm
        public static void ExportJSON(Item[] itemData)
        {
            var json = JsonConvert.SerializeObject(itemData, Formatting.Indented);
            FileStuff.ExportItemJSON(json);
        }

        public static Item[] ImportJSON(string json)
        {
            var results = JsonConvert.DeserializeObject<List<Item>>(json);
            return results.ToArray();
        }

    }
}
