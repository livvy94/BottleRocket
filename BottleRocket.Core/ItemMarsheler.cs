using System;
using System.Runtime.InteropServices;

namespace BottleRocket.Core
{
    public static class ItemMarsheler
    {
        private const int MARSHEL_ITEM_SIZE = 8;

        public static Item ReadFrom(byte[] buffer)
        {
            var objType = typeof(Item);
            var ptrObj = Marshal.AllocHGlobal(MARSHEL_ITEM_SIZE);
            if (ptrObj == IntPtr.Zero)
                throw new Exception($"Couldn't allocate memory to create object of type {objType}");

            Marshal.Copy(buffer, 0, ptrObj, MARSHEL_ITEM_SIZE);
            var obj = Marshal.PtrToStructure(ptrObj, objType);
            Marshal.FreeHGlobal(ptrObj);
            return (Item)obj;
        }
    }
}
