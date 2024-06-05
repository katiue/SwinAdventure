using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace SwinAdventure
{
    public class PlayerTest
    {
        private Player _testPlayer = new Player("Khang", "a friendly student");

        [Test]
        public void PlayerIsIdentifiable()
        {
            Assert.IsTrue(_testPlayer.AreYou("me"));
        }
        [Test]
        public void PlayerLocateItem()
        {
            Item sword = new Item(new string[] { "sword" }, "a bronze sword", "a sharp sword");
            Player _testPlayer = new Player("Khang", "a friendly student");
            _testPlayer.Inventory.Put(sword);
            Assert.That(_testPlayer.Locate("sword"), Is.EqualTo(sword));
        }
        [Test]
        public void PlayerLocateItSelf()
        {
            Assert.That(_testPlayer,Is.EqualTo(_testPlayer.Locate("me")));
        }
        [Test]
        public void PlayerLocateNothing()
        {
            Item sword = new Item(new string[] { "sword" }, "a bronze sword", "a sharp sword");
            _testPlayer.Inventory.Put(sword);
            Assert.That(_testPlayer.Locate("shovel"), Is.EqualTo(null));
        }
        [Test]
        public void PlayerFullDescription()
        {
            Item sword = new Item(new string[] { "sword" }, "a bronze sword", "a sharp sword");
            _testPlayer.Inventory.Put(sword);
            Assert.That(_testPlayer.FullDescription, Is.EqualTo("You are Khang, a friendly student. You are carrying:\n    a bronze sword (sword)\n    "));
        }
    }
}
