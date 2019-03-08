using System;
using BottleRocket.Tables;
using NUnit.Framework;

namespace BottleRocket.Core.Tests
{
    [TestFixture]
    public class TrainDestinationTests
    {
        [Test]
        public void DestToPointerTableEntry()
        {
            var expectedEntry = new byte[]
            {
                0xED, 0x83, 0x94, 0x4F, 0xC5, 0x53, 0x10, 0x00,
            };

            var test = new TrainDestination
            {
                NameTextOffset = "03FD",
                MusicToPlay = 9,
                TrainStartLocationX = 1937,
                StartDirection = "southeast",
                TrainStartLocationY = 1621,
                Price = 16
            };

            var result = test.GenerateTableEntry();

            Assert.AreEqual(expectedEntry, result);
        }

        //[Test]
        //HexToDestination()
        //{
        //    var tableEntry = new byte[]
        //    {
        //        0xF6,
        //        0x83,
        //        0x94,
        //        0x4F,
        //        0xC5,
        //        0x53,
        //        0x19,
        //        0x00
        //    };

        //    var test = TrainDestination.ParseHex(tableEntry);

        //    var expectedDestination = new TrainDestination
        //    {
        //        NameTextOffset = "03FD",
        //        MusicToPlay = 9,
        //        TrainStartLocationX = 1937,
        //        StartDirection = "southeast",
        //        TrainStartLocationY = 1621,
        //        Price = 16
        //    };


        //}
    }
}