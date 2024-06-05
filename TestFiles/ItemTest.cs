using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class ItemTest
    {
        private Item _testItem = new Item(new string[] { "sword" }, "a bronze sword", "a sharp sword");
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ItemIsIdentifiable()
        {
            Assert.IsTrue(_testItem.AreYou("sword"));
        }
        [Test]
        public void ShortDescription()
        {
            Assert.That(_testItem.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
        }
        [Test]
        public void FullDescription()
        {
            Assert.That(_testItem.FullDescription, Is.EqualTo("a sharp sword"));
        }
    }
}
