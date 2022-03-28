

using AuctionHouseClassLibrary.Interfaces;

namespace AuctionHouseClassLibrary
{
    public class Buyer : IBuyer
    {

        public int accountBalance { get; set; }
        public int bid { get; set; }
        public void GiveBid()
        {

            string userInput;
            int intVal;

            Console.WriteLine("Give bid");
            userInput = Console.ReadLine();
            intVal = Convert.ToInt32(userInput);
            
            

            if (accountBalance >= intVal)
            {
                this.bid = intVal;
                Console.WriteLine("Bid given: " + bid);
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