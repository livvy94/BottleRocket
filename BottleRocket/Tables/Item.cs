using System;

namespace BottleRocket.Tables
{
    public class Item
    {
        public const int START_OFFSET = 0x1800;
        public const int END_OFFSET = 0x1C00; //the last byte of the last entry is 1C0F
        public const int NUMBER_OF_ENTRIES = 128; //There are 128 items in the table, though quite a few of them are dummied out
        public const string FILENAME = "item_configuration_table";
        //In the future, something cool to do would be to make it not dependent on there being the same number of entries,
        //and make it so that you can change the order, and it affects references to item numbers throughout the map data/rest of the ROM
        //to let people "refactor" item usage and shuffle them around.
        //Though now that just sounds like a pipe dream that might not even be worth it lmao

        public string NameTextOffset;
        public bool NintenUsable;
        public bool AnaUsable;
        public bool LloydUsable;
        public bool TeddyUsable;
        public bool Unknown1;
        public bool Unknown2;
        public bool Edible;
        public bool Permanent;
        public ushort Power; //Attack value for weapons, defense value for coin/ring, resistance value for pendant
        public string Type;
        public byte EffectOutsideOfBattle;
        public byte EffectInBattle;
        public ushort Price;

        public byte[] TableEntry
        {
            get
            {
                var result = new byte[8];
                var textOffsetTemp = 0x7FF0 + int.Parse(NameTextOffset, System.Globalization.NumberStyles.HexNumber);
                var textOffsetArray = BitConverter.GetBytes(textOffsetTemp);
                var priceTemp = BitConverter.GetBytes(Price);
                if (Power > 0x3F) throw new Exception("Power can only go from 0 to 63!");
                var thirdByte = new PowerTypeCombo(Power, Type);

                result[0] = textOffsetArray[0]; //BitConverter is already little-endian so no swapping necessary!
                result[1] = textOffsetArray[1];
                result[2] = HexHelpers.InterpretBoolsAsByte(new bool[] { NintenUsable, AnaUsable, LloydUsable, TeddyUsable, Unknown1, Unknown2, Edible, Permanent});
                result[3] = thirdByte.Calculate();
                result[4] = EffectOutsideOfBattle;
                result[5] = EffectInBattle;
                result[6] = priceTemp[0];
                result[7] = priceTemp[1];
                return result;
            }
        }

        public static Item ParseHex(byte[] input)
        {
            int offsetTemp = BitConverter.ToUInt16(new byte[] { input[0], input[1] }, 0);
            offsetTemp -= 0x7FF0; //The ROM byte array will be headerless, but this is a value that people will compare to an open hex editor, where the header *will* be present. So we still need to do this, right?
            var attributesTemp = HexHelpers.InterpretByteAsBools(input[2]);
            var thirdByte = new PowerTypeCombo(input[3]);

            return new Item
            {
                NameTextOffset = offsetTemp.ToString("X4"),
                NintenUsable = attributesTemp[0],
                AnaUsable = attributesTemp[1],
                LloydUsable = attributesTemp[2],
                TeddyUsable = attributesTemp[3],
                Unknown1 = attributesTemp[4],
                Unknown2 = attributesTemp[5],
                Edible = attributesTemp[6],
                Permanent = attributesTemp[7],
                Power = thirdByte.Power,
                Type = thirdByte.Type,
                EffectOutsideOfBattle = input[4],
                EffectInBattle = input[5],
                Price = BitConverter.ToUInt16(new byte[] { input[6], input[7] })
            };
        }
    }

    class PowerTypeCombo
    {
        public ushort Power;
        public string Type;

        public PowerTypeCombo(ushort power, string type)
        {
            //Initialize with normal values
            Power = power;
            Type = type;
        }

        public PowerTypeCombo(byte input)
        {
            //Initialize with a hex number
            var inputTemp = Convert.ToString(input, 2).PadLeft(8, '0');
            var powerBytes = inputTemp.Substring(2);
            var typeBytes = inputTemp.Substring(0, 2);

            Power = Convert.ToUInt16(powerBytes, 2);
            Type = typeBytes switch
            {
                "00" => "Weapon",
                "01" => "Coin",
                "10" => "Ring",
                "11" => "Pendant",
            };
        }

        public byte Calculate()
        {
            //Generate a hex code
            var powerTemp = Convert.ToString(Power, 2).PadLeft(6, '0'); //bytes
            var typeTemp = Type switch
            {
                "Weapon"  => "00",
                "Coin"    => "01",
                "Ring"    => "10",
                "Pendant" => "11",
                _ => throw new Exception("Invalid item type! The only valid types are Weapon, Coin, Ring, and Pendant.")
            };

            var result = typeTemp + powerTemp;
            return Convert.ToByte(result, 2);
        }
    }
}
