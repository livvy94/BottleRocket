namespace BottleRocket.Core
{
    public class ItemConstants
    {
        public const int START_OFFSET = 0x1810;
        public const int END_OFFSET = 0x1C10; //the last byte of the last entry is 1C0F
        public const int NUMBER_OF_ENTRIES = 128; //There are 128 items in the table, though quite a few of them are dummied out
        public const string JSON_PATH = @"item_configuration_table.json";
        public const int ITEM_ROM_OFFSET = 0x7FF0;
    }
}
