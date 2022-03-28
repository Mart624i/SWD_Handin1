using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseClassLibrary.Interfaces
{
    public interface IBuyer
    {
        void SetAccountBalance();
        void GiveBid();
    }
}
