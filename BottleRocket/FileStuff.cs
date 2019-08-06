using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BottleRocket.Tables;

namespace BottleRocket
{
    class FileStuff
    {
        private const string FINISHED = @"Finished inserting data! Refresh your hex editor!";


        #region Methods for loading a ROM
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
        #endregion

        #region Methods for exporting and importing data
        public static void ExportData(string data, string path) //multi-purpose!
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(data);
            }
            MessageBox.Show($"Finished writing {path}");
        }


        public static Item[] LoadItemDataFromConfig()
        {
            var tomlText = string.Empty;
            using (var reader = new StreamReader(Item.TOML_PATH))
            {
                tomlText = reader.ReadToEnd();
            }

            return Item.ImportTOML(tomlText);
        }

        public static TeleportLocation[] LoadTeleportDataFromTOML()
        {
            var tomlText = string.Empty;
            using (var reader = new StreamReader(TeleportLocation.TOML_PATH))
            {
                tomlText = reader.ReadToEnd();
            }

            return TeleportLocation.ImportTOML(tomlText);
        }
        #endregion

        #region Methods for reading from the ROM
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

        public static TeleportLocation[] LoadTeleportDataFromROM()
        {
            var teleportTableContents = new List<TeleportLocation>();
            using (var reader = new BinaryReader(File.Open(ROMpath, FileMode.Open)))
            {
                reader.BaseStream.Position = TeleportLocation.START_OFFSET;

                while (reader.BaseStream.Position < TeleportLocation.END_OFFSET)
                {
                    var tableEntry = reader.ReadBytes(8);
                    teleportTableContents.Add(TeleportLocation.ParseHex(tableEntry));
                }
            }

            return teleportTableContents.ToArray();
        }
        #endregion

        #region Methods for writing to the ROM

        public static void SaveToROM(Item[] items) //eventually, there will be other overloaded versions of SaveToROM for other data
        {
            if (WrongNumberOfEntries(Item.NUMBER_OF_ENTRIES, items.Length)) return;

            //Generate a pointer table from a list of Item objects, and save it to the ROM
            var pointerTable = new List<byte>();
            foreach (var item in items)
            {
                pointerTable.AddRange(item.GenerateTableEntry());
            }

            WriteToROM(pointerTable, Item.START_OFFSET);
        }

        public static void SaveToROM(TeleportLocation[] teleportLocations)
        {
            if (WrongNumberOfEntries(TeleportLocation.NUMBER_OF_ENTRIES, teleportLocations.Length)) return;

            var teleportTable = new List<byte>();
            foreach (var location in teleportLocations)
            {
                teleportTable.AddRange(location.GenerateTableEntry());
            }

            WriteToROM(teleportTable, TeleportLocation.START_OFFSET);
        }

        public static void WriteToROM(List<byte> table, int offset) //heck yeah this is its own method now
        {
            //http://www.java2s.com/Tutorials/CSharp/System.IO/BinaryWriter/C_BinaryWriter_Write_Byte_Array.htm
            using (var stream = new FileStream(ROMpath, FileMode.Open, FileAccess.Write))
            {
                using (var romWriter = new BinaryWriter(stream))
                {
                    romWriter.Seek(offset, SeekOrigin.Begin);
                    romWriter.Write(table.ToArray());
                }
            }

            MessageBox.Show(FINISHED);
        }

        #endregion

        private static bool WrongNumberOfEntries(int expectedNumber, int number)
        {
            if (expectedNumber == number) return false;
            MessageBox.Show($"ERROR: Wrong number of items!\r\n(Should be {expectedNumber}, but instead it's {number}.)");
            return true;

        }
    }
}
