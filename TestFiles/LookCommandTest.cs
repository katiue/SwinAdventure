using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommandTest
    {
        public Player _player = new Player("Khang", "Student");
        public Item item1 = new Item(new string[] { "gem" }, "gem", "An expensive gem");
        public Item item2 = new Item(new string[] { "shield" }, "shield", "A shield");

        [SetUp]
        public void SetUp()
        {
        }
        [Test]
        public void LookAtMe()
        {
            Player _player = new Player("Khang", "Student");
            LookCommand look = new LookCommand();
            Assert.That(look.Execute(_player, ["look", "at", "inventory"]), Is.EqualTo("You are Khang, Student. You are carrying:\n    "));
        }
        [Test]
        public void LookAtGem()
        {
            Player _player = new Player("Khang", "Student");
            LookCommand look = new LookCommand();
            _player.Inventory.Put(item1);
            Assert.That(look.Execute(_player, ["look", "at", "gem"]), Is.EqualTo("An expensive gem"));
        }
        [Test]
        public void LookAtUnk()
        {
            Player _player = new Player("Khang", "Student");
            LookCommand look = new LookCommand();
            Assert.That(look.Execute(_player, ["look", "at", "gem"]), Is.EqualTo("I cannot find the gem"));
        }
        [Test]
        public void LookAtGemInMe()
        {
            LookCommand look = new LookCommand();
            _player.Inventory.Put(item1);
            Assert.That(look.Execute(_player, ["look", "at", "gem", "in", "inventory"]), Is.EqualTo("An expensive gem"));
        }
        [Test]
        public void LookAtGemInBag()
        {
            LookCommand look = new LookCommand();
            Bag bag = new Bag(new string[] { "bag" }, "bag", "A bag");
            bag.Inventory.Put(item1);
            _player.Inventory.Put(bag);
            Assert.That(look.Execute(_player, ["look", "at", "gem", "in", "bag"]), Is.EqualTo("An expensive gem"));
        }
        [Test]
        public void LookAtGemInNoBag()
        {
            Player _player = new Player("Khang", "Student");
            LookCommand look = new LookCommand();
            Assert.That(look.Execute(_player, ["look", "at", "gem", "in", "bag"]), Is.EqualTo("I cannot find the bag"));
        }
        [Test]
        public void LookAtGemInNoGem()
        {
            Player _player = new Player("Khang", "Student");
            LookCommand look = new LookCommand();
            Bag bag = new Bag(new string[] { "bag" }, "bag", "A bag");
            _player.Inventory.Put(bag);
            Assert.That(look.Execute(_player, ["look", "at", "gem", "in", "bag"]), Is.EqualTo("I cannot find the gem"));
        }
        [Test]
        public void InvalidLook()
        {
            LookCommand look = new LookCommand();
            Assert.That(look.Execute(_player, ["look", "around"]), Is.EqualTo("I don't know how to look like that"));
            Assert.That(look.Execute(_player, ["hello", "Mr.Eric", "Le"]), Is.EqualTo("Error in look input"));
            Assert.That(look.Execute(_player, ["look", "at", "a", "at", "b"]), Is.EqualTo("What do you want to look in?"));
        }
    }
}
