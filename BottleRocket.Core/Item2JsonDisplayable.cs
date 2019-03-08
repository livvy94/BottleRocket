namespace BottleRocket.Core
{
    public class Item2JsonDisplayable
    {
        public string RomOffset {get; private set;}
        public static Item2JsonDisplayable FromItem(Item items)
        {
            return new Item2JsonDisplayable
            {
                RomOffset = (items.RawRomOffset - 0x7FF0).ToString("X4"),
            };
        }
    }
}