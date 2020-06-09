using NUnit.Framework;
using BottleRocket.Tables;

namespace Hex_Serialization_Tests
{
    class TeleportTests
    {

        byte[] location1 = new byte[]{ 0xD3, 0x83, 0x86, 0x33, 0x46, 0x51, 0x00, 0x00 };
        byte[] location2 = new byte[]{ 0x11, 0x84, 0x86, 0xCA, 0x83, 0x4B, 0x00, 0x00 };

        //[Test]
        //public void LocationToPointerTableEntry()
        //{
        //    var test = new TeleportDestination
        //    {
        //        NameTextOffset = "03E3",
        //        Song = 0x86,
        //        X = 0x33,
        //        MinitileCode = 4,
        //        Direction = "west",
        //        Y = 0x51
        //    };

        //    var testBytes = test.GenerateTableEntry();

        //    Assert.AreEqual(location1, testBytes);
        //}

        //[Test]
        //public void LocationToPointerTableEntry2()
        //{
        //    var test = new TeleportDestination
        //    {
        //        NameTextOffset = "0421",
        //        Song = 0x86,
        //        X = 0xCA,
        //        MinitileCode = 8,
        //        Direction = "southeast",
        //        Y = 0x4B
        //    };

        //    Assert.AreEqual(location2, test.GenerateTableEntry());
        //}

        //[Test]
        //public void HexToLocation1()
        //{
        //    var test = TeleportDestination.ParseHex(location1);

        //    var expectedLocation = new TeleportDestination
        //    {
        //        NameTextOffset = "03E3",
        //        Song = 0x86,
        //        X = 0x33,
        //        MinitileCode = 4,
        //        Direction = "west",
        //        Y = 0x51
        //    };

        //    Assert.AreEqual(expectedLocation.NameTextOffset, test.NameTextOffset);
        //    Assert.AreEqual(expectedLocation.Song, test.Song);
        //    Assert.AreEqual(expectedLocation.X, test.X);
        //    Assert.AreEqual(expectedLocation.Direction, test.Direction);
        //    Assert.AreEqual(expectedLocation.MinitileCode, test.MinitileCode);
        //    Assert.AreEqual(expectedLocation.Y, test.Y);
        //}

        //[Test]
        //public void HexToLocation2()
        //{
        //    var expectedLocation = new TeleportDestination
        //    {
        //        NameTextOffset = "0421",
        //        Song = 0x86,
        //        X = 0xCA,
        //        MinitileCode = 8,
        //        Direction = "west",
        //        Y = 0x4B
        //    };

        //    var test = TeleportDestination.ParseHex(location2);

        //    Assert.AreEqual(expectedLocation.NameTextOffset, test.NameTextOffset);
        //    Assert.AreEqual(expectedLocation.Song, test.Song);
        //    Assert.AreEqual(expectedLocation.X, test.X);
        //    Assert.AreEqual(expectedLocation.Direction, test.Direction);
        //    Assert.AreEqual(expectedLocation.MinitileCode, test.MinitileCode);
        //    Assert.AreEqual(expectedLocation.Y, test.Y);
        //}
    }
}
