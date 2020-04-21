using BottleRocket.Tables;
using NUnit.Framework;

namespace HackinTests
{
    [TestFixture]
    public class TeleportTests
    {
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

            var test = TeleportLocation.ParseHex(tableEntry);

            var expectedLocation = new TeleportLocation
            {
                NameTextOffset = "03E3",
                Song = 0x86,
                X = 0x33,
                MinitileCode = 4,
                Direction = "west",
                Y = 0x51
            };

            Assert.AreEqual(expectedLocation.NameTextOffset, test.NameTextOffset);
            Assert.AreEqual(expectedLocation.Song, test.Song);
            Assert.AreEqual(expectedLocation.X, test.X);
            Assert.AreEqual(expectedLocation.Direction, test.Direction);
            Assert.AreEqual(expectedLocation.MinitileCode, test.MinitileCode);
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
                Song = 0x86,
                X = 0xCA,
                MinitileCode = 8,
                Direction = "west",
                Y = 0x4B
            };

            var test = TeleportLocation.ParseHex(tableEntry);

            Assert.AreEqual(expectedLocation.NameTextOffset, test.NameTextOffset);
            Assert.AreEqual(expectedLocation.Song, test.Song);
            Assert.AreEqual(expectedLocation.X, test.X);
            Assert.AreEqual(expectedLocation.Direction, test.Direction);
            Assert.AreEqual(expectedLocation.MinitileCode, test.MinitileCode);
            Assert.AreEqual(expectedLocation.Y, test.Y);
        }

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
                Song = 0x86,
                X = 0x33,
                MinitileCode = 4,
                Direction = "west",
                Y = 0x51
            };

            var testBytes = test.GenerateTableEntry();

            Assert.AreEqual(expectedEntry, testBytes);
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
                0x83,
                0x4B,
                0x00,
                0x00
            };

            var test = new TeleportLocation
            {
                NameTextOffset = "0421",
                Song = 0x86,
                X = 0xCA,
                MinitileCode = 8,
                Direction = "southeast",
                Y = 0x4B
            };

            Assert.AreEqual(expectedEntry, test.GenerateTableEntry());
        }
    }
}