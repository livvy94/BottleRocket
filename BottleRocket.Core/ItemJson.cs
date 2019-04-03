using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BottleRocket.Core
{
    public class ItemJson
    {
        public string RomOffset {get; private set;}
        public static ItemJson FromItem(Item items)
        {
            return new ItemJson
            {
                RomOffset = (items.RawRomOffset - 0x7FF0).ToString("X4"),
            };
        }
    }

    public class ItemJsonReader
    {
        public Item[] Read(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            {
                var json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<ItemJson>>(json)
                    .Select(ItemJsonMapper.ToItem)
                    .ToArray();
            }
        }
    }

    public class ItemJsonWriter
    {
        public void Write(ItemJson[] items, Stream stream)
        {
        }
    }

    public class ItemJsonMapper
    {
        public static ItemJson FromItem(Item item)
        {
            return new ItemJson();
        }

        public static Item ToItem(ItemJson item)
        {
            return new Item();
        }
    }
}
