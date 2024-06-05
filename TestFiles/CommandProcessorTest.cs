using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessorTest
    {
        private Player _player = new Player("Khang", "Student");
        public Item item1 = new Item(new string[] { "gem" }, "gem", "An expensive gem");
        [Test]
        public void TestCommandProcessor()
        {
            CommandProcessor cp = new CommandProcessor();
            Player p = new Player("me", "inventory");
            string[] text = new string[] { "move", "bedroom" };
            string result = cp.Execute(p, text);
            //already in bedroom
            Assert.That(result, Is.EqualTo("I do not know that place"));
        }
        [Test]
        public void TestMoveCommand()
        {
            CommandProcessor cp = new CommandProcessor();
            Player p = new Player("me", "inventory");
            Location location = new Location(new string[] { "living room" }, "living room", "where you greet your guesses");
            Path path = new Path(new string[] { "north" }, "north", "the path to the living room", p.Location, location, false);
            p.Location.AddPath(path);
            string[] text = new string[] { "move", "north" };
            string result = cp.Execute(p, text);
            Assert.That(result, Is.EqualTo("You are now in living room"));
        }
        [Test]
        public void PathIsBlocked()
        {
            Player _player = new Player("Khang", "friendly student");
            MoveCommand moveCommand = new MoveCommand();

            Location location1 = new Location(new string[] { "living room" }, "living room", "this is your living room");
            Location location2 = new Location(new string[] { "kitchen" }, "kitchen", "this is your kitchen");
            Location location3 = new Location(new string[] { "bath room" }, "bath room", "this is your bath room");
            Location location4 = new Location(new string[] { "dining room" }, "dining room", "this is your dining room");

            Path path1 = new Path(new string[] { "north" }, "north", "You are going north", _player.Location, location1, false);
            Path path2 = new Path(new string[] { "south" }, "south", "You are going south", _player.Location, location2, false);
            Path path3 = new Path(new string[] { "east" }, "east", "You are going east", _player.Location, location3, false);
            Path path4 = new Path(new string[] { "west" }, "west", "You are going west", _player.Location, location4, true);

            _player.Location.AddPath(path1);
            _player.Location.AddPath(path2);
            _player.Location.AddPath(path3);
            _player.Location.AddPath(path4);

            Assert.That(moveCommand.Execute(_player, new string[] { "move", "west" }), Is.EqualTo("You are now in bedroom"));
        }
        [Test]
        public void PathIsValid()
        {
            Player _player = new Player("Khang", "friendly student");
            MoveCommand moveCommand = new MoveCommand();

            Location location1 = new Location(new string[] { "living room" }, "living room", "this is your living room");
            Location location2 = new Location(new string[] { "kitchen" }, "kitchen", "this is your kitchen");
            Location location3 = new Location(new string[] { "bath room" }, "bath room", "this is your bath room");
            Location location4 = new Location(new string[] { "dining room" }, "dining room", "this is your dining room");

            Path path1 = new Path(new string[] { "north" }, "north", "You are going north", _player.Location, location1, false);
            Path path2 = new Path(new string[] { "south" }, "south", "You are going south", _player.Location, location2, false);
            Path path3 = new Path(new string[] { "east" }, "east", "You are going east", _player.Location, location3, false);
            Path path4 = new Path(new string[] { "west" }, "west", "You are going west", _player.Location, location4, true);

            _player.Location.AddPath(path1);
            _player.Location.AddPath(path2);
            _player.Location.AddPath(path3);
            _player.Location.AddPath(path4);

            Assert.That(moveCommand.Execute(_player, new string[] { "move", "east" }), Is.EqualTo("You are now in bath room"));
        }
        [Test]
        public void PathIsInvalid()
        {
            Player _player = new Player("Khang", "friendly student");
            MoveCommand moveCommand = new MoveCommand();

            Location location1 = new Location(new string[] { "living room" }, "living room", "this is your living room");
            Location location2 = new Location(new string[] { "kitchen" }, "kitchen", "this is your kitchen");
            Location location3 = new Location(new string[] { "bath room" }, "bath room", "this is your bath room");
            Location location4 = new Location(new string[] { "dining room" }, "dining room", "this is your dining room");

            Path path1 = new Path(new string[] { "north" }, "north", "You are going north", _player.Location, location1, false);
            Path path2 = new Path(new string[] { "south" }, "south", "You are going south", _player.Location, location2, false);
            Path path3 = new Path(new string[] { "east" }, "east", "You are going east", _player.Location, location3, false);
            Path path4 = new Path(new string[] { "west" }, "west", "You are going west", _player.Location, location4, true);

            _player.Location.AddPath(path1);
            _player.Location.AddPath(path2);
            _player.Location.AddPath(path3);
            _player.Location.AddPath(path4);

            Assert.That(moveCommand.Execute(_player, new string[] { "move", "ahead" }), Is.EqualTo("I do not know that place"));
        }
        [Test]
        public void PathIdentifiable()
        {
            Player _player = new Player("Khang", "friendly student");
            MoveCommand moveCommand = new MoveCommand();
            Location location = new Location(new string[] { "living room" }, "living room", "this is your living room");
            Path pth = new Path(new string[] { "north" }, "north", "You are going north", _player.Location, location, false);
            _player.Location.AddPath(pth);

            Assert.That(_player.Location.Locate("north"), Is.EqualTo(pth));
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
