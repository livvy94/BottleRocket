﻿// namespace BottleRocket.Core
// {
// //    public class Item
// //    {
// //        //In the future, something cool to do would be to make it not dependent on there being the same number of entries,
// //        //and make it so that you can change the order, and it affects references to item numbers throughout the map data/rest of the ROM
// //        //to let people "refactor" item usage and shuffle them around.
// //        //Though now that just sounds like a pipe dream that might not even be worth it lmao

// //        public string NameTextOffset { get; set; }

// //        public bool NintenUsable { get; set; } //Second half   000X 0000
// //        public bool AnaUsable { get; set; }    //Second half   00X0 0000
// //        public bool LloydUsable { get; set; }  //Second half   0X00 0000
// //        public bool TeddyUsable { get; set; }  //Second half   X000 0000

// //        public bool Unknown1 { get; set; }     //First half    0000 000X
// //        public bool Unknown2 { get; set; }     //First half    0000 00X0
// //        public bool Edible { get; set; }       //First half    0000 0X00
// //        public bool Permanent { get; set; }    //First half    0000 X000

// //        public int EquippableStrength { get; set; }
// //        public string Type { get; set; }
// //        public byte EffectOutsideOfBattle { get; set; }
// //        public byte EffectInBattle { get; set; }
// //        public int Price { get; set; }

// //        public byte[] GenerateTableEntry()
// //        {
// //            byte[] result = new byte[8];

// //            int textOffsetTemp = HexHelpers.HexStringToInt(NameTextOffset) + 0x7FF0;
// //            string namePointerBytes = textOffsetTemp.ToString("X4");

// //            //5A

// //            byte digit2 = Convert.ToByte(
// //            HexHelpers.InterpretBoolsAsBinary(new bool[]
// //            {       //3
// //                    Permanent,     //0
// //                    Edible,        //0
// //                    Unknown2,      //1
// //                    Unknown1,      //1

// //                    //F
// //                    TeddyUsable,   //1
// //                    LloydUsable,   //1
// //                    AnaUsable,     //1
// //                    NintenUsable   //1

// //                //...results in 0x3F
// //            }));

// //            //build the third number
// //            var tempThree = HexHelpers.IntToBinaryString(EquippableStrength, 6);

// //            if (Type == "Weapon") tempThree += "00";
// //            else if (Type == "Coin") tempThree += "01";
// //            else if (Type == "Ring") tempThree += "10";
// //            else if (Type == "Pendant") tempThree += "11";
// //            else throw new ArgumentException(
// //                @"Items can only be weapons, coins, rings, or pendants...
// //Normal items are just weapons with zero strength, which makes them non-equippable.");

// //            tempThree = HexHelpers.Reverse(tempThree); //the 1s and 0s stored in reverse order...ick

// //            byte[] priceBytes = HexHelpers.HexStringToByteArray(HexHelpers.Swap(Price.ToString("X4")));

// //            result[0] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(2, 2));
// //            result[1] = (byte)HexHelpers.HexStringToInt(namePointerBytes.Substring(0, 2));

// //            result[2] = digit2;
// //            result[3] = (byte)HexHelpers.BinaryStringToInt(tempThree);
// //            result[4] = EffectOutsideOfBattle;
// //            result[5] = EffectInBattle;
// //            result[6] = priceBytes[0];
// //            result[7] = priceBytes[1];

// //            return result;
// //        }

// //        public static Item ParseHex(byte[] input)
// //        {
// //            if (input.Length != 8)
// //                throw new ArgumentException("This pointer table entry isn't eight hex codes long...");

// //            var result = new Item();

// //            var namePointerTemp = HexHelpers.HexStringToInt(input[1].ToString("X2") + input[0].ToString("X2")); //for example, 4A80. we can swap it here so it's 804A
// //            result.NameTextOffset = (namePointerTemp - 0x7FF0).ToString("X4"); //subtract the magic NES number to get the proper ROM offset: 5A

// //            var itemProperties = HexHelpers.IntToBinaryString(input[2]); //get the one with all of the boolean values in it
// //            itemProperties = HexHelpers.Pad(itemProperties, 8); //pad the thing with zeroes so all of the properties can be set

// //            var strengthAndTypeTemp = HexHelpers.IntToBinaryString(input[3], 8);
// //            var strengthAndTypeTemp2 = HexHelpers.Reverse(strengthAndTypeTemp); //make the string of 1s and 0s not be in reverse order so we can work with it
// //            var typeTemp = HexHelpers.BinaryStringToInt(strengthAndTypeTemp2.Substring(6, 2));
// //            var strengthTemp = HexHelpers.BinaryStringToInt(strengthAndTypeTemp.Substring(2, 6));

// //            //set properties based on the 1s and 0s
// //            result.Permanent = GetProperty(itemProperties, 0);
// //            result.Edible = GetProperty(itemProperties, 1);
// //            result.Unknown2 = GetProperty(itemProperties, 2);
// //            result.Unknown1 = GetProperty(itemProperties, 3);
// //            result.TeddyUsable = GetProperty(itemProperties, 4);
// //            result.LloydUsable = GetProperty(itemProperties, 5);
// //            result.AnaUsable = GetProperty(itemProperties, 6);
// //            result.NintenUsable = GetProperty(itemProperties, 7);

// //            result.EquippableStrength = strengthTemp;

// //            if (typeTemp == 0) result.Type = "Weapon";
// //            if (typeTemp == 1) result.Type = "Coin";
// //            if (typeTemp == 2) result.Type = "Ring";
// //            if (typeTemp == 3) result.Type = "Pendant";

// //            result.EffectOutsideOfBattle = input[4];
// //            result.EffectInBattle = input[5];

// //            var priceTemp = input[7].ToString("X2") + input[6].ToString("X2"); //the price is stored swapped, with no extra math applied to it! We can just swap the numbers like so.
// //            result.Price = HexHelpers.HexStringToInt(priceTemp);

// //            return result;
// //        }

// //        private static bool GetProperty(string input, int position)
// //        {
// //            return input.Substring(position, 1) == "1"; //return true for 1 and false for 0. Thanks for the simplification, ReSharper
// //        }

// //        //https://www.newtonsoft.com/json/help/html/SerializingCollections.htm
// //        public static void ExportJSON(Item[] itemData)
// //        {
// //            var json = JsonConvert.SerializeObject(itemData, Formatting.Indented);
// //            FileStuff.ExportJson(json, ItemConstants.JSON_PATH);
// //        }
// //        public static Item[] ImportJSON(string json)
// //        {
// //            var results = JsonConvert.DeserializeObject<List<Item>>(json);
// //            return results.ToArray();
// //        }
// }