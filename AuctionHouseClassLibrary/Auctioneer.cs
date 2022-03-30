using System.Runtime.CompilerServices;
using System.Timers;
using Timer = System.Timers.Timer;


namespace AuctionHouseClassLibrary
{
    public class Auctioneer : IMediator
    {
        // Fields & Properties

        public List<Item> _items = new List<Item>();
        //private List<Buyer> _buyers;

        // Trying to implement the list of buyers 
        public List<Buyer> _buyers = new List<Buyer>();

        private static  Timer _timer;

        // Constructor

        public Auctioneer()
        {
            _timer = new Timer(5000);
            _timer.Elapsed += TimerRunOut;
        }

        private void TimerRunOut(object? sender, ElapsedEventArgs e)
        {
            FindHighestBidder();
        }

        // Methods
        public void AddBuyer(Buyer buyer)
        {
            _buyers.Add(buyer);
        }

        public void FindHighestBidder()
        {
            // Search for the Buyer with the highest bid
            Buyer highestBidder;
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
            _items[0]._itemNotSold = false;
            _items.RemoveAt(0);
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void Countdown(Buyer buyer)
        {
            // Countdown from 5 seconds - when a new bid comes, restart the timer. 
            // Method not yet complete
            if(_timer.Enabled == true)
                _timer.Stop();

            _timer.Start();
            Console.WriteLine("Starting Countdown! Any other bidders?");
        }

        public Buyer? FindBuyer(string name)
        {
            Buyer bidder = null;
            for (int i = 0; i < _buyers.Count; i++)
            {
                if(_buyers[i].name.Contains(name))
                    bidder = _buyers[i];

            }

            return bidder;
        }

    }
}