using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuaythaiSportManagementSystemApi.Fights;

namespace MuaythaiSportManagementSystemApiTests
{
    [TestClass]
    public class FightTreeTest
    {
        [TestMethod]
        public void TestOneFighter()
        {
            FightsTree tree = new FightsTree(1);
            Assert.AreEqual(0, tree.Root.Children.Count);
            Assert.AreNotEqual(tree.Root.Fight, null);
            Assert.AreEqual(tree.Root.Parent, null);
        }

        [TestMethod]
        public void TestTwoFighters()
        {
            FightsTree tree = new FightsTree(2);
            Assert.AreEqual(1, tree.Root.Children.Count);
            Assert.AreNotEqual(tree.Root.Fight, null);
            Assert.AreEqual(tree.Root.Parent, null);
        }

        [TestMethod]
        public void TestThreeFighters()
        {
            FightsTree tree = new FightsTree(3);
            Assert.AreEqual(1, tree.Root.Children.Count);
            Assert.AreNotEqual(tree.Root.Fight, null);
            Assert.AreEqual(tree.Root.Parent, null);

            tree.Print();
        }
    }
}
