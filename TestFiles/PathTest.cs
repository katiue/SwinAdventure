using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture]
    public class PathTest
    {
        [SetUp]
        public void Setup()
        {
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

            Assert.That(moveCommand.Execute(_player,new string[] { "move", "west"}), Is.EqualTo("You are now in bedroom"));
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
    }
}
