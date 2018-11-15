using System;
using NUnit.Framework;
using BottleRocket;

namespace HackinTests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void ItemToPointerTableEntry()
        {
            var expectedEntry = new byte[8]
            {
                //the Stun Gun. info from http://pkhack.fobby.net/misc/txt/eb0_1810.txt
                0x4A,
                0x80,
                0x04,
                0x0F,
                0x02,
                0x00,
                0x2C,
                0x01
            };

            var test = new Item
            {
                NameTextOffset = 0x5A, //pointer is 4A80. swap it. 804A - 7FF0 = 5A <-- actual offset
                NintenUsable = false,
                AnaUsable = false,
                LloydUsable = true,
                TeddyUsable = false,
                Unknown1 = false,
                Unknown2 = false,
                Edible = false,
                Permanent = false,
                WeaponStrength = 0x0F,
                EffectOutsideOfBattle = 0x02,
                EffectInBattle = 0x00,
                Price = 300 //entry in the pointer table is 2C01, 012C is 300 in decimal
            };

            Assert.AreEqual(expectedEntry, test.GenerateTableEntry());
        }

        [Test]
        public void PointerTableEntryToItem()
        {
            var tableEntry = new byte[8]
            {
                //the Stun Gun
                0x4A,
                0x80,
                0x04,
                0x0F,
                0x02,
                0x00,
                0x2C,
                0x01
            };

            var expectedItem = new Item
            {
                NameTextOffset = 0x5A,
                NintenUsable = false,
                AnaUsable = false,
                LloydUsable = true,
                TeddyUsable = false,
                Unknown1 = false,
                Unknown2 = false,
                Edible = false,
                Permanent = false,
                WeaponStrength = 0x0F,
                EffectOutsideOfBattle = 0x02,
                EffectInBattle = 0x00,
                Price = 300
            };

            var test = Item.ParseHex(tableEntry);

            //It doesn't seem to work if I compare the objects directly, so I'm going to try this
            Assert.AreEqual(expectedItem.NameTextOffset, test.NameTextOffset);
            Assert.AreEqual(expectedItem.NintenUsable, test.NintenUsable);
            Assert.AreEqual(expectedItem.AnaUsable, test.AnaUsable);
            Assert.AreEqual(expectedItem.LloydUsable, test.LloydUsable);
            Assert.AreEqual(expectedItem.TeddyUsable, test.TeddyUsable);
            Assert.AreEqual(expectedItem.Unknown1, test.Unknown1);
            Assert.AreEqual(expectedItem.Unknown2, test.Unknown2);
            Assert.AreEqual(expectedItem.Edible, test.Edible);
            Assert.AreEqual(expectedItem.Permanent, test.Permanent);
            Assert.AreEqual(expectedItem.WeaponStrength, test.WeaponStrength);
            Assert.AreEqual(expectedItem.EffectOutsideOfBattle, test.EffectOutsideOfBattle);
            Assert.AreEqual(expectedItem.EffectInBattle, test.EffectInBattle);
            Assert.AreEqual(expectedItem.Price, test.Price);
        }
    }
}
