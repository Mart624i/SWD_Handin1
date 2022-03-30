using System.Runtime.CompilerServices;
using System.Timers;
using Timer = System.Timers.Timer;


namespace AuctionHouseClassLibrary
{
    public class Auctioneer : IMediator
    {
        // Fields & Properties

        private readonly List<Item> _items = new List<Item>();
        //private List<Buyer> _buyers;

        // Trying to implement the list of buyers 
        private readonly List<Buyer> _buyers = new List<Buyer>();

        private Timer _timer = new Timer(5000);



        // Methods
        public void AddBuyer(Buyer buyer)
        {
            _buyers.Add(buyer);
        }

        public void FindHighestBidder()
        {
            // Search for the Buyer with the highest bid
            Buyer highestBidder = new Buyer();
            highestBidder = _buyers[0];
            for (int i = 1; i < _buyers.Count; i++)
            {
                if (_buyers[i].bid > highestBidder.bid)
                {
                    highestBidder = _buyers[i];
                }
            }

            Console.WriteLine($"The highest bidder is {highestBidder.name}. Congratulations, you won the item {_items[0].name}!");

            //When the auction is done, the item is removed from the list of available items. 
            _items.RemoveAt(0);
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void Countdown()
        {
            // Countdown from 5 seconds - when a new bid comes, restart the timer. 
            // Method not yet complete
            _timer.Stop();
            _timer.Start();
            while (_timer.Enabled == true)
            {
                Console.WriteLine("Starting Countdown!");
                //for (int i = 1; i < 6; i++)
                //{
                //    Console.WriteLine($"{i}...");

                //}
            }

            // When the time runs out call
            FindHighestBidder();
        }
    }
}