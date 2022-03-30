using AuctionHouseClassLibrary;
using System;
using testLib;

/* Jeg har lavet et nyt library projekt(testLib), som har samme .NET version, som applikationsprojektet(4.7.2). 
 * Det tidligere project, 'AuctionHouseClassLibrary' brugte .NET 6.0, og man kunne derfor ikke lave referencer dertil fra 
 * applikationsprojektet. Jeg unloadede selvfølgelig det tidligere class library i solutionen. 
 * 
 * Derudover flyttede jeg logikken i program.cs, som lagde i 'AuctionHouseClassLibrary' ind den program.cs,
 * som ligger i applikationsprojektet og satte det, som startup-projekt. 
 * 
 * Programmet kan nu godt compile og man når et stykke ved ned, indtil at man løber ind i en System.NullReferenceException,
 * som ikke bliver afviklet. Ud fra consoloutput ser det ud til at den opstår i 'Auctioneer.cs, linje 81 og program.cs, linje 66.
 * 
 * Jeg har ikke fundet en løsning på det. Tror bare vi skal spørge læreren.  
 * 
 * */

namespace AuctionHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 testclass = new Class1();
            testclass.suiii();

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
