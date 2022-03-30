using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseClassLibrary
{
    interface IMediator
    {
        void AddBuyer(Buyer buyer);
        void FindHighestBidder();

        void AddItem(Item item);
    }
}
