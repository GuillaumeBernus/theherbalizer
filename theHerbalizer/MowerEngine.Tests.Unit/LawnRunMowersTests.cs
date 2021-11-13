using MowerEngine.Models;
using System.Collections.Generic;
using Xunit;

namespace MowerEngine.Tests.Unit
{
    public class LawnRunMowersTests
    {
        [Fact]
        public void RunMowers_WhenCorrectlyParametrized_ReturnsAResultForEachMower()
        {
            Point upperRigthCorner = Tools.GetPoint(10, 10);
            var mowers = new List<Mower>();
            mowers.Add(Tools.GetRandomMower(upperRigthCorner));
            mowers.Add(Tools.GetRandomMower(upperRigthCorner));
            mowers.Add(Tools.GetRandomMower(upperRigthCorner));
            mowers.Add(Tools.GetRandomMower(upperRigthCorner));
            var lawn = new Lawn(mowers, upperRigthCorner);

            var actual = lawn.RunMowers();

            Assert.NotNull(actual);
            Assert.Equal(actual.Count, mowers.Count);
        }
    }
}