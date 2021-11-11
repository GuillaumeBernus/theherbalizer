using MowerEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var lawn = new Lawn(mowers)
            {
                UpperRigthCorner = upperRigthCorner
            };

            var actual=lawn.RunMowers();

            Assert.NotNull(actual);
            Assert.Equal(actual.Count, mowers.Count);
        }


    }
}
