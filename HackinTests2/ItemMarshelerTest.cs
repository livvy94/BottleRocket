using NUnit.Framework;

namespace BottleRocket.Core.Tests
{
    /// <summary>
    /// ROM offset is little-endian
    /// When you're reading it in a hex editor, it'll look like 34 12, but the actual value is 0x1234)
    /// </summary>
    [TestFixture]
    public class ItemMarshelerTest
    {
        [Test]
        public void ItemToPointerTableEntry()
        {
            var itemInRom = new byte[]
            {
                0x72, 0x80, 0x01, 0x1E, 0x02, 0x00, 0xE8, 0x03
            };
            var expectedItem = new Item
            {
                RawRomOffset = 0x8072,
                ItemAttributes = ItemAttributes.NintenUsable,
                Equipment = 0x1E,
                ItemActionNonBattle = 0x02,
                ItemActionBattle = 0x00,
                Price = 0x03E8
            };

            var actualItem = ItemMarsheler.ReadFrom(itemInRom);

            Assert.That(expectedItem, Is.EqualTo(actualItem));
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.NintenUsable), Is.True);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.AnaUsable), Is.False);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.LloydUsable), Is.False);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.TeddyUsable), Is.False);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Unknown1), Is.False);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Unknown2), Is.False);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Edible), Is.False);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Permanent), Is.False);
        }

        [Test]
        public void ItemToPointerTableEntry_NewTotallyRadicalExtendedOffset()
        {
            var itemInRom = new byte[]
            {
                0x6D, 0x83, 0x3F, 0x00, 0x00, 0x3C, 0x00, 0x00
            };
            var expectedItem = new Item
            {
                RawRomOffset = 0x836D,
                ItemAttributes = (ItemAttributes)0x3F,
                Equipment = 0x00,
                ItemActionNonBattle = 0x00,
                ItemActionBattle = 0x3C,
                Price = 0x0000,
            };

            var actualItem = ItemMarsheler.ReadFrom(itemInRom);

            Assert.That(expectedItem, Is.EqualTo(actualItem));
            Assert.That(expectedItem.RomOffset, Is.EqualTo(0x037D));
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.NintenUsable), Is.True);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.AnaUsable), Is.True);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.LloydUsable), Is.True);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.TeddyUsable), Is.True);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Unknown1), Is.True);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Unknown2), Is.True);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Edible), Is.False);
            Assert.That(expectedItem.ItemAttributes.HasFlag(ItemAttributes.Permanent), Is.False);
        }
    }
}
