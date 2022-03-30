

using AuctionHouseClassLibrary.Interfaces;
using System;

namespace AuctionHouseClassLibrary
{
    public class Buyer : IBuyer
    {
        protected IMediator _mediator;
        public string name { get; set; }
        public int accountBalance { get; set; }
        public int bid { get; set; }

        // Constructor 
        public Buyer(IMediator med, string name)
        {
            _mediator = med;
            name = name;
        }

        // Methods

        public void GiveBid(int bid)
        {
            //string userInput;
            //int intVal;

            //Console.WriteLine("Give bid");
            //userInput = Console.ReadLine();
            //intVal = Convert.ToInt32(userInput);

            // Changing method for science...?

            int intVal = bid;

            if (accountBalance >= intVal)
            {
                this.bid = intVal;
                Console.WriteLine("Bid given: " + bid);
                _mediator.Countdown(this);
            }
            else
            {
                Console.WriteLine("Not enough money on account - Account: " + accountBalance + "\nBid exceedes account balance - Bid: " + intVal);
            }
        }

        public void SetAccountBalance()
        {
            string userInputAccountBalance;
            int intValAccountBalance;

            Console.WriteLine("Enter amount on your account: ");
            userInputAccountBalance = Console.ReadLine();
            intValAccountBalance = Convert.ToInt32(userInputAccountBalance);
            Console.WriteLine("AccountBalance: " + intValAccountBalance);

            accountBalance = intValAccountBalance;
        }

        
    }
}