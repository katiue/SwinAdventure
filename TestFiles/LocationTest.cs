using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SwinAdventure
{
    public class LocationTest
    {
        private Location location = new Location(new string[] { "bedroom" },"bedroom","your workspace");
        private Player player = new Player("player", "player");
        [Test]
        public void LocationIsIdentifiable()
        {
            Assert.IsTrue(location.AreYou("bedroom"));
        }
        [Test]
        public void LocationLocatesItems()
        {
            Item item = new Item(new string[] { "sword" }, "sword", "a sharp sword");
            location.Inventory.Put(item);
            Assert.That(location.Locate("sword"), Is.EqualTo(item));
        }
        [Test]
        public void PlayerLocateItem()
        {
            Item item = new Item(new string[] { "sword" }, "sword", "a sharp sword");
            Location location = new Location(new string[] { "bedroom" }, "bedroom", "your workspace");
            Player player = new Player("player", "player");

            location.Inventory.Put(item);
            player.Location = location;

            Assert.That(player.Location.Locate("sword"), Is.EqualTo(item));
        }
        [Test]
        public void PlayerLookAtLocation()
        {
            Location location = new Location(new string[] { "bedroom" }, "bedroom", "your workspace");
            Player player = new Player("player", "player");

            player.Location = location;

            Assert.That(player.Location.FullDescription, Is.EqualTo("You are in bedroom, your workspace. This place has\n    This place have the current paths: "));
        }
    }
}
