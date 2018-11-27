using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BottleRocket
{
    class FileStuff
    {
        private const string FINISHED = @"Finished inserting data! Refresh your hex editor!";
        private const string ITEM_JSON_PATH = @"item_configuration_table.json";

        public static string ROMpath = string.Empty;

        public static bool RomIsGood(string filepath)
        {
            ROMpath = filepath;
            var result = ROMpath.ToUpper().Contains(".NES");

            using (var reader = new BinaryReader(File.Open(ROMpath, FileMode.Open)))
            {
                reader.BaseStream.Position = 0x00;
                if (HexHelpers.ReaderToASCII(reader, 3) != "NES")
                    result = false;

                reader.BaseStream.Position = 0x03FFF0;
                if (HexHelpers.ReaderToASCII(reader, 11) != "EARTH BOUND")
                    result = false;
            }

            return result;
        }

        public static bool ROMisLoaded()
        {
            var status = ROMpath != string.Empty;
            if (!status) MessageBox.Show(@"Please open a ROM!");
            return status;
        }

        public static void ExportItemJSON(string json)
        {
            using (var writer = new StreamWriter(ITEM_JSON_PATH))
            {
                writer.Write(json);
            }
            MessageBox.Show($"Finished writing {ITEM_JSON_PATH}");
        }

        public static Item[] LoadItemDataFromROM()
        {
            //Read the item configuration table in the ROM, and parse what it finds into Item objects

            var itemTableContents = new List<Item>();
            using (var reader = new BinaryReader(File.Open(ROMpath, FileMode.Open))) //Does this belong in Item.cs?
            {
                reader.BaseStream.Position = Item.START_OFFSET;

                while (reader.BaseStream.Position < Item.END_OFFSET)
                {
                    var tableEntry = reader.ReadBytes(8);
                    itemTableContents.Add(Item.ParseHex(tableEntry));
                }
            }

            return itemTableContents.ToArray();
        }

        public static Item[] LoadItemDataFromJSON()
        {
            var jsonText = string.Empty;
            using (var reader = new StreamReader(ITEM_JSON_PATH))
            {
                jsonText = reader.ReadToEnd();
            }

            return Item.ImportJSON(jsonText);
        }

        public static void SaveToROM(Item[] items) //eventually, there will be other overloaded versions of SaveToROM for other data
        {
            if (WrongNumberOfEntries(Item.NUMBER_OF_ENTRIES, items.Length)) return;

            //Generate a pointer table from a list of Item objects, and save it to the ROM
            var pointerTable = new List<byte>();
            foreach (var item in items)
            {
                pointerTable.AddRange(item.GenerateTableEntry());
            }

            //http://www.java2s.com/Tutorials/CSharp/System.IO/BinaryWriter/C_BinaryWriter_Write_Byte_Array.htm
            using (var stream = new FileStream(ROMpath, FileMode.Open, FileAccess.Write))
            {
                using (var romWriter = new BinaryWriter(stream))
                {
                    romWriter.Seek(Item.START_OFFSET, SeekOrigin.Begin);
                    romWriter.Write(pointerTable.ToArray());
                }
            }
            
            MessageBox.Show(FINISHED);
        }

        private static bool WrongNumberOfEntries(int expectedNumber, int number)
        {
            if (expectedNumber != number)
            {
                MessageBox.Show($"ERROR: Wrong number of items!\r\n(Should be {expectedNumber}, but instead it's {number}.)");
                return true;
            }

            return false;
        }
    }
}
