using System;
using System.Runtime.InteropServices;

namespace BottleRocket.Core
{
    [StructLayout(LayoutKind.Sequential, Size=8, CharSet=CharSet.Ansi)]
    public struct Item
    {
        public ushort RawRomOffset;
        public ItemAttributes ItemAttributes;
        public byte Equipment; //bits 0-5 can mean different things
        public byte ItemActionNonBattle;
        public byte ItemActionBattle;
        public ushort Price;

        public ushort RomOffset => (ushort)(RawRomOffset - 0x7FF0);

        [System.Obsolete("TODO Remove GenerateTableEntry")]
        public byte[] GenerateTableEntry()
        {
            throw new NotImplementedException("wowee");
            var result = new byte[8];

            return result;
        }

        [System.Obsolete("TODO Remove ImportJSON")]
        public static Item[] ImportJSON(string json)
        {
            throw new NotImplementedException();
        }

        [System.Obsolete("TODO Remove ParseHex")]
        public static Item ParseHex(byte[] tableEntry)
        {
            throw new NotImplementedException();
        }
    }
}