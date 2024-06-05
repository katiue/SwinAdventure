namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please tell me your name");
            string _name = Console.ReadLine();

            Console.WriteLine("Please tell me about yourself " + _name);
            string _desc = Console.ReadLine();
            
            Player _player = new Player(_name, _desc);
            Console.WriteLine("You are " + _name + ", " + _desc + " nice to meet you\n");

            Item item1 = new Item(new string[] { "Laptop" }, "Computer", "Handy laptop use for programming");
            Item item2 = new Item(new string[] { "Medicine" }, "Medicine", "Medicine pack to keep sanityThe pack included: Celexa, Prozac, Zoloft...");

            Bag bag = new Bag(new string[] { "bag" }, "bag", "A bag");
            bag.Inventory.Put(item1);
            bag.Inventory.Put(item2);

            Item item3 = new Item(new string[] { "Charger" }, "Equipment", "It charges your computer");
            bag.Inventory.Put(item3);
            _player.Inventory.Put(bag);

            Item item4 = new Item(new string[] { "Bed" }, "Furniture", "You never used it");
            _player.Location.Inventory.Put(item4);

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

            while(true)
            {
                CommandProcessor commandProcessor = new CommandProcessor();
                Console.WriteLine("What do you want to do?");
                string[] input = Console.ReadLine().Split(' ');
                Console.WriteLine(commandProcessor.Execute(_player, input));
            }
        }
    }
}
