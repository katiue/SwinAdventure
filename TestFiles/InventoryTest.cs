using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class InventoryTest
    {
        private Inventory? _testInventory;
        private Item sword = new Item(new string[] { "sword" }, "a bronze sword", "a sharp sword");
        private Item shovel = new Item(new string[] { "shovel" }, "a iron shovel", "a new shovel ready to burry anything");

        [SetUp]
        public void Setup()
        {
        
        }
        [Test]
        public void FindItem()
        {
            _testInventory = new Inventory();
            _testInventory.Put(sword);
            Assert.IsTrue(_testInventory.HasItem("sword"));
        }
        [Test]
        public void NoItemFind()
        {
            _testInventory = new Inventory();
            _testInventory.Put(sword);
            Assert.IsFalse(_testInventory.HasItem("shovel"));
        }
        [Test]
        public void FetchItem()
        {
            _testInventory = new Inventory();
            _testInventory.Put(sword);
            Assert.That(sword,Is.EqualTo(_testInventory.Fetch("sword")));
        }
        [Test]
        public void TakeItem()
        {
            _testInventory = new Inventory();
            _testInventory.Put(sword);
            _testInventory.Take("sword");
            Assert.That(_testInventory.Fetch("sword"), Is.EqualTo(null));
        }
    }
}
