using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using AuctionHouseClassLibrary.Interfaces;

namespace AuctionHouseClassLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring all the necessary variables and objects

            Auctioneer auctioneer = new Auctioneer();
            Buyer buyer1 = new Buyer(auctioneer, "Ben");
            Buyer buyer2 = new Buyer(auctioneer, "Diana");
            Buyer buyer3 = new Buyer(auctioneer, "Ole");

            Item painting = new Item("Painting", 200);
            Item vase = new Item("Fancy Vase", 150);
            Item retroCar = new Item("Retro Car", 500);

            auctioneer.AddBuyer(buyer1);
            auctioneer.AddBuyer(buyer2);
            auctioneer.AddBuyer(buyer3);

            auctioneer.AddItem(painting);
            auctioneer.AddItem(vase);
            auctioneer.AddItem(retroCar);

            // The auction will now start!

            for (int i = 0; i < auctioneer._items.Count; i++)
            {
                Console.WriteLine($"Now receiving bids for {auctioneer._items[0].name}.");
                Console.WriteLine($"The bidding starts at {auctioneer._items[0].price}$");
                Console.WriteLine("To bid on the item, please write your name followed by the amount your bid.");

                while (auctioneer._items[0]._itemNotSold)
                {

                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Bid: ");
                    int bid = Convert.ToInt32(Console.ReadLine());


                    if (bid > auctioneer._items[0].price)
                    {
                        Buyer bidder = auctioneer.FindBuyer(name);
                        if (bidder != null)
                            bidder.GiveBid(bid);
                        else
                            Console.WriteLine("Bidder was not found.");
                    }

                }
            }

        }
    }

}

