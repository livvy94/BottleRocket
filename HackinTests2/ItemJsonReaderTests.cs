using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace BottleRocket.Core.Tests
{
    [TestFixture]
    public class ItemJsonReaderTests
    {
        [TestCase("GoldenFiles\\golden_items.json")]
        public void GoldenFileTest(string goldenFileRelativePath)
        {
            var actualItems = new List<Item>();
            var itemReader = new ItemJsonReader();
            var absolutePath = Path.Combine(TestContext.CurrentContext.TestDirectory, goldenFileRelativePath);
            var expectedItems = new Item[]
            {
                new Item
                {
                    RawRomOffset = ItemConstants.ITEM_ROM_OFFSET + 0x0011,
                    ItemAttributes = ItemAttributes.NintenUsable |
                                     ItemAttributes.AnaUsable |
                                     ItemAttributes.LloydUsable |
                                     ItemAttributes.TeddyUsable |
                                     ItemAttributes.Unknown1 |
                                     ItemAttributes.Unknown2,
                    Equipment = 0b0000_0001,
                    ItemActionNonBattle = 0x10,
                    ItemActionBattle = 0x75,
                    Price = 0
                },
                new Item
                {
                    RawRomOffset = ItemConstants.ITEM_ROM_OFFSET + 0x016E,
                    ItemAttributes = ItemAttributes.NintenUsable |
                                     ItemAttributes.AnaUsable |
                                     ItemAttributes.LloydUsable |
                                     ItemAttributes.TeddyUsable |
                                     ItemAttributes.Unknown1 |
                                     ItemAttributes.Unknown2,
                    Equipment = 0b0100_0101,
                    ItemActionNonBattle = 0x02,
                    ItemActionBattle = 0x00,
                    Price = 260
                },
            };

            using (var fileStream = new FileStream(absolutePath, FileMode.Open))
            {
                actualItems.AddRange(itemReader.Read(fileStream));
            }

            Assert.That(actualItems, Is.EquivalentTo(expectedItems));
        }
    }
}
