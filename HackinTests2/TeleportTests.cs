using BottleRocket.Tables;
using NUnit.Framework;

namespace HackinTests
{
    [TestFixture]
    public class TeleportTests
    {
        [Test]
        public void LocationToPointerTableEntry()
        {
            var expectedEntry = new byte[]
            {
                0xD3,
                0x83,
                0x86,
                0x33,
                0x46,
                0x51,
                0x00,
                0x00
            };

            var test = new TeleportLocation
            {
                NameTextOffset = "03E3",
                X = 0x3386, //Is this even correct??
                Y = 0x5146 //TODO: After JSON works, try increasing MyHome's X by one and see what happens
            };

            Assert.AreEqual(expectedEntry, test.GenerateTableEntry());
        }

        [Test]
        public void LocationToPointerTableEntry2()
        {
            var expectedEntry = new byte[]
            {
                0x11,
                0x84,
                0x86,
                0xCA,
                0x86,
                0x4B,
                0x00,
                0x00
            };

            var test = new TeleportLocation
            {
                NameTextOffset = "0421",
                X = 0xCA86,
                Y = 0x4B86
            };

            Assert.AreEqual(expectedEntry, test.GenerateTableEntry());
        }

        [Test]
        public void HexToLocation1()
        {
            var tableEntry = new byte[]
            {
                0xD3,
                0x83,
                0x86,
                0x33,
                0x46,
                0x51,
                0x00,
                0x00
            };

            var expectedLocation = new TeleportLocation
            {
                NameTextOffset = "03E3",
                X = 0x3386,
                Y = 0x5146
            };

            var test = TeleportLocation.ParseHex(tableEntry);

            Assert.AreEqual(expectedLocation.NameTextOffset, test.NameTextOffset);
            Assert.AreEqual(expectedLocation.X, test.X);
            Assert.AreEqual(expectedLocation.Y, test.Y);
        }

        [Test]
        public void HexToLocation2()
        {
            var tableEntry = new byte[]
            {
                0x11,
                0x84,
                0x86,
                0xCA,
                0x86,
                0x4B,
                0x00,
                0x00
            };

            var expectedLocation = new TeleportLocation
            {
                NameTextOffset = "0421",
                X = 0xCA86,
                Y = 0x4B86
            };

            var test = TeleportLocation.ParseHex(tableEntry);

            Assert.AreEqual(expectedLocation.NameTextOffset, test.NameTextOffset);
            Assert.AreEqual(expectedLocation.X, test.X);
            Assert.AreEqual(expectedLocation.Y, test.Y);
        }
    }
}