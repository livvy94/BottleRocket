using NUnit.Framework;
using BottleRocket.Tables;

namespace Hex_Serialization_Tests
{
    class TrainDestinationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        byte[] destination1 = new byte[]
            {
                0xED,
                0x83,
                0x94, //10010100
                0x4F, //01001111
                0xC5, //11000101
                0x53, //01010011
                0x10,
                0x00,
            };

        //[Test]
        //public void DestToPointerTableEntry()
        //{
        //    var test = new TrainDestination
        //    {
        //        NameTextOffset = "03FD",
        //        MusicToPlay = 9,
        //        TrainStartLocationX = 1937,
        //        StartDirection = "southeast",
        //        TrainStartLocationY = 1621,
        //        Price = 16
        //    };

        //    var result = test.GenerateTableEntry();

        //    Assert.AreEqual(destination1, result);
        //}
    }
}
