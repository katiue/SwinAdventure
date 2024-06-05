using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace SwinAdventure
{
    public class BagTest
    {
        private Bag _testBag = new Bag(new string[] { "bag", "sack" }, "a bag", "a small bag");
        private Item _testItem = new Item(new string[] { "id", "item" }, "an item", "a test item");
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void BagLocateItem()
        {
            Bag _testBag = new Bag(new string[] { "bag", "sack" }, "a bag", "a small bag");
            Item _testItem = new Item(new string[] { "id", "item" }, "an item", "a test item");
            _testBag.Inventory.Put(_testItem);
            Assert.That(_testBag.Locate("id"), Is.EqualTo(_testItem));
        }
        [Test]
        public void BagLocateItSelf()
        {
            Assert.That(_testBag, Is.EqualTo(_testBag.Locate("bag")));
        }
        [Test]
        public void BagLocateNothing()
        {
            _testBag.Inventory.Put(_testItem);
            Assert.That(_testBag.Locate("shovel"), Is.EqualTo(null));
        }
        [Test]
        public void BagFullDescription()
        {
            _testBag.Inventory.Put(_testItem);
            Assert.That(_testBag.FullDescription, Is.EqualTo("In the a bag you can see:\n    an item (id)\n    "));
        }
        [Test]
        public void BagInBag()
        {
            Bag _testBag = new Bag(new string[] { "bag", "sack" }, "a bag", "a small bag");
            Bag _testBag2 = new Bag(new string[] { "bag2", "sack2" }, "a bag2", "a small bag2");

            Item _testItem = new Item(new string[] { "id", "item" }, "an item", "a test item");
            Item _testItem2 = new Item(new string[] { "id2", "item2" }, "an item2", "a test item2");

            _testBag.Inventory.Put(_testBag2);
            _testBag.Inventory.Put(_testItem);
            _testBag2.Inventory.Put(_testItem2);

            Assert.That(_testBag.Locate("bag2"), Is.EqualTo(_testBag2));
            Assert.That(_testBag.Locate("id"), Is.EqualTo(_testItem));
            Assert.That(_testBag.Locate("id2"), Is.EqualTo(null));
        }
    }
}
